using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumleTjek.Model;

namespace TumleTjek.ViewModel
{
    public class ChildViewModel
    {
        public ChildViewModel(Child child, string? name, int? age, string? details, Parent parents, bool? isMet)
        {
            Child = child;
            Name = name;
            Age = age;
            this.Parents = parents;
            IsMet = isMet;
            Details = details;
        }

        public Child Child { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }

        public string? Details { get; set; }

        public Parent Parents { get; set; }

        public bool? IsMet { get; set; }
    }
}
