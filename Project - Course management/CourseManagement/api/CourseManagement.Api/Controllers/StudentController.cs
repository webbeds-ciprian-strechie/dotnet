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
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;
        private readonly IMemoryCache memoryCache;
        public StudentController(IStudentService studentService, ILogger<StudentController> logger, IMemoryCache memoryCache)
        {
            _studentService = studentService;
            _logger = logger;
            this.memoryCache = memoryCache;
        }

        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetList(CancellationToken cancellationToken)
        {
            var students = await _studentService.GetList(cancellationToken).ConfigureAwait(false);

            return Ok(students.Select(x => x.MapToStudentGetDto()));
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<StudentGetDto>> Get(int id, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("StudentController-Get(id) hit");
            cancellationToken.ThrowIfCancellationRequested();
            var student = await _studentService.Get(id).ConfigureAwait(false);
            if (student == null)
            {
                return NotFound();
            }

            var result = student.MapToStudentGetDto();
            HttpContext.Response.Headers.Add(HeaderNames.ETag, student.GetEtag());

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Post(StudentCreateDto studentCreateDto, [FromHeader] string modifiedBy, CancellationToken cancellationToken)
        {
            if (studentCreateDto == null)
            {
                return BadRequest();
            }

            var existingStudentByCNP = await _studentService.GetByCNP(studentCreateDto.CNP).ConfigureAwait(false);
            if (existingStudentByCNP != null)
            {
                return BadRequest();
            }

            cancellationToken.ThrowIfCancellationRequested();

            var student = studentCreateDto.MapToStudent(modifiedBy);
            var createdStudentGetDto = (await _studentService.Create(student).ConfigureAwait(false)).MapToStudentGetDto();

            _logger.LogInformation($"New student was created: {createdStudentGetDto.Id}");

            var cts = new CancellationTokenSource();
            this.memoryCache.Set($"STUD{createdStudentGetDto.Id}", cts);


            return CreatedAtAction(nameof(Get), new { createdStudentGetDto.Id }, createdStudentGetDto);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public async Task<ActionResult> Put(int id, StudentUpdateDto studentUpdateDto, [FromHeader] string modifiedBy, [FromHeader(Name = "if-match")][Required] string eTag, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (eTag == null)
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Invalid If-Match");
            }

            if (studentUpdateDto == null)
            {
                return BadRequest("Invalid body!");
            }

            var student = await _studentService.Get(id).ConfigureAwait(false);
            if (student == null)
            {
                return NotFound("Invalid Student id!");
            }

            if (eTag != student.GetEtag())
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Invalid Etag");
            }

            cancellationToken.ThrowIfCancellationRequested();

            var existingStudentByCnp = await _studentService.GetByCNP(studentUpdateDto.CNP).ConfigureAwait(false);
            if (existingStudentByCnp != null && existingStudentByCnp.Id != id)
            {
                return BadRequest("Student already exist!");
            }

            var studentGetDto = student.MapToStudentGetDto();
            if (studentUpdateDto.Equals(studentGetDto))
            {
                return BadRequest("Student No Update!");
            }

            student.SetFromStudentUpdateDto(studentUpdateDto, modifiedBy);

            await _studentService.Update(student).ConfigureAwait(false);

            _logger.LogInformation($"Student {id} was updated.");

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Student>> Delete(int id, CancellationToken cancellationToken)
        {
            var student = await _studentService.Get(id).ConfigureAwait(false);
            if (student == null)
            {
                return NotFound("Invalid Student id!");
            }

            cancellationToken.ThrowIfCancellationRequested();

            await _studentService.Delete(id).ConfigureAwait(false);

            var result = student.MapToStudentGetDto();

            var cts = this.memoryCache.Get<CancellationTokenSource>($"STUD{id}");
            cts?.Cancel();

            return Ok(result);
        }
    }
}
