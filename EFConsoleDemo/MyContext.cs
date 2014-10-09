using EFConsoleDemo.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleDemo
{
    public class MyContext : DbContext
    {
        public MyContext() : base("EFConsoleDemoDB") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleCategory> ModuleCategorys { get; set; }
        public DbSet<ModuleItem> ModuleItems { get; set; }
        public DbSet<ModuleAndItemRelationship> ModuleAndItemRelationships { get; set; }
    }
}
