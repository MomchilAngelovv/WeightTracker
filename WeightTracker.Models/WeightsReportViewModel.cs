using System;
using System.Collections.Generic;
using System.Text;

namespace WeightTracker.Models
{
    public class WeightsReportViewModel
    {
        public string Name { get; set; }
        public string SecretWord { get; set; }
        public IEnumerable<WeightsReportWeight> Weights { get; set; }
    }
}
