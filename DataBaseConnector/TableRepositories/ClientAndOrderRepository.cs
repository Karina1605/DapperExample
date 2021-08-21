using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataBaseConnector.CrudInterfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataBaseConnector.TableRepositories
{
    class ClientAndOrderRepository : ICrudOperationsShort<ClientAndOrderRepository>
    {
        public string ConnectionString { get; set; }

        public async Task<IEnumerable<ClientAndOrderRepository>> GetAll()
        {
            using (IDbConnection c =new SqlConnection(ConnectionString))
            {
                return await c.QueryAsync<ClientAndOrderRepository>(@"
                    SELECT * FROM ClientsAndOrders;
                ");
            }
        }

        public async Task<ClientAndOrderRepository> GetById(int id)
        {
            using (IDbConnection c = new SqlConnection(ConnectionString))
            {
                return await c.QueryFirstOrDefaultAsync<ClientAndOrderRepository>($"SELECT * FROM ClientsAndOrders WHERE Id ={id};");
            }
        }
    }
}
