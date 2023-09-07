using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.API.Interfaces;
using StudentManagementSystem.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }



        // GET: api/<InstructorsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("getallinstructors")]
        public async Task<ActionResult<IList<Instructor>>> GetAllInstructors()
        {
            try
            {
                return Ok(await _instructorService.GetAllInstructors());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database!");
            }
        }



        // GET api/<InstructorsController>/5
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("getinstructor/{id}")]
        public async Task<ActionResult<Instructor>> GetInstructor(int id)
        {
            try
            {
                Instructor instructor = await _instructorService.GetInstructor(id);
            
                if (instructor == null)
                {
                    return NotFound($"Instructor with ID = {id} was not found!");
                }

                return Ok(instructor);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database!");
            }
        }



        // POST api/<InstructorsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("createinstructor")]
        public async Task<ActionResult<Instructor>> CreateInstructor([FromBody] Instructor instructor)
        {
            try
            {
                if (instructor == null)
                {
                    return BadRequest("Cannot pass a null payload!");
                }
                var createdInstructor = await _instructorService.AddInstructor(instructor);
                return CreatedAtAction(nameof(GetInstructor), new { id = createdInstructor.Id }, createdInstructor);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data to the database!");
            }
        }



        // PUT api/<InstructorsController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("updateinstructor")]
        public async Task<ActionResult<Instructor>> UpdateInstructor([FromBody] Instructor instructor)
        {
            try
            {
                if (instructor == null)
                {
                    return BadRequest("Cannot pass a null payload!");
                }

                Instructor existingInstructor = await _instructorService.GetInstructor(instructor.Id);

                if (existingInstructor == null)
                {
                    return NotFound($"Instructor with ID = {instructor.Id} was not found!");
                }

                Instructor updatedInstructor = await _instructorService.UpdateInstructor(instructor);

                return Ok(updatedInstructor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database!");
            }
        }



        // DELETE api/<InstructorsController>/5
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("deleteinstructor/{id}")]
        public async Task<ActionResult<Instructor>> DeleteInstructor(int id)
        {
            try
            {
                Instructor instructor = await _instructorService.GetInstructor(id);

                if (instructor == null)
                {
                    return NotFound($"Instructor with ID = {id} was not found!");
                }

                Instructor deleteinstructor = await _instructorService.DeleteInstructor(id);

                return Ok(deleteinstructor);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database!");
            }
        }
    }
}
