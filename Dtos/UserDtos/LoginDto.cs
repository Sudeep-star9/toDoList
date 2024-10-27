using System.ComponentModel.DataAnnotations;

namespace toDoList.Dtos.UserDtos
{
    public class LoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
