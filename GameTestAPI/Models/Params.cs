using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest.Models
{
   
    public class Params
    {
        public string ProfileName { get; set; }
        public Parameters parameters { get; set; }

    }
    public class Parameters
    {
        public string SwitchedOnColour { get; set; }
        public string SwitchedOffColour { get; set; }
        public int NumberOfLightsOn { get; set; }
        public int BoardSize { get;set; }
    }
}
