using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftLoggerAPI.Models;

namespace ShiftLoggerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftsController : Controller
    {
        private readonly ShiftDbContext _context;

        public ShiftsController(ShiftDbContext shiftDbContext)
        {
            _context = shiftDbContext;
        }

        [HttpGet("getall/")]
        public async Task<IActionResult> GetAllShifts()
        {
            return Ok(await _context.Shifts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShift(int id)
        {
            return Ok(await _context.Shifts.FindAsync(id));
        }

        [HttpPost("post/")]
        public async Task<IActionResult> PostShift([FromBody]Shift shift)
        {
            if (shift is null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Add(shift);
            var created = await _context.SaveChangesAsync();

            return Created("created",created);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateShift([FromBody] Shift shift, int id)
        {
            if (!ShiftExists(id)) return NotFound();

            if (shift is null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            shift.ShiftId = id;
            _context.Shifts.Update(shift);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteShift(int id)
        {
            if (!ShiftExists(id))
                return BadRequest();

            _context.Shifts.Remove(new Shift() { ShiftId = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ShiftExists(int id) => _context.Shifts.Any(s => s.ShiftId == id);
        
    }
}
