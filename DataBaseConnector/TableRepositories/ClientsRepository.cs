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
    public class ClientsRepository : ICrudOperationsFull<Client>
    {
        private string _connectionString;
        public ClientsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> Create(Client item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    INSERT INTO Clients (LastName, FirstName, Email, Password)
                    VALUES ('{0}', '{1}', '{2}', '{3}')", item.LastName, item.FirstName, item.Email, item.Password));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Client item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    DELETE FROM Clients
                    WHERE Id = {0}", item.Id));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            using (IDbConnection c = new SqlConnection(_connectionString))
            {
                var res =await c.QueryAsync<Client>(@"
                    SELECT * FROM Clients;
                ");
                return res;
            }
        }

        public async Task<Client> GetById(int id)
        {
            using (IDbConnection c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Client>($"SELECT * FROM Clients WHERE Id ={id};");
            }
        }

        public async Task<bool> Update(Client item)
        {
            try
            {
                IDbConnection c = new SqlConnection(_connectionString);
                await c.ExecuteScalarAsync(String.Format(@"
                    INSERT INTO Clients
                    SET LastName = '{0}',
                        FisrtName = '{1}',
                        Email = '{2}',
                        Password = '{3}',
                    WHERE Id ={4}", item.LastName, item.FirstName, item.Email, item.Id));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
