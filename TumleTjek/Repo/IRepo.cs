using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumleTjek.Repo
{
    public interface IRepo<T> where T : class
    {

        void Add(T item);
        void Remove(T item);
        void Update(T item);
        T GetById(int id);
        List<T> GetAll();
    }
}
