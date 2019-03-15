using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResistanceCalculator.ViewModels
{
    public class CalculatorViewModel
    {
        public string FirstBandSelectedValue { get; set; }
        public string SecondBandSelectedValue { get; set; }
        public string MultiplierSelectedValue { get; set; }
        public string ToleranceSelectedValue { get; set; }
        public int OhmsValue { get; set;}
        public Dictionary<string,int> BandValues { get; set; }
        public Dictionary<string, double> MultiplierValues { get; set; }
        public Dictionary<string,double> ToleranceValues { get; set; }
    }
}
