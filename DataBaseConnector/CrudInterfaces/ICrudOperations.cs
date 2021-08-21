using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace DataBaseConnector.CrudInterfaces
{
    interface ICrudOperationsShort<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        string ConnectionString { get; set; }
    }
}
