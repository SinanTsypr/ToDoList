using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Data
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        public bool Done { get; set; }
    }
}
