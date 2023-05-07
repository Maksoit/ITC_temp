using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("/api/[controller]")]
    public class StudentsController : Controller
    {
        [HttpGet]
        public IEnumerable<Student> Get() => API.Data.data_for.students;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = API.Data.data_for.students.SingleOrDefault(p => p.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            API.Data.data_for.students.Remove(API.Data.data_for.students.SingleOrDefault(p => p.Id == id));
            return Ok(new {message = "OMG"});
        }

        private int NextStudentId => API.Data.data_for.students.Count() == 0 ? 1 : API.Data.data_for.students.Max(x => x.Id) +1;

        [HttpGet("GetNextStudentId")]
        public int GetNextProductId()
        {
            return NextStudentId;
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            student.Id = NextStudentId;
            API.Data.data_for.students.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPost("AddStudent")]
        public IActionResult PostBody([FromBody] Student student) => Post(student);

        [HttpPut]
        public IActionResult Put(Student student)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var storedProduct = API.Data.data_for.students.SingleOrDefault(p => p.Id == student.Id);
            if (storedProduct == null) return NotFound();
            storedProduct.name =  student.name;
            
            return Ok(storedProduct);
        }

        [HttpPut("PutStudent")]
        public IActionResult PutBody([FromBody] Student student) => Put(student);

    }
}

//TODO
//не вписывать объект возрастом больше 25 (валидаторы)
//Посмотреть обращение по ссылкам
//Общаться с контрлером через голый браузер (для maui, чтобы он поолучал
//json по ссылке
// local/sudent/get/id ? id = 5
//Разобраться с EF !!!!!!!
//Linq запросы к EF моделям!
