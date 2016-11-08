using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatSignalR.Models
{
    public class User
    {
        public int Id { get; set; }
      
        [RegularExpression(@"[A-Z|a-z|0-9|_]{3,15}", ErrorMessage = "Login may contain of upper/lowercase letters, numbers and _")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Login must be from 3 to 15 symbols")]
        [Required(ErrorMessage = "Enter login")]
        public string Name { get; set; }
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be from 6 to 20 symbols")]
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        [Required(ErrorMessage = "Enter e-mail")]
        public string Email { get; set; }
        [NotMapped]
        public string ConnectionId { get; set; }
    }
}