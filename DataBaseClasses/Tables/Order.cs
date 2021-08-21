using System;

namespace Simple.DataBaseModels
{
    public class Order
    {
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
