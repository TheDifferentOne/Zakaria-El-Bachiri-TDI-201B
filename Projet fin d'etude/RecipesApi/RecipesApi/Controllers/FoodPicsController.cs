using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesApi.Models;

namespace RecipesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodPicsController : ControllerBase
    {
        private readonly ProjetFinEtudeContext _context;

        public FoodPicsController(ProjetFinEtudeContext context)
        {
            _context = context;
        }

        // GET: api/FoodPics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodPic>>> GetFoodPics()
        {
            return await _context.FoodPics.ToListAsync();
        }

        // GET: api/FoodPics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodPic>> GetFoodPic(int id)
        {
            var foodPic = await _context.FoodPics.FindAsync(id);

            if (foodPic == null)
            {
                return NotFound();
            }

            return foodPic;
        }

        // PUT: api/FoodPics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodPic(int id, FoodPic foodPic)
        {
            if (id != foodPic.Id)
            {
                return BadRequest();
            }

            _context.Entry(foodPic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodPicExists(id))
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

        // POST: api/FoodPics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodPic>> PostFoodPic(FoodPic foodPic)
        {
            _context.FoodPics.Add(foodPic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodPic", new { id = foodPic.Id }, foodPic);
        }

        // DELETE: api/FoodPics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodPic(int id)
        {
            var foodPic = await _context.FoodPics.FindAsync(id);
            if (foodPic == null)
            {
                return NotFound();
            }

            _context.FoodPics.Remove(foodPic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodPicExists(int id)
        {
            return _context.FoodPics.Any(e => e.Id == id);
        }
    }
}
