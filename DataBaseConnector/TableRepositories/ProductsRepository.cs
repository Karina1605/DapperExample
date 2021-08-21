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
    class ProductsRepository :ICrudOperationsFull<Product>
    {
        public string ConnectionString { get; set; }

        public async Task<bool> Create(Product item)
        {
            try
            {
                IDbConnection c = new SqlConnection(ConnectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    INSERT INTO Orders (Name, Count, Cost)
                    VALUES ({0}, {1}, {2})", item.Name, item.Count, item.Cost));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Product item)
        {
            try
            {
                IDbConnection c = new SqlConnection(ConnectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    DELETE FROM Products
                    WHERE Id = {0}", item.Id));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using (IDbConnection c = new SqlConnection(ConnectionString))
            {
                return await c.QueryAsync<Product>(@"
                    SELECT * FROM Products;
                ");
            }
        }

        public async Task<Product> GetById(int id)
        {
            using (IDbConnection c = new SqlConnection(ConnectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Product>($"SELECT * FROM Products WHERE Id ={id};");
            }
        }

        public async Task<bool> Update(Product item)
        {
            try
            {
                IDbConnection c = new SqlConnection(ConnectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    INSERT INTO Products
                    SET Name = {0},
                        Counr = {1},
                        Cost ={2}
                    WHERE Id ={3}",
                        item.Name,
                        item.Count,
                        item.Cost,
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
