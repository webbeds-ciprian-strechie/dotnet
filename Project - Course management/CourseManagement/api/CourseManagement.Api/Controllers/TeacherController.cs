using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManagement.Application.Services;
using CourseManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using CourseManagement.Domain.Dtos;
using CourseManagement.Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ITeacherService teacherService, ILogger<TeacherController> logger)
        {
            _teacherService = teacherService;
            _logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TeacherGetDto>>> GetList(CancellationToken cancellationToken)
        {
            var teachers = await _teacherService.GetList(cancellationToken).ConfigureAwait(false);

            return Ok(teachers.Select(x => x.MapToTeacherGetDto()));
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TeacherGetDto>> Get(int id, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("TeacherController-Get(id) hit");

            var teacher = await _teacherService.Get(id).ConfigureAwait(false);
            if (teacher == null)
            {
                return NotFound();
            }

            var result = teacher.MapToTeacherGetDto();
            HttpContext.Response.Headers.Add(HeaderNames.ETag, teacher.GetEtag());

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Post(TeacherCreateDto teacherCreateDto, [FromHeader] string modifiedBy, CancellationToken cancellationToken)
        {
            if (teacherCreateDto == null)
            {
                return BadRequest();
            }

            var teacher = teacherCreateDto.MapToTeacher(modifiedBy);
            var createdTeacherGetDto = (await _teacherService.Create(teacher).ConfigureAwait(false)).MapToTeacherGetDto();

            _logger.LogInformation($"New teacher was created: {createdTeacherGetDto.Id}");

            return CreatedAtAction(nameof(Get), new { createdTeacherGetDto.Id }, createdTeacherGetDto);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public async Task<ActionResult> Put(int id, TeacherUpdateDto teacherUpdateDto, [FromHeader] string modifiedBy, [FromHeader(Name = "if-match")][Required] string eTag, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (eTag == null)
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Invalid If-Match");
            }

            if (teacherUpdateDto == null)
            {
                return BadRequest("Invalid body!");
            }

            var teacher = await _teacherService.Get(id).ConfigureAwait(false);
            if (teacher == null)
            {
                return NotFound("Invalid Teacher id!");
            }

            if (eTag != teacher.GetEtag())
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Invalid Etag");
            }

            var teacherGetDto = teacher.MapToTeacherGetDto();
            if (teacherUpdateDto.Equals(teacherGetDto))
            {
                return BadRequest("Teacher No Update!");
            }

            cancellationToken.ThrowIfCancellationRequested();

            teacher.SetFromTeacherUpdateDto(teacherUpdateDto, modifiedBy);

            await _teacherService.Update(teacher).ConfigureAwait(false);

            _logger.LogInformation($"Teacher {id} was updated.");

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Teacher>> Delete(int id, CancellationToken cancellationToken)
        {
            var teacher = await _teacherService.Get(id).ConfigureAwait(false);
            if (teacher == null)
            {
                return NotFound("Invalid Teacher id!");
            }

            cancellationToken.ThrowIfCancellationRequested();

            await _teacherService.Delete(id).ConfigureAwait(false);

            var result = teacher.MapToTeacherGetDto();

            return Ok(result);
        }
    }
}
