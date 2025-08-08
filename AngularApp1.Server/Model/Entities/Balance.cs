﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApp1.Server.Model.Entities
{
    public class Balance
    {
        public int Id { get; set; }
        public double Count { get; set; }
        public int ResourceId { get; set; }
        public Resource? Resource { get; set; }
        public int MeasureId { get; set; }
        public Measure? Measure { get; set; }
    }
}
