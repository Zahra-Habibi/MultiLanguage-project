using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLanguage.Core.ViewModels
{
    public class UserViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Department { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public string UserImg { get; set; }
    }
}
