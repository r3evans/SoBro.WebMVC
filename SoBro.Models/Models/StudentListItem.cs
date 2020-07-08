using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Models.Models
{
    public enum Rank { White = 1, Blue, Purple, Brown, Black }
    public class StudentListItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Rank Rank { get; set; }

        public Guid StudentID { get; set; }
        public bool Active { get; set; }
        public int Age { get; set; }
    }
}
