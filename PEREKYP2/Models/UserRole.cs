using System;
using System.Collections.Generic;

namespace PEREKYP2.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int IdUserRole { get; set; }
        public string Role { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
