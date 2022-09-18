using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T>  where T : class, IAggregateRoot
    {
        public Task<List<T>> GetAll();
        public T Get(int id);
    }
}
