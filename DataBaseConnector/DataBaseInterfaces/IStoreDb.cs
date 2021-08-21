using DataBaseConnector.CrudInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DataBaseClasses.Tables;
using DataBaseClasses.Views;
namespace DataBaseConnector.DataBaseInterfaces
{
    interface IStoreDb
    {
        ICrudOperations<Client> Clients { get; }
        ICrudOperations<Order> Orders { get; }
        ICrudOperations<Discount> Discounts { get; }
        ICrudOperations<Product> Products { get; }
        ICrudOperations<ProductInOrder> ProductsInOrders { get; }
        ICrudOperations<ClientsAndOrders> ClientsAndOrders { get; }
    }
}
