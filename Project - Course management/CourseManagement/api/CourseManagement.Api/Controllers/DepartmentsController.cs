using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Domain.Entities;
using CourseManagement.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using CourseManagement.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Memory;
using CourseManagement.Domain.Dtos;

namespace CourseManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IMemoryCache memoryCache;
        public DepartmentsController(ApiDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            this.memoryCache = memoryCache;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentCreateDto>>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            var result = departments.Select(x => x.MapToDepartmentGetDto());
            return Ok(result);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentCreateDto>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department.MapToDepartmentGetDto();
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentCreateDto department)
        {
            if (id != department.DepartmentID)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var cts = new CancellationTokenSource();
                this.memoryCache.Set($"_DP{department.DepartmentID}", cts);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<DepartmentCreateDto>> PostDepartment(DepartmentCreateDto department, [FromHeader(Name = "if-match")][Required] string eTag, CancellationToken cancellationToken)
        {
            if (eTag != department.GetEtag())
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Invalid Etag");
            }

            _context.Departments.Add(department.MapAsNewEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.DepartmentID }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentCreateDto>> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            var cts = this.memoryCache.Get<CancellationTokenSource>($"_DP{id}");
            cts?.Cancel();

            var result = department.MapToDepartmentGetDto();
            return result;
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
