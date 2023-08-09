using System.ComponentModel.DataAnnotations;

namespace Mortiz.Domain.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введіть email")]
     public   String Email { get; set; }
        [Required(ErrorMessage = "Введіть пароль")]
        public String Password { get; set; }
    }
}
