using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Models.Models
{
   
    public class StudentCreate
    {
        [Key]
        [Required]
        public int StudentId { get; set; }
        public Guid OwnerID { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Range(13, 80, ErrorMessage = "Please put a proper age.")]
        public int Age { get; set; }
        [Required]
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        [Required]
        public Rank Rank { get; set; }
    }
}
