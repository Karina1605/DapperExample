using DataBaseClasses.Tables;
using DataBaseClasses.Views;
using DataBaseConnector.CrudInterfaces;
using DataBaseConnector.DataBaseInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DataBaseConnector.TableRepositories;

namespace DataBaseConnector.Implementations
{
    public class RepositorySqlServer : IStoreDb
    {
        private readonly string _connectionString;

        public RepositorySqlServer (string connectionString)
        {
            _connectionString = connectionString;
            Clients = new ClientsRepository(_connectionString);
            Orders = new OrdersRepository(_connectionString);
            Discounts = new DiscountsRepository(_connectionString);
            Products = new ProductsRepository(_connectionString);
            ProductsInOrders = new ProductInOrderRepository(_connectionString);
            ClientsAndOrders = new ClientAndOrderRepository(_connectionString);
        }

        public ICrudOperationsFull<Client> Clients { get; private set; }

        public ICrudOperationsFull<Order> Orders { get; private set; }

        public ICrudOperationsFull<Discount> Discounts { get; private set; }

        public ICrudOperationsFull<Product> Products { get; private set; }

        public ICrudOperationsFull<ProductInOrder> ProductsInOrders { get; private set; }

        public ICrudOperationsShort<ClientsAndOrders> ClientsAndOrders { get; private set; }
    }
}
