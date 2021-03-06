﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Data
{
    public class Kerbal
    {
        public int KerbalId { get; set; }
        public string Name { get; set; }
        public bool OnMission { get; set; }
        
        public virtual Mission LastCompletedMission { get; set; }
    }
}
