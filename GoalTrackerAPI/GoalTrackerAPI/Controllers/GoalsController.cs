using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoalTrackerAPI.Models;

namespace GoalTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GoalsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/goals
        [HttpPost]
        public async Task<ActionResult<Goals>> CreateGoal([FromBody] Goals goal)
        {


            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGoal), new { id = goal.Id }, goal);
        }

        // GET: api/goals/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Goals>> GetGoal(int id)
        {
            var goal = await _context.Goals.FindAsync(id);

            if (goal == null)
            {
                return NotFound();
            }

            return goal;
        }

        // GET: api/goals/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Goals>>> GetGoalsByUser(int userId)
        {
            var goals = await _context.Goals
                .Where(g => g.UserId == userId)
                .ToListAsync();

            return Ok(goals);
        }

        // DELETE: api/goals/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var goal = await _context.Goals.FindAsync(id);

            if (goal == null)
            {
                return NotFound();
            }

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
