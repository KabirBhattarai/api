using Dapper;
using Microsoft.AspNetCore.Mvc;
using New_folder.Repositories;
using New_folder.Services;
using Npgsql;

namespace New_folder.Controllers;

public class StudentsController : ControllerBase
{
    
    private readonly StudentService _studentService;
    private readonly StudentRepository _studentRepository;
    
    public StudentsController(StudentService studentService, StudentRepository studentRepository)
    {
        _studentService = studentService;
        _studentRepository = studentRepository;
    }

    

    [HttpPost("/api/student")]
    public async Task<IActionResult> Create([FromBody] StudentDto studentDto)
    {
        try
        {
            await _studentService.CreateAsync(studentDto);
            return Ok("Student created Successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    

    [HttpGet("/api/student/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var student = await _studentRepository.GetByIdAsync(id);
            
            if (student == null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/api/student")]
    public async Task<IActionResult> GetAll([FromQuery] StudentFilterDto filter)
    {
        try
        {
            var students = await _studentRepository.GetAllAsync(filter.FirstName);
            return Ok(students);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("/api/student/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] StudentDto studentDto)
    {
        try
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return NotFound("Student not found");
            }

            await _studentService.UpdateAsync(id, studentDto);
            return Ok("Student updated successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpDelete("/api/student/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return NotFound("Student not found");
            }

            await _studentService.DeleteAsync(id);
            return Ok("Student deleted successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}

public class StudentFilterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class StudentDto
{
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    
}

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
}
