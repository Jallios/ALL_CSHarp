using System;
using System.Collections.Generic;

namespace WHATEVEVR_API.Models
{
    public partial class User
    {
        public int? IdUser { get; set; }
        public string? LoginUser { get; set; } = null!;
        public string? PasswordUser { get; set; } = null!;
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public int? StatusUserId { get; set; }
    }
}
