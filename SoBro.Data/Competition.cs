using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Data
{
   public class Competition
    {   
        [Key]
        public int CompetitionID { get; set; }
        public enum Organization { IBJJF, Fuji, Local }
        public string Name { get; set; }
        public string City { get; set; }
        public bool Ranked { get; set; }
   
    }
}
