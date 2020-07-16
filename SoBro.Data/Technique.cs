using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Data
{

    public class Technique

    {
        [Key]
        public int TechniqueId { get; set; }
        
        [Required]
        public bool RequiresGi { get; set; }
       
        public string Name { get; set; }

        [Range(1, 5, ErrorMessage = "Enter a difficulty between 1-5.")]
        public int Difficulty { get; set; }

        public string Description { get; set; }

        
    }
}
