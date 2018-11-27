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
    public class PersonController : ControllerBase
    {
        private readonly PersonDS _context;

        public PersonController(PersonDS context)
        {
            _context = context;
        }

        // GET: api/Person
        [HttpGet]
        public IEnumerable<PersonDTO> GetPersonDTO()
        {
            return _context.PersonDTO;
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonDTO([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personDTO = await _context.PersonDTO.FindAsync(id);

            if (personDTO == null)
            {
                return NotFound();
            }

            return Ok(personDTO);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonDTO([FromRoute] int id, [FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(personDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonDTOExists(id))
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

        // POST: api/Person
        [HttpPost]
        public async Task<IActionResult> PostPersonDTO([FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonDTO.Add(personDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonDTO", new { id = personDTO.Id }, personDTO);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonDTO([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personDTO = await _context.PersonDTO.FindAsync(id);
            if (personDTO == null)
            {
                return NotFound();
            }

            _context.PersonDTO.Remove(personDTO);
            await _context.SaveChangesAsync();

            return Ok(personDTO);
        }

        private bool PersonDTOExists(int id)
        {
            return _context.PersonDTO.Any(e => e.Id == id);
        }
    }
}