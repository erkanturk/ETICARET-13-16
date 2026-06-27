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
            new Product(){Name="MSI MEG VISION X Gaming PC",Price=409684,Images={
                    new Image(){ImageUrl="msi-meg-vision.jpg"},
                    new Image(){ImageUrl="msi-meg-vision-1.jpg"},
                    new Image(){ImageUrl="msi-meg-vision-2.jpg"},
                    new Image(){ImageUrl="msi-meg-vision-3.jpg"} },
                Description="<p>İşletim Sistemi: Windows 11 Home\r\nİşlemci: Intel Core Ultra 9 processor 285K\r\nDepolama Alanı: 2TB SSD\r\nSistem Belleği: 64GB DDR5\r\nEkran Kartı: GeForce RTX 5090 32G VENTUS 3X\r\nRenk: Siyah"
            },
            new Product(){Name="MSI MPG INFINITE Z3 Gaming PC",Price=145473,Images={
                    new Image(){ImageUrl="msi-mpg-infinite.jpg"},
                    new Image(){ImageUrl="msi-mpg-infinite-2.jpg"},
                    new Image(){ImageUrl="msi-mpg-infinite-3.jpg"},
                    new Image(){ImageUrl="msi-mpg-infinite-4.jpg"} },
                Description="<p>İşletim Sistemi: Windows 11 Home\r\nİşlemci: AMD Ryzen 7 9700X\r\nDepolama Alanı: 1TB*1 SSD\r\nSistem Belleği: 32GB DDR5\r\nEkran Kartı: GeForce RTX 5070 12G SHADOW 2X\r\nRenk: Siyah"
            },
            new Product(){Name="MSI MAG INFINITE S3 Gaming PC",Price=122235,Images={
                    new Image(){ImageUrl="msi-mag-infinite.jpg"},
                    new Image(){ImageUrl="msi-mag-infinite-1.jpg"},
                    new Image(){ImageUrl="msi-mag-infinite-2.jpg"},
                    new Image(){ImageUrl="msi-mag-infinite-3.jpg"} },
                Description="<p>İşletim Sistemi: Windows 11 Home\r\nİşlemci: Intel Core i7-14700F\r\nDepolama Alanı:  1TB SSD\r\nSistem Belleği: 32GB DDR5\r\nEkran Kartı: GeForce RTX 5070 SHADOW 2X 12G\r\nRenk: Siyah"
            },
            new Product(){Name="MSI MPG INFINITE X3 Masaüstü Gaming PC",Price=180270,Images={
                    new Image(){ImageUrl="msi-mpg-x3.jpg"},
                    new Image(){ImageUrl="msi-mpg-x3-1.jpg"},
                    new Image(){ImageUrl="msi-mpg-x3-2.jpg"},
                    new Image(){ImageUrl="msi-mpg-x3-3.jpg"} },
                Description="<p>İşletim Sistemi: Windows 11\r\nİşlemci: Intel ULTRA 7 265K\r\nDepolama Alanı: 1000GB SSD\r\nSistem Belleği: 32GB DDR5\r\nEkran Kartı: GeForce RTX 5070 Ti VENTUS 3X 16G\r\nRenk: Siyah"
            },
            new Product(){Name="MSI MPG TRIDENT AS  Gaming PC",Price=115000,Images={
                    new Image(){ImageUrl="msi-mpg-trident.jpg"},
                    new Image(){ImageUrl="msi-mpg-trident-1.jpg"},
                    new Image(){ImageUrl="msi-mpg-trident-2.jpg"},
                    new Image(){ImageUrl="msi-mpg-trident-3.jpg"} },
                Description="<p>İşletim Sistemi: Windows 11 Home\r\nİşlemci: Intel Core Ultra 7 processor 265F\r\nDepolama Alanı: 1TB*1 SSD\r\nSistem Belleği: 32GB DDR5\r\nEkran Kartı: GeForce RTX 5060 Ti 8G SHADOW 2X PLUS\r\nRenk: Siyah"
            }
        };
        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[2],Category=Categories[1]},
            new ProductCategory(){Product=Products[3],Category=Categories[1]},
            new ProductCategory(){Product=Products[4],Category=Categories[1]},
            new ProductCategory(){Product=Products[5],Category=Categories[1]},
            new ProductCategory(){Product=Products[6],Category=Categories[1]}
        };


    }
}
