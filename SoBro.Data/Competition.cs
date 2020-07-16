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
   public class Competition
    {   
        [Key]
        public int CompetitionId { get; set; }
        public string Name { get; set; }

        public string City { get; set; }
        public bool Ranked { get; set; }
    }
}
