using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataBaseConnector.CrudInterfaces;
using DataBaseClasses.Views;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataBaseConnector.TableRepositories
{
    public class ClientAndOrderRepository : ICrudOperationsShort<ClientsAndOrders>
    {
        private string _connectionString;

        public ClientAndOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<ClientsAndOrders>> GetAll()
        {
            using (IDbConnection c =new SqlConnection(_connectionString))
            {
                return await c.QueryAsync<ClientsAndOrders>(@"
                    SELECT * FROM ClientsAndOrders;
                ");
            }
        }

        public async Task<ClientsAndOrders> GetById(int id)
        {
            using (IDbConnection c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<ClientsAndOrders>($"SELECT * FROM ClientsAndOrders WHERE Id ={id};");
            }
        }
    }
}
