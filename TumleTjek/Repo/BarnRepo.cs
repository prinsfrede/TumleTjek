using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumleTjek.Model;

namespace TumleTjek.Repo
{
    public class BarnRepo : IRepo<Barn>
    {
        private List<Barn> barns = new List<Barn>();
        public void Add(Barn item)
        {
            barns.Add(item);
        }

        public void Remove(Barn item)
        {
            barns.Remove(item);
        }

        public void Update(Barn item)
        {
            var index = barns.FindIndex(b => b.Name == item.Name);
            if (index != -1)
            {
                barns[index] = item;
            }
        }

        public Barn GetById(int id)
        {
            return barns.FirstOrDefault(b => b.Age == id);
        }

        public IEnumerable<Barn> GetAll()
        {
            return barns;
        }
    }

        


    
}
