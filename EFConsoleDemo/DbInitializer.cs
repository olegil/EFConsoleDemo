using EFConsoleDemo.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleDemo
{
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

            //module set records
            ModuleCategory moduleCategory1 = new ModuleCategory { Name = ModuleCategoryName.Home, IsPublic = true };
            ModuleCategory moduleCategory2 = new ModuleCategory { Name = ModuleCategoryName.Home, IsPublic = false };
            ModuleCategory moduleCategory3 = new ModuleCategory { Name = ModuleCategoryName.Staff, IsPublic = false };

            Module cat1_module1 = new Module { Title = "Useful Links", ColumnIndex = 1, RowIndex = 1 };
            Module cat1_module2 = new Module { Title = "Canvas News", ColumnIndex = 1, RowIndex = 2};
            Module cat2_module1 = new Module { Title = "My Bookmarks", ColumnIndex = 2, RowIndex = 1 };
            Module cat2_module2 = new Module { Title = "University Policies", ColumnIndex = 2, RowIndex = 2};
            Module cat3_module1 = new Module { Title = "Human Resources Office (HRO)", ColumnIndex = 3, RowIndex = 2 };
            Module cat3_module2 = new Module { Title = "Computer Services Centre (CSC)", ColumnIndex = 3, RowIndex = 3};

            ModuleItem item1 = new ModuleItem { Title = "Canvas", Url = "https://canvas.cityu.edu.hk/login" };
            ModuleItem item2 = new ModuleItem { Title = "AIMS", Url = "https://banweb.cityu.edu.hk/" };
            ModuleItem item3 = new ModuleItem { Title = "News Centre", Url = "#" };
            ModuleItem item4 = new ModuleItem { Title = "City TV", Url = "#" };
            ModuleItem item5 = new ModuleItem { Title = "My link 1", Url = "#" };
            ModuleItem item6 = new ModuleItem { Title = "My link 2", Url = "#" };
            ModuleItem item7 = new ModuleItem { Title = "Popular link 1", Url = "#" };
            ModuleItem item8 = new ModuleItem { Title = "Services from HRO", Url = "#" };
            ModuleItem item9 = new ModuleItem { Title = "IT Services", Url = "#" };

            moduleCategory1.Modules.Add(cat1_module1);
            moduleCategory1.Modules.Add(cat1_module2);
            moduleCategory2.Modules.Add(cat2_module1);
            moduleCategory2.Modules.Add(cat2_module2);
            moduleCategory3.Modules.Add(cat3_module1);
            moduleCategory3.Modules.Add(cat3_module2);

            context.ModuleCategorys.Add(moduleCategory1);
            context.ModuleCategorys.Add(moduleCategory2);
            context.ModuleCategorys.Add(moduleCategory3);
            context.ModuleItems.Add(item1);
            context.ModuleItems.Add(item2);
            context.ModuleItems.Add(item3);
            context.ModuleItems.Add(item4);
            context.ModuleItems.Add(item5);
            context.ModuleItems.Add(item6);
            context.ModuleItems.Add(item7);
            context.ModuleItems.Add(item8);
            context.ModuleItems.Add(item9);

            context.SaveChanges();

            context.ModuleAndItemRelationships.Add(new ModuleAndItemRelationship { ModuleId = cat1_module1.ModuleId, ModuleItemId = item1.ModuleItemId, ItemIndex = 1 });
            context.ModuleAndItemRelationships.Add(new ModuleAndItemRelationship { ModuleId = cat1_module1.ModuleId, ModuleItemId = item2.ModuleItemId, ItemIndex = 2 });
            context.ModuleAndItemRelationships.Add(new ModuleAndItemRelationship { ModuleId = cat1_module2.ModuleId, ModuleItemId = item3.ModuleItemId, ItemIndex = 1 });
            context.ModuleAndItemRelationships.Add(new ModuleAndItemRelationship { ModuleId = cat1_module2.ModuleId, ModuleItemId = item4.ModuleItemId, ItemIndex = 2 });
            context.ModuleAndItemRelationships.Add(new ModuleAndItemRelationship { ModuleId = cat2_module1.ModuleId, ModuleItemId = item5.ModuleItemId, ItemIndex = 1 });
            context.ModuleAndItemRelationships.Add(new ModuleAndItemRelationship { ModuleId = cat2_module1.ModuleId, ModuleItemId = item6.ModuleItemId, ItemIndex = 2 });
            context.ModuleAndItemRelationships.Add(new ModuleAndItemRelationship { ModuleId = cat2_module2.ModuleId, ModuleItemId = item7.ModuleItemId, ItemIndex = 1 });
            context.ModuleAndItemRelationships.Add(new ModuleAndItemRelationship { ModuleId = cat3_module1.ModuleId, ModuleItemId = item8.ModuleItemId, ItemIndex = 1 });
            context.ModuleAndItemRelationships.Add(new ModuleAndItemRelationship { ModuleId = cat3_module2.ModuleId, ModuleItemId = item9.ModuleItemId, ItemIndex = 1 });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
