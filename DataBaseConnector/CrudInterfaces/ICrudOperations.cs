using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace DataBaseConnector.CrudInterfaces
{
    interface ICrudOperations<T>
    {
        Task<bool> Create(T item);
        Task<bool> Delete(T item);
        Task<bool> Update(T item);
        Task<T> GetById<K>(K id);
        Task<IEnumerable<T>> GetAll();
    }
}
