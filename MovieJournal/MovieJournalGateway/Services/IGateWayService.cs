using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalGateway.Services
{
    public interface IGateWayService<T>
    {
        IEnumerable<T> ReadAll();

        T Get(int id);

        T Add(T t);

        T Delete(int id);

        T Edit(T t);
    }
}
