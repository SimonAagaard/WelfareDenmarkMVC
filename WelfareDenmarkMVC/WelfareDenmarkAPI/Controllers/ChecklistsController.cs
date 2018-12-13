using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        [HttpPut("{checklist.Id}")]
        public HttpResponseMessage PutChecklistAPI(Checklist checklist)
        {
            if (checklist == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            _context.Entry(checklist).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChecklistExists(checklist.Id))
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                else
                {
                    throw;
                }
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //PUT: api/Checklists/5
        //[HttpPut("{checklist.Id}")]
        //public async Task<IActionResult> PutChecklist([FromRoute] Checklist checklist)
        //{

        //    var json = JsonConvert.DeserializeObject(checklist);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!ChecklistExists(checklist.Id))
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(checklist).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ChecklistExists(checklist.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

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