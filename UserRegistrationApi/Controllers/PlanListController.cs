using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserRegistration.Models;
using UserRegistrationApi.Data;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanListController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlanListController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PlanList
        [HttpGet]
        public ActionResult<IEnumerable<Plan>> GetPlans()
        {
            var plans = _context.Plans.ToList();
            if (plans == null || !plans.Any())
            {
                return NotFound("No plans found.");
            }
            return Ok(plans);
        }

        // GET: api/PlanList/level/{level}
        [HttpGet("level/{level}")]
        public ActionResult<IEnumerable<Plan>> GetPlansByLevel(string level)
        {
            var levelUpper = level.ToUpper();
            var plans = _context.Plans
                .Where(p => p.Level.ToUpper() == levelUpper)
                .ToList();

            if (plans == null || !plans.Any())
            {
                return NotFound($"No plans found for level: {level}.");
            }
            return Ok(plans);
        }

        // POST: api/PlanList
        [HttpPost]
        public IActionResult AddPlan([FromBody] Plan plan)
        {
            if (plan == null)
            {
                return BadRequest("Plan data is required.");
            }

            _context.Plans.Add(plan);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPlans), new { id = plan.ID }, plan);
        }

        // PUT: api/PlanList/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePlan(int id, [FromBody] Plan updatedPlan)
        {
            var existingPlan = _context.Plans.FirstOrDefault(p => p.ID == id);
            if (existingPlan == null)
            {
                return NotFound("Plan not found.");
            }

            existingPlan.Nameplan = updatedPlan.Nameplan;
            existingPlan.Level = updatedPlan.Level;
            existingPlan.Repeat = updatedPlan.Repeat;
            existingPlan.Time = updatedPlan.Time;
            existingPlan.Favorite = updatedPlan.Favorite;
            existingPlan.Idyoutube = updatedPlan.Idyoutube;
            existingPlan.Imageplan = updatedPlan.Imageplan;

            _context.SaveChanges();

            return Ok(existingPlan);
        }


        // DELETE: api/PlanList/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePlan(int id)
        {
            var plan = _context.Plans.FirstOrDefault(p => p.ID == id);
            if (plan == null)
            {
                return NotFound("Plan not found.");
            }

            _context.Plans.Remove(plan);
            _context.SaveChanges();

            return NoContent();
        }

        // PUT: api/PlanList/{id}/favorite
        [HttpPut("{id}/favorite")]
        public IActionResult UpdateFavoriteStatus(int id, [FromBody] UpdateFavoriteRequest request)
        {
            var plan = _context.Plans.FirstOrDefault(p => p.ID == id);
            if (plan == null)
            {
                return NotFound("Plan not found.");
            }

            plan.Favorite = request.Favorite;
            _context.SaveChanges();

            return Ok(plan);
        }
    }

    public class UpdateFavoriteRequest
    {
        public bool Favorite { get; set; }
    }
}
