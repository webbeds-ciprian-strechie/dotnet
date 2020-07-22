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

namespace CourseManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfficeAssignmentsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IMemoryCache memoryCache;
        public OfficeAssignmentsController(ApiDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            this.memoryCache = memoryCache;
        }

        // GET: api/OfficeAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeAssignment>>> GetOfficeAssignments()
        {
            return await _context.OfficeAssignments.ToListAsync();
        }

        // GET: api/OfficeAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeAssignment>> GetOfficeAssignment(int id)
        {
            var officeAssignment = await _context.OfficeAssignments.FindAsync(id);

            if (officeAssignment == null)
            {
                return NotFound();
            }

            return officeAssignment;
        }

        // PUT: api/OfficeAssignments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeAssignment(int id, OfficeAssignment officeAssignment, [FromHeader(Name = "if-match")][Required] string eTag, CancellationToken cancellationToken)
        {
            if (id != officeAssignment.TeacherID)
            {
                return BadRequest();
            }

            if (eTag != officeAssignment.GetEtag())
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Invalid Etag");
            }

            _context.Entry(officeAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var cts = new CancellationTokenSource();
                this.memoryCache.Set($"_OS{officeAssignment.TeacherID}", cts);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeAssignmentExists(id))
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

        // POST: api/OfficeAssignments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OfficeAssignment>> PostOfficeAssignment(OfficeAssignment officeAssignment)
        {
            _context.OfficeAssignments.Add(officeAssignment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OfficeAssignmentExists(officeAssignment.TeacherID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOfficeAssignment", new { id = officeAssignment.TeacherID }, officeAssignment);
        }

        // DELETE: api/OfficeAssignments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfficeAssignment>> DeleteOfficeAssignment(int id)
        {
            var officeAssignment = await _context.OfficeAssignments.FindAsync(id);
            if (officeAssignment == null)
            {
                return NotFound();
            }

            _context.OfficeAssignments.Remove(officeAssignment);
            await _context.SaveChangesAsync();

            var cts = this.memoryCache.Get<CancellationTokenSource>($"_OS{id}");
            cts?.Cancel();

            return officeAssignment;
        }

        private bool OfficeAssignmentExists(int id)
        {
            return _context.OfficeAssignments.Any(e => e.TeacherID == id);
        }
    }
}
