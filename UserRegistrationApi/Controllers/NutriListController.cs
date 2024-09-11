using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserRegistration.Models;
using UserRegistrationApi.Data;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutriListController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NutriListController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("count")]
        public async Task<IActionResult> GetNutriCount()
        {
            try
            {
                var count = await _context.Nutris.CountAsync(); // Sửa từ NutriList thành Nutris
                return Ok(new { count });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/NutriList
        [HttpGet]
        public ActionResult<IEnumerable<Nutri>> GetNutris()
        {
            var nutris = _context.Nutris.ToList();
            if (nutris == null || !nutris.Any())
            {
                return NotFound();
            }
            return Ok(nutris);
        }

        // POST: api/NutriList
        [HttpPost]
        public IActionResult CreateNutri([FromBody] Nutri nutri)
        {
            if (nutri == null)
            {
                return BadRequest("Nutri data is required.");
            }

            _context.Nutris.Add(nutri);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetNutris), new { id = nutri.Id }, nutri);
        }

        // PUT: api/NutriList/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateNutri(int id, [FromBody] Nutri updatedNutri)
        {
            if (updatedNutri == null)
            {
                return BadRequest("Nutri data is required.");
            }

            var existingNutri = _context.Nutris.FirstOrDefault(n => n.Id == id);
            if (existingNutri == null)
            {
                return NotFound();
            }

            // Update the existing Nutri with the new data
            existingNutri.Calo = updatedNutri.Calo;
            existingNutri.TimeCook = updatedNutri.TimeCook;
            existingNutri.Meal = updatedNutri.Meal;
            existingNutri.Imagenutri = updatedNutri.Imagenutri;
            existingNutri.Ready = updatedNutri.Ready;
            existingNutri.HowToCook = updatedNutri.HowToCook;
            existingNutri.Favorite = updatedNutri.Favorite;

            _context.SaveChanges();

            return Ok(existingNutri);
        }

        // DELETE: api/NutriList/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteNutri(int id)
        {
            var nutri = _context.Nutris.FirstOrDefault(n => n.Id == id);
            if (nutri == null)
            {
                return NotFound();
            }

            _context.Nutris.Remove(nutri);
            _context.SaveChanges();

            return NoContent(); // Return 204 No Content
        }

        public class UpdateFavoriteRequestNutri
        {
            public bool Favorite { get; set; }
        }
    }
}
