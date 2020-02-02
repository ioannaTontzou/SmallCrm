using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = System.IO.File.ReadAllLines(@"products.csv");
            var  random = new Random();

            IEnumerable<Product> queryProduct =
            from productLine in products
            let splitProd = productLine.Split(';')
            select new Product()
            {
                ProductId = splitProd[0],
                Description = splitProd[1],
                Price = RandomDec(random) 
            };

            List<Product> prod = queryProduct.ToList();


            var productList1 = new List<Product>
            {
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)]
            };

            var ord1 = new Order()
            {
                OrderId = "ORD1",
                DeliveryAddress = "Egnatias 5, Thessaloniki tk 22222",
                ProductList = productList1,
                TotalAmount = GetTotalAmmount(productList1)
            };

            var productList2 = new List<Product>
            {
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)],
                prod[random.Next(prod.Count)]
            };

            var ord2 = new Order()
            {
                OrderId = "ORD2",
                DeliveryAddress = "Eptapirgiou 7, Thessaloniki tk 55555",
                ProductList = productList2,
                TotalAmount = GetTotalAmmount(productList2)
            };

            var custom1 = new Customer("Gkouras")
            {
                Age = 23,
                IdCust = 55,
                FirstName = "Ioannis",
                OrderList = new List<Order>
                {
                    ord1
                }

            };

            var custom2 = new Customer("Tontzos")
            {
                Age = 51,
                IdCust = 66,
                FirstName = "Konstantinos",
                OrderList = new List<Order>
                {
                    ord2
                }
            };

            Console.WriteLine($"Customer: {custom1.PrintFullName()}   ID: {custom1.IdCust}");
            foreach (var o in custom1.OrderList) {
                Console.WriteLine(o.PrintOrder());
            }
            foreach (var p in ord1.ProductList) {
                Console.WriteLine(p.PrintProduct());
            }
            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ");

            Console.WriteLine($"Customer: {custom2.PrintFullName()}   ID: {custom2.IdCust}");
            foreach (var o in custom2.OrderList) {
                Console.WriteLine(o.PrintOrder());
            }
            foreach (var p in ord2.ProductList) {
                Console.WriteLine(p.PrintProduct());
            }


            if( TopCustomer(custom1.OrderList) > TopCustomer(custom2.OrderList)) {
                Console.WriteLine($"TOP CUSTOMER: {custom1.PrintFullName()} TotalAmmount {ord1.TotalAmount} ");
            } else {
                Console.WriteLine($"TOP CUSTOMER: {custom2.PrintFullName()} TotalAmmount {ord2.TotalAmount}");
            }

            var soldProducts = new List<Product>();
             soldProducts = productList1.Concat(productList2).ToList();

            /*var topSaleProds = (from p in soldProducts
                                group p by p.ProductId into pg
                                orderby pg.Count() descending
                                select pg.Key).ToList(); */

            var topSaleProds = (soldProducts
                                .GroupBy(p => p.ProductId)
                                .OrderByDescending(grp => grp.Count())
                                .Take(10))
                                .ToList();
            
                              
             
            for(var i =0; i <topSaleProds.Count; i++) {
                Console.WriteLine($"TOP SALE PRODUCT: {topSaleProds[i].Key}");
            }
       

        }

        
        static decimal RandomDec(Random rm)
        {
            var randomPrice = (double) rm.Next(1, 100) +
                Math.Round(rm.NextDouble(), 2);
            return Convert.ToDecimal(randomPrice);       
        }
         
        static bool IsUniqueId(List<Product> prlist,string id)
        {
           foreach(var o in prlist) { 
                prlist.Where(o => o.ProductId.Equals(id))
                 .SingleOrDefault();
                return true;
            }
            return false;
            }
        static decimal GetTotalAmmount(List<Product> products)
        {
            var total = 0.00M;
            foreach (var p in products) {
                total = total + p.Price;
            }
            return total;
        }

        static decimal TopCustomer(List<Order> orderList)
        {
            var total = 0.00M;
            foreach (var o in orderList) {
                total = total + o.TotalAmount;
            }
            return total;
        }

    }
}
