using System;

namespace DataBaseClasses.Tables
{
    public class Order
    {
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
