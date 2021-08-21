using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseClasses.Views
{
    class ClientsAndOrders
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
