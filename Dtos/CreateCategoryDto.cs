using System.ComponentModel.DataAnnotations;

namespace toDoList.Dtos
{
    public class CreateCategoryDto
    {
        [Required (ErrorMessage ="Name Is Required")]
        public string Name { get; set; } = string.Empty;
    }
}
