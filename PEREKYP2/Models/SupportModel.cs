using System.ComponentModel.DataAnnotations;

namespace PEREKYP2.Models
{
    public class SupportModel
    {
        [Required(ErrorMessage = "Hе указано Имя")]
        public string Name { get; set; }
        [RegularExpression(@"[A-Za-z0-9._+-]+@[A-Za-z0-9.-]+. [A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Required(ErrorMessage = "Не указан E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Message{get; set; }
}
}
