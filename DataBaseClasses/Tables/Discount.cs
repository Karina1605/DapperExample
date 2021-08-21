using System;

namespace Simple.DataBaseModels
{
    public class Discount
    {
        public int Id { get; set; }
        public string DiscountName { get; set; }
        public int DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

    }
}
