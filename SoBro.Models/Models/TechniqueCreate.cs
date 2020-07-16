using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Models.Models
{
   public class TechniqueCreate
    {
        [Key]
        public int TechniqueId { get; set; }
        
        public string Description { get; set; }
        
        public bool RequiresGi { get; set; }
        
        public string Name { get; set; }

        [Range(1, 5, ErrorMessage = "Enter a difficulty between 1-5.")]
        public int Difficulty { get; set; }
    }  
}
