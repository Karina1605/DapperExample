using System;
using System.Collections.Generic;


namespace DataBaseClasses.Tables
{
    public class Client
    {     
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        
        public virtual List<Discount> Discounts{ get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
