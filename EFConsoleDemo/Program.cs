using System;
using System.Collections.Generic;
using System.Data.Entity;
namespace EFConsoleDemo {
    class Program {
        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());

            MyContext context = new MyContext();
            Database.SetInitializer(new DbInitializer());
            context.Database.Log = Console.Write; //generated sql is output to console

            Product product = new Product { Name = "product 1" };
            context.Products.Add(product);
            context.SaveChanges();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    public class MyContext : DbContext {
        public MyContext() : base("EFConsoleDemoDB") { }
        public DbSet<Product> Products { get; set; } 
    }

    public class DbInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            var products = new List<Product>
            {
                new Product{Name="p1", Description="desc1"},
                new Product{Name="p2", Description="desc2"}
            };
            products.ForEach(s => context.Products.Add(s));
            //context.SaveChanges(); //no need this line
            base.Seed(context);
        }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    } 
}
