using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Data
{
   public enum Rank { White = 1, Blue, Purple, Brown, Black }
    public class Student
    {
        public Guid OwnerId { get; set; }

        [Key]
        [Required]
        public Guid StudentId { get; set; }

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
        [Required]
        public decimal Weight { get; set; }
        
        public Rank Rank { get; set; }

       // [ForeignKey("Competition")]
       // [Required]
        public int CompetitionID { get; set; }
        public virtual Competition Competition { get; set; }

        [ForeignKey("Technique")]
      
        public int TechniqueID { get; set; }
        public virtual Competition Technique { get; set; }
    }
    
}
