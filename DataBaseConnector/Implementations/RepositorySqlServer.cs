using DataBaseClasses.Tables;
using DataBaseClasses.Views;
using DataBaseConnector.CrudInterfaces;
using DataBaseConnector.DataBaseInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseConnector.Implementations
{
    class RepositorySqlServer : IStoreDb
    {
        private static readonly string _connectionString ="Server=localhost\\SQLEXPRESS;Database=StoreDataBase;Trusted_Connection=True;";

        public ICrudOperationsFull<Client> Clients => throw new NotImplementedException();

        public ICrudOperationsFull<Order> Orders => throw new NotImplementedException();

        public ICrudOperationsFull<Discount> Discounts => throw new NotImplementedException();

        public ICrudOperationsFull<Product> Products => throw new NotImplementedException();

        public ICrudOperationsFull<ProductInOrder> ProductsInOrders => throw new NotImplementedException();

        public ICrudOperationsShort<ClientsAndOrders> ClientsAndOrders => throw new NotImplementedException();
    }
}
