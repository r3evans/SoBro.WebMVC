﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Models.Models
{
    public class CompetitionEdit
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public bool Ranked { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
