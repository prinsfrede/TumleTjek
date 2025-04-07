using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumleTjek.Model
{
    public class Barn
    {
        public int BarnID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Forældre forældre { get; set; }

        public bool IsSick { get; set; }
    }
}
