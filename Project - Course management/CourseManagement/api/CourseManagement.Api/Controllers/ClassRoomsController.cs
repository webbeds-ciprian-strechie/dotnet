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
    public class ClassRoomsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IMemoryCache memoryCache;
        public ClassRoomsController(ApiDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            this.memoryCache = memoryCache;
        }

        // GET: api/ClassRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassRoomCreateDto>>> GetClassRooms()
        {
            var classRooms = await _context.ClassRooms.ToListAsync();
            var result = classRooms.Select(x => x.MapToClassRoomCreateDto());
            return Ok(result);
        }

        // GET: api/ClassRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassRoomCreateDto>> GetClassRoom(int id)
        {
            var classRoom = await _context.ClassRooms.FindAsync(id);
            var result = classRoom.MapToClassRoomCreateDto();

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/ClassRooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassRoom(int id, ClassRoomCreateDto classRoom, [FromHeader(Name = "if-match")][Required] string eTag, CancellationToken cancellationToken)
        {
            if (id != classRoom.Id)
            {
                return BadRequest();
            }

            if (eTag != classRoom.GetEtag())
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Invalid Etag");
            }

            _context.Entry(classRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var cts = new CancellationTokenSource();
                this.memoryCache.Set($"_CR{classRoom.Id}", cts);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassRoomExists(id))
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

        // POST: api/ClassRooms
        [HttpPost]
        public async Task<ActionResult<ClassRoomCreateDto>> PostClassRoom(ClassRoomCreateDto classRoom)
        {
            _context.ClassRooms.Add(classRoom.MapAsNewEntity());
            await _context.SaveChangesAsync();

            var cts = new CancellationTokenSource();
            this.memoryCache.Set($"_CLS{classRoom.Id}", classRoom);

            return CreatedAtAction("GetClassRoom", new { id = classRoom.Id }, classRoom);
        }

        // DELETE: api/ClassRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClassRoomCreateDto>> DeleteClassRoom(int id)
        {
            var classRoom = await _context.ClassRooms.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }

            _context.ClassRooms.Remove(classRoom);
            await _context.SaveChangesAsync();
            var result = classRoom.MapToClassRoomCreateDto();

            var cts = this.memoryCache.Get<CancellationTokenSource>($"_CLS{id}");
            cts?.Cancel();

            return result;
        }

        private bool ClassRoomExists(int id)
        {

            return _context.ClassRooms.Any(e => e.Id == id);
        }
    }
}
