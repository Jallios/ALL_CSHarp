using System;
using System.Collections.Generic;

namespace APIProject.Models
{
    public partial class User
    {
        public int? IdUser { get; set; }
        public string? SurnameUser { get; set; } = null!;
        public string? NameUser { get; set; } = null!;
        public string? PatronymicUser { get; set; } = null!;
        public string? SeriNumUser { get; set; } = null!;
        public string? MobileNumberUser { get; set; } = null!;
        public string? LoginUser { get; set; } = null!;
        public string? PasswordUser { get; set; } = null!;
        public int? UserRoleId { get; set; }
    }
}
