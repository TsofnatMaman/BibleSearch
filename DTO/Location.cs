using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Location
    {
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Verse { get; set; }
        public int Index { get; set; }
        public override string ToString()
        {
            return "["+Book + " " + Chapter + ", " + Verse+"]";
        }
    }
}
