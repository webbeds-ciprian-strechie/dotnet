namespace Hotels.Api.Controllers
{
    using Hotels.Api.Data;
    using Hotels.Api.Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly Data.ApiDbContext context;

        public HotelsController(ApiDbContext context)
        {
            this.context = context;
        }

        // GET: api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await this.context.Hotels.ToListAsync();
        }

        // GET: api/hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotelItem(int id)
        {
            var hotelItem = await this.context.Hotels.FindAsync(id);

            if (hotelItem == null)
            {
                return this.NotFound();
            }

            return hotelItem;
        }


        // PUT: api/hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelItem(int id, Hotel hotelItem)
        {
            if (id < 0)
            {
                throw new ArgumentException("negative id");
            }

            this.context.Entry(hotelItem).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.HotelItemExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.NoContent();
        }


        // POST: api/hotels
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotelItem(Hotel hotelItem)
        {
            this.context.Hotels.Add(hotelItem);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("GetHotelItem", new { id = hotelItem.Id }, hotelItem);
        }

        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteTodoItem(long id)
        {
            var hotelItem = await this.context.Hotels.FindAsync(id);

            if (hotelItem == null)
            {
                return this.NotFound();
            }

            this.context.Hotels.Remove(hotelItem);
            await this.context.SaveChangesAsync();

            return hotelItem;
        }


        private bool HotelItemExists(int id)
        {
            return this.context.Hotels.Any(e => e.Id == id);
        }
    }
}
