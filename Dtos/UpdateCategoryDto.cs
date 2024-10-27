using System.ComponentModel.DataAnnotations;

namespace toDoList.Dtos
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
    }
}
