using System;
using System.Collections.Generic;
using System.Text;

namespace SmallCrm
{
    class Customer : Person
    {
        public int IdCust { set; get; }

        public List<Order> OrderList { set; get; }

        public Customer(string lName) : base(lName)
        {
            OrderList = new List<Order>();
        }
    }
}

