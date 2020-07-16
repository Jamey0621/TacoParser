using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    class Tacobell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
