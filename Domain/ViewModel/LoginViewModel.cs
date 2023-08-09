using System.ComponentModel.DataAnnotations;

namespace Mortiz.Domain.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введіть email")]
     public   String Email { get; set; }
        [Required(ErrorMessage = "Введіть парол")]

      public   String Password { get; set; }

    }
}
