using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallCrm
{
    class Order
    {
        public string OrderId { get; set; }

        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; set; }

        public List<Product> ProductList { set; get; }


        public Order()
        {
            ProductList = new List<Product>();

        }

        public decimal GetTotalAmmount(List<Product> products)
        {
            var total = 0.00M;
            foreach (var p in products) {
                total = total + p.Price;
            }
            return total;
        }

        public string PrintOrder()
        {
            return $" You order details: ID-->{OrderId}   TotalAmmount-->{TotalAmount}  ";
        }
    }
}

