using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnector.CrudInterfaces
{
    interface ICrudOperationsFull<T> : ICrudOperationsShort<T>
    {
        Task<bool> Create(T item);
        Task<bool> Delete(T item);
        Task<bool> Update(T item);

    }
}
