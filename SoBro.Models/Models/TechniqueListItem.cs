using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Models.Models
{
    public enum BodyPart { shoulder, neck, knee, elbow, foot, wrist }
    public class TechniqueListItem
    {   
        public int TechniqueID { get; set; }
        public string Name { get; set; }
        public bool RequiresGi { get; set; }

        public BodyPart BodyArea { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
