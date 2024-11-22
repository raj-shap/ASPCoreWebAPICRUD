using ASPCoreWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICRUD.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentAPIController : ControllerBase
	{
		private readonly MyDbContext _Context;

        public StudentAPIController(MyDbContext Context)
        {
            _Context = Context;
        }
		[HttpGet]
		public async Task<ActionResult<List<Student>>> GetStudent()
		{
			var data = await _Context.Students.ToListAsync();
			return Ok(data);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Student>> GetStudentById(int id)
		{
			var data = await _Context.Students.FindAsync(id);
			if (data == null) { 
				return NotFound();
			}

			return data;
		}
		[HttpPost]
		public async Task<ActionResult<Student>> CreateStudent(Student student)
		{
			await _Context.Students.AddAsync(student);
			await _Context.SaveChangesAsync();
			return Ok(student);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
		{
			if(id != student.Id)
			{
				return BadRequest();
			}
			_Context.Entry(student).State = EntityState.Modified;
			await _Context.SaveChangesAsync();
			return Ok(student);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<Student>> DeleteStudent(int id)
		{
			var std = await _Context.Students.FindAsync(id);
			if (std == null)
			{
				return NotFound();
			}
			_Context.Students.Remove(std);
			await _Context.SaveChangesAsync();
			return Ok();
		}
    }
}
