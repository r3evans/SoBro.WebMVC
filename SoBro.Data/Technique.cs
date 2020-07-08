using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Data
{

    public class Technique

    {
        [Key]
        public int TechniqueID { get; set; }
        public enum Type { choke, joint_lock, sweep, guard, }
        public Type TechniqueType { get; set; }
        [Required]
        public bool RequiresGi { get; set; }
        public enum BodyPart { shoulder, neck, knee, elbow, foot, wrist }
        public BodyPart BodyArea {get; set;}
        public string Name { get; set; }

        [Range(1, 5, ErrorMessage = "Enter a difficulty between 1-5.")]
        public int Difficulty { get; set; }
    }
}
