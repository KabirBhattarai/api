//
// using Microsoft.AspNetCore.Mvc;
//
// namespace New_folder.Controllers
// {
//     public class PersonController : ControllerBase
//     {
//         public static List<Person> People = new List<Person>();
//
//         [HttpPost("/api/person")]
//         public IActionResult Create([FromBody] PersonDto personDto)
//         {
//             try
//             {
//                 if (string.IsNullOrEmpty(personDto.Name))
//                 {
//                     return BadRequest("Name is required");
//                 }
//
//                 var person = new Person
//                 {
//                     Id = People.Count + 1,
//                     Name = personDto.Name
//                 };
//
//                 People.Add(person);
//                 return Ok(person);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//
//         [HttpGet("/api/person/{id}")]
//         public IActionResult GetById(int id)
//         {
//             try
//             {
//                 var person = People.FirstOrDefault(x => x.Id == id);
//                 if (person == null)
//                 {
//                     return NotFound();
//                 }
//
//                 return Ok(person);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//
//         [HttpGet("/api/person")]
//         public IActionResult GetAll([FromQuery] PersonDto filter)
//         {
//             var people = People.Where(x =>
//                 (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase))
//             ).ToList();
//
//             return Ok(people);
//         }
//
//
//         [HttpPut("/api/person/{id}")]
//         public IActionResult Update(int id, [FromBody] PersonDto personDto)
//         {
//             try
//             {
//                 var existingPerson = People.FirstOrDefault(x => x.Id == id);
//                 if (existingPerson == null)
//                 {
//                     return NotFound();
//                 }
//
//                 if (string.IsNullOrEmpty(personDto.Name))
//                 {
//                     return BadRequest("Name is required.");
//                 }
//
//                 existingPerson.Name = personDto.Name;
//
//                 return Ok("Person updated successfully");
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//
//         [HttpDelete("/api/person/{id}")]
//         public IActionResult Delete(int id)
//         {
//             try
//             {
//                 var person = People.FirstOrDefault(x => x.Id == id);
//                 if (person == null)
//                 {
//                     return NotFound();
//                 }
//
//                 People.Remove(person);
//                 return Ok("Person deleted successfully");
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//
//         public class PersonDto
//         {
//             public string Name { get; set; }
//         }
//
//         public class Person
//         {
//             public int Id { get; set; }
//             public string Name { get; set; }
//             
//         }
//     }
// }
