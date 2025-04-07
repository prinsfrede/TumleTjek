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
        public ChildViewModel(Barn child, string name, int age, Forældre forældre, bool isSick)
        {
            Child = child;
            Name = name;
            Age = age;
            this.forældre = forældre;
            IsSick = isSick;
        }


        public Barn Child { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Forældre forældre { get; set; }

        public bool IsSick { get; set; }
    }
}
