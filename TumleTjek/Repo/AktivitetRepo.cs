using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumleTjek.Model;

namespace TumleTjek.Repo
{
    public class AktivitetRepo: IRepo<Aktivitet>

    {
        private List<Aktivitet> aktiviteter = new List<Aktivitet>();

        public void Add(Aktivitet item)
        {
            throw new NotImplementedException();
        }

        public List<Aktivitet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Aktivitet GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Aktivitet item)
        {
            throw new NotImplementedException();
        }

        public void Update(Aktivitet item)
        {
            throw new NotImplementedException();
        }
    }
}
 