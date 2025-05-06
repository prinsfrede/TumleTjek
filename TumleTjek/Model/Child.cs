using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumleTjek.Model
{
    public class Child
    {
        public int? ChildID { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }

        public string? Details { get; set; }

        public Parent? Parents { get; set; }

        public bool? IsMet { get; set; }
    }
}
