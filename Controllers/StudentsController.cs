using Microsoft.AspNetCore.Mvc;

namespace New_folder.Controllers;

public class StudentsController : ControllerBase
{
    public static List<Student> Students = new List<Student>();

    [HttpPost("/api/student")]
    public IActionResult Create([FromBody] StudentDto studentDto)
    {
        var student = new Student
        {
            Id = Students.Count + 1,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Email = studentDto.Email
        };

        Students.Add(student);
        return Ok(student);
    }

    [HttpGet("/api/student")]
    public IActionResult GetAll([FromQuery] StudentFilterDto filter)
    {
        var students = Students.Where(x =>
            (string.IsNullOrEmpty(filter.FirstName) || x.FirstName.Contains(filter.FirstName)) &&
            (string.IsNullOrEmpty(filter.LastName) || x.LastName.Contains(filter.LastName))
        ).ToList();
        return Ok(students);
    }

    [HttpGet("/api/student/{id}")]
    public IActionResult GetById(int id)
    {
        var student = Students.FirstOrDefault(x => x.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPut("/api/student/{id}")]
    public IActionResult Update(int id, [FromBody] StudentDto studentDto)
    {
        var existingStudent = Students.FirstOrDefault(x => x.Id == id);
        if (existingStudent == null)
        {
            return NotFound();
        }

        existingStudent.FirstName = studentDto.FirstName;
        existingStudent.LastName = studentDto.LastName;
        existingStudent.Email = studentDto.Email;
        
        return Ok("Student updated successfully");
    }

    [HttpDelete("/api/student/{id}")]
    public IActionResult Delete(int id)
    {
        var student = Students.FirstOrDefault(x => x.Id == id);
        if (student == null)
        {
            return NotFound();
        }

        Students.Remove(student);
        return Ok("Student deleted successfully");
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
    public string LastName { get; set; }
    public string Email { get; set; }
    
}

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
}
