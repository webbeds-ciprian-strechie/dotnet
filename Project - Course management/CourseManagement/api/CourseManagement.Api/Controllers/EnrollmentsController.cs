using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Domain.Entities;
using CourseManagement.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using CourseManagement.Infrastructure.Extensions;
using CourseManagement.Domain.Dtos;

namespace CourseManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IMemoryCache memoryCache;

        public EnrollmentsController(ApiDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            this.memoryCache = memoryCache;
        }

        // GET: api/Enrollments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentCreateDto>>> GetEnrollments()
        {
            var enrollments = await _context.Enrollments.ToListAsync();
            var result = enrollments.Select(x => x.MapToEnrollmentGetDto());
            return Ok(result);
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentCreateDto>> GetEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return enrollment.MapToEnrollmentGetDto();
        }

        // PUT: api/Enrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollment(int id, EnrollmentCreateDto enrollment)
        {
            if (id != enrollment.Id)
            {
                return BadRequest();
            }

            _context.Entry(enrollment.MapAsNewEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(id))
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

        // POST: api/Enrollments
        [HttpPost]
        public async Task<ActionResult<EnrollmentCreateDto>> PostEnrollment(EnrollmentCreateDto enrollment)
        {
            _context.Enrollments.Add(enrollment.MapAsNewEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnrollment", new { id = enrollment.Id }, enrollment);
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnrollmentCreateDto>> DeleteEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return enrollment.MapToEnrollmentGetDto();
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.Id == id);
        }
    }
}
