﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SussolAnalysisApp
{
    public class ClusterDistanceCenter
    {
        [Key]
        public long Id { get; set; }
        public long ToClusterId { get; set; }
        public double Distance { get; set; }
    }
}
