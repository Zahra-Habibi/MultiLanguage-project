using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multipisus.DataLayer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Department { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }

        public string UserImg { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

    }
}
