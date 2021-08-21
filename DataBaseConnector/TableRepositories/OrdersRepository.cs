using System;
using System.Collections.Generic;
using System.Text;
using DataBaseConnector.CrudInterfaces;
using DataBaseClasses.Tables;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace DataBaseConnector.TableRepositories
{
    public class OrdersRepository :ICrudOperationsFull<Order>
    {
        private string _connectionString;

        public OrdersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> Create(Order item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    INSERT INTO Orders (ClientId, Orderdate)
                    VALUES ({0}, {1})", item.ClientId, item.OrderDate));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Order item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    DELETE FROM Orders
                    WHERE Id = {0}", item.Id));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            using (IDbConnection c = new SqlConnection(_connectionString))
            {
                return await c.QueryAsync<Order>(@"
                    SELECT * FROM Orders;
                ");
            }
        }

        public async Task<Order> GetById(int id)
        {
            using (IDbConnection c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Order>($"SELECT * FROM Orders WHERE Id ={id};");
            }
        }

        public async Task<bool> Update(Order item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    INSERT INTO Orders
                    SET ClientId = {0},
                        OrderDate = {1}
                    WHERE Id ={3}",
                        item.ClientId,
                        item.OrderDate,
                        item.Id
                        ));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
