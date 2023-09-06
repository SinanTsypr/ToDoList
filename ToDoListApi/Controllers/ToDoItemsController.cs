using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Data;

namespace ToDoListApi.Controllers
{
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ToDoItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<ToDoItem> GetToDoItems()
        {
            return _db.ToDoItems
                .OrderBy(x => x.Done)
                .ToList();
        }

        // Get: api/ToDoItem/3
        [HttpGet("{id}")]
        public ActionResult<ToDoItem> PostToDoItem(int? id) //ActionResult NotFoundResult'da döndürebilmemizi sağlıyor
        {
            var toDoItem = _db.ToDoItems.Find(id);
            if (toDoItem == null)
                return NotFound();

            return toDoItem;
        }

        [HttpPost]
        public ActionResult<ToDoItem> PostToDo(ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                _db.Add(toDoItem);
                _db.SaveChanges();
                return CreatedAtAction(nameof(PostToDoItem), new { id = toDoItem.Id}, toDoItem);
            }

            return BadRequest(ModelState);
        }

        // Delete: api/ToDoItem/3
        [HttpDelete("{id}")]
        public IActionResult DeleteToDoItem(int id)
        {
            var toDoItem = _db.ToDoItems.Find(id);

            if (toDoItem == null)
                return NotFound();

            _db.Remove(toDoItem);
            _db.SaveChanges();

            return NoContent();
        }


        // Put: api/ToDoItems/3
        [HttpPut("{id}")]
        public IActionResult PutToDoItem(int id, ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
                return BadRequest();

            if (!_db.ToDoItems.Any(x => x.Id == id))
                return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(toDoItem);
                _db.SaveChanges();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

    }
}
