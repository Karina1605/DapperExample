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
    class ProductInOrderRepository :ICrudOperationsFull<ProductInOrder>
    {
        private string _connectionString;

        public ProductInOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> Create(ProductInOrder item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    INSERT INTO ProductInOrders (OrderId, ProductId, Count)
                    VALUES ({0}, {1}, {2})", item.OrderId, item.ProductId, item.Count));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(ProductInOrder item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    DELETE FROM ProductInOrders
                    WHERE ProductId = {0} AND OrderId ={1}", item.ProductId, item.OrderId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductInOrder>> GetAll()
        {
            using (IDbConnection c = new SqlConnection(_connectionString))
            {
                return await c.QueryAsync<ProductInOrder>(@"
                    SELECT * FROM ProductInOrders;
                ");
            }
        }

        public Task<ProductInOrder> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ProductInOrder item)
        {
            throw new NotImplementedException();
        }
    }
}
