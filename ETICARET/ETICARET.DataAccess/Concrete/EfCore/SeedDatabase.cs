using ETICARET.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETICARET.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new DataContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.AddRange(Categories);
                }
                if (context.Products.Count() == 0)
                {
                    context.AddRange(Products);
                    context.AddRange(ProductCategories);
                }
                context.SaveChanges();
            }

        }
        private static Category[] Categories =
        {
            new Category(){Name="Telefon"},//0
            new Category(){Name="Bilgisayar"},//1
            new Category(){Name="Elektronik"},//2
            new Category(){Name="Ev Gereçleri"}//3
        };
        private static Product[] Products =
        {
            new Product(){Name="IPhone 15 128",Price=50000,Images={
                    new Image(){ImageUrl="iphone 15.jpg"},
                    new Image(){ImageUrl="iphone 15-1.jpg"},
                    new Image(){ImageUrl="iphone 15-2.jpg"},
                    new Image(){ImageUrl="iphone 15-3.jpg"}},
                Description="<p>IPhone 15 128 gb Telefon"
                },
            new Product(){Name="IPhone 16 256",Price=60000,Images={
                    new Image(){ImageUrl="iphone16.jpg"},
                    new Image(){ImageUrl="iphone16-1.jpg"},
                    new Image(){ImageUrl="iphone16-2.jpg"},
                    new Image(){ImageUrl="iphone16-3.jpg"}},
                Description="<p>IPhone 16 256 gb Lacivertaş Telefon"
                },

        };
        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
        };


    }
}
