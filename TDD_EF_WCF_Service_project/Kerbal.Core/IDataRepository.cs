using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Core
{
    public interface IDataRepository<T> where T : class, new()
    {
        T Add(T entity);
        void Remove(T entity);
        T Update(T entity);
        IEnumerable<T> Get();
    }
}
