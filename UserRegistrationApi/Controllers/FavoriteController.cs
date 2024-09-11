using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserRegistration.Models;
using UserRegistrationApi.Data;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Favorite/plans
        [HttpGet("plans")]
        public ActionResult<IEnumerable<Plan>> GetFavoritePlans()
        {
            var favoritePlans = _context.Plans.Where(p => p.Favorite == true).ToList();
            if (favoritePlans == null || !favoritePlans.Any())
            {
                return NotFound("No favorite plans found.");
            }
            return Ok(favoritePlans);
        }

        // GET: api/Favorite/nutris
        [HttpGet("nutris")]
        public ActionResult<IEnumerable<Nutri>> GetFavoriteNutris()
        {
            var favoriteNutris = _context.Nutris.Where(n => n.Favorite == true).ToList();
            if (favoriteNutris == null || !favoriteNutris.Any())
            {
                return NotFound("No favorite nutris found.");
            }
            return Ok(favoriteNutris);
        }
    }
}
