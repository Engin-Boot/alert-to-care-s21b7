﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class BedModel
    {
        public string BedId { get; set; }
        public string ICUId { get; set; }
        public string BedLayout { get; set; }
        public string BedStatus { get; set; }
    }
}
