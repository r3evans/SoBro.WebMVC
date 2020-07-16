using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Models.Models
{
    public class StudentEdit
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Rank Rank { get; set; }
        public decimal Weight { get; set; }
        public bool Active { get; set; }
        public Guid StudentId { get; set; }


    }
}
