﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Models.Models
{
   public class CompetitionListItem
    {
        public int CompetitionID { get; set; }
        public string Name { get; set; }
        
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
