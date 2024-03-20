using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApi3.Data;
using SampleApi3.DTO;
using System.Numerics;

namespace SampleApi3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost, Route("/create")]
        public async Task<ActionResult<DTOStudent>> CreateStudent(DTOStudent student)
        {
            try
            {
                var dto = await _dbContext.Students.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                 
                //DTOStudent mDTO = dto.Entity;
                return Ok(dto.Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }  
        
        [HttpGet, Route("/get/list")]
        public async Task<ActionResult<List<DTOStudent>>> CreateStudent()
        {
            try
            {
                var dtos = await _dbContext.Students.AsNoTracking().ToListAsync();
                 
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  
        
        [HttpGet, Route("/get/listbypk/{id}")]
        public async Task<ActionResult<List<DTOStudent>>> FindStudent(Guid id)
        {
            try
            {
                var dto = await _dbContext.Students.FindAsync(id);

                if (dto is null)
                    return NotFound();
                 
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut, Route("/update")]
        public async Task<ActionResult<List<DTOStudent>>> EdittStudent(DTOStudent dto)
        {
            try
            {
                var mDTO = await _dbContext.Students.FindAsync(dto.ID);

                if (mDTO is null)
                    return NotFound();

                mDTO.Name = dto.Name;
                mDTO.Email = dto.Email;
                mDTO.Phone = dto.Phone;
                mDTO.Subscribed = dto.Subscribed;

                await _dbContext.SaveChangesAsync();
                 
                return Ok(mDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("/delete")]
        public async Task<ActionResult<List<DTOStudent>>> DeleteStudent(DTOStudent dto)
        {
            try
            {
                var mDTO = await _dbContext.Students.FindAsync(dto.ID);
              
                if (mDTO is null)
                    return NotFound();

                _dbContext.Students.Remove(mDTO);
                await _dbContext.SaveChangesAsync();
                 
                return Ok(mDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
