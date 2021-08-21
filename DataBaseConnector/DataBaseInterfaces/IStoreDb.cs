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
        ICrudOperationsFull<Client> Clients { get; }
        ICrudOperationsFull<Order> Orders { get; }
        ICrudOperationsFull<Discount> Discounts { get; }
        ICrudOperationsFull<Product> Products { get; }
        ICrudOperationsFull<ProductInOrder> ProductsInOrders { get; }
        ICrudOperationsShort<ClientsAndOrders> ClientsAndOrders { get; }
    }
}
