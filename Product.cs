using System;
using System.Collections.Generic;
using System.Text;

namespace SmallCrm
{
    class Product
    {
        public decimal Price { set; get; }

        public string ProductId { set; get; }

        public string Description { set; get; }



        public Product()
        {

        }

        public string PrintProduct()
        {
            return @$" Product you Order: Price--> {Price} |  ProductID--> {ProductId} | Description--> {Description}";
        }

    }
}

