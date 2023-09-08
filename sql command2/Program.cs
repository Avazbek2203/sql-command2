using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQL_COMMAND
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL dal = new DAL();

            dal.CreateProduct("Pepsi", 250);
            dal.ReadAllProducts();
            Console.WriteLine();

            dal.UpdateProduct(1, "snikers", 500);
            dal.ReadAllProducts();
            Console.WriteLine();

            dal.DeleteProduct(2);
            dal.ReadAllProducts();
            Console.WriteLine();


            dal.CreateProductCategory("beverage");
            dal.ReadAllProducts();
            Console.WriteLine();

            dal.UpdateProductCategory("bread", 1);
            dal.ReadAllProducts();
            Console.WriteLine();


        }
    }
}
