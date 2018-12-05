using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WelfareDenmarkAPI.Models;

namespace WelfareDenmarkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistsController : ControllerBase
    {
        private readonly ChecklistContext _context;

        public ChecklistsController(ChecklistContext context)
        {
            _context = context;
        }

        // GET: api/Checklists
        [HttpGet]
        public IEnumerable<Checklist> GetChecklists()
        {
            return _context.Checklists;
        }

        // GET: api/Checklists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChecklist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checklist = await _context.Checklists.FindAsync(id);

            if (checklist == null)
            {
                return NotFound();
            }

            return Ok(checklist);
        }

        // PUT: api/Checklists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChecklist([FromRoute] int id, [FromBody] Checklist checklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checklist.Id)
            {
                return BadRequest();
            }

            _context.Entry(checklist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChecklistExists(id))
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

        // POST: api/Checklists
        [HttpPost]
        public async Task<IActionResult> PostChecklist([FromBody] Checklist checklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Checklists.Add(checklist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChecklist", new { id = checklist.Id }, checklist);
        }

        // DELETE: api/Checklists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChecklist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checklist = await _context.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }

            _context.Checklists.Remove(checklist);
            await _context.SaveChangesAsync();

            return Ok(checklist);
        }

        private bool ChecklistExists(int id)
        {
            return _context.Checklists.Any(e => e.Id == id);
        }
    }
}