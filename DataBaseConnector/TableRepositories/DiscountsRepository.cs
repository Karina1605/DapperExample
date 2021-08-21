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
    public class DiscountsRepository : ICrudOperationsFull<Discount>
    {
        private string _connectionString;

        public DiscountsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> Create(Discount item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    INSERT INTO Discounts (DiscountName, DiscountValue, StartDate, FinishDate, ClientId)
                    VALUES ({0}, {1}, {2}, {3}, {4})", item.DiscountName, item.DiscountValue, item.StartDate, item.FinishDate, item.ClientId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Discount item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    DELETE FROM Discounts
                    WHERE Id = {0}", item.Id));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Discount>> GetAll()
        {
            using (IDbConnection c = new SqlConnection(_connectionString))
            {
                return await c.QueryAsync<Discount>(@"
                    SELECT * FROM Discounts;
                ");
            }
        }

        public async Task<Discount> GetById(int id)
        {
            using (IDbConnection c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Discount>($"SELECT * FROM Discounts WHERE Id ={id};");
            }
        }

        public async Task<bool> Update(Discount item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    INSERT INTO Clients
                    SET DiscountName = {0},
                        DiscountValue = {1},
                        StartDate = {2},
                        FinishDate = {3},
                        ClientId ={4}
                    WHERE Id ={5}", 
                        item.DiscountName, 
                        item.DiscountValue, 
                        item.StartDate, 
                        item.FinishDate,
                        item.ClientId,
                        item.Id));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
