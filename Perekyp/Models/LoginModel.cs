using System.ComponentModel.DataAnnotations;

namespace Perekyp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "He указан пароль")] 

        [DataType(DataType.Password)] 
        public string Password { get; set; }
    }
}
