﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace EFConsoleDemo {
    class Program {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());

            MyContext context = new MyContext();
            context.Database.Log = Console.Write; //generated sql is output to console

            //add record
            Product product = new Product { Name = "product 1" };
            context.Products.Add(product);
            context.SaveChanges();

            //test IQueryable and IEnumeric difference when query
            testIQueryableAndIEnumbericDifferenceWhenQuery(context);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void testIQueryableAndIEnumbericDifferenceWhenQuery(MyContext context)
        {
            /*
             * Here are 4 EF query examples with 3 different sources:
             *  IEnumerable
             *  IQueryable
             *  var
             *  
             * different source generate different sql statement for the same scripts.
             * 
             * EF and Linq use lazy query, in these 2 examples,
             * query is not executed until call ToList() method
             * 
             * in these examples, "context.Products" is defined as DbSet<Product>,
             * it can convert to IQueryable or IEnumerable.
             * If no explicit cast "context.Products" type, by default is IQueryable
             */

            /*
             * Use IEnumerable to query
             * generated sql like:
             * select * from product
             * 
             * Note: "Where" method is not converted to sql statement
             */
            IEnumerable<Product> query1 = context.Products;
            var query1Result = query1.Where(p => p.Name == "product 1");             
            Console.WriteLine(query1Result.ToList().Count);

            /*
             * Use IQueryable to query
             * generated sql like:
             * select * from product where name = 'product 1'
             * 
             * Note: "Where" method is converted to sql statement
             */
            IQueryable<Product> query2 = context.Products;
            var query2Result = query2.Where(p => p.Name == "product 1");
            Console.WriteLine(query2Result.ToList().Count);

            /*
             * Use var to query. If use "var", it is considered as IQueryable.
             * generated sql like:
             * select * from product where name = 'product 1'
             * 
             * Note: "Where" method is converted to sql statement
             */
            var query3 = context.Products;
            var query3Result = query3.Where(p => p.Name == "product 1");
            Console.WriteLine(query3Result.ToList().Count);

            /*
             * Convert to IEnumerable after where method is called
             * generated sql like:
             * select * from product where name = 'product 1'
             * 
             * Note: "Where" method is converted to sql statement because cast to IEnumerable after where method is called
             */
            IEnumerable<Product> query4Result = 
                context.Products.Where(p => p.Name == "product 1");
            Console.WriteLine(query4Result.ToList().Count);
        
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
