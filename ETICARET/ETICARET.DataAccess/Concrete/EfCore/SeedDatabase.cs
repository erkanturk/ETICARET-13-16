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
            },
            new Product(){Name="Ütü Masası",Price=500,Images={
                    new Image(){ImageUrl="utu-masasi.jpg"},
                    new Image(){ImageUrl="utu-masasi-1.jpg"},
                    new Image(){ImageUrl="utu-masasi-2.jpg"},
                    new Image(){ImageUrl="utu-masasi-3.jpg"} },
                Description="<p>Cok iyi ütü masası"
            },
            new Product(){Name="Buzdolabı",Price=15000,Images={
                    new Image(){ImageUrl="buzdolabi.jpg"},
                    new Image(){ImageUrl="buzdolabi-1.jpg"},
                    new Image(){ImageUrl="buzdolabi-2.jpg"},
                    new Image(){ImageUrl="buzdolabi-3.jpg"} },
                Description="<p>Cok iyi buzdolabı"
            },
            new Product(){Name="Çamaşır Makinesi",Price=10000,Images={
                    new Image(){ImageUrl="camasir-makinesi.jpg"},
                    new Image(){ImageUrl="camasir-makinesi-1.jpg"},
                    new Image(){ImageUrl="camasir-makinesi-2.jpg"},
                    new Image(){ImageUrl="camasir-makinesi-3.jpg"} },
                Description="<p>Cok iyi çamaşır makinesi"
            },
            new Product(){Name="Bulaşık Makinesi",Price=8000,Images={
                    new Image(){ImageUrl="bulasik-makinesi.jpg"},
                    new Image(){ImageUrl="bulasik-makinesi-1.jpg"},
                    new Image(){ImageUrl="bulasik-makinesi-2.jpg"},
                    new Image(){ImageUrl="bulasik-makinesi-3.jpg"} },
                Description="<p>Cok iyi bulaşık makinesi"
            },
            new Product(){Name="Televizyon",Price=20000,Images={
                    new Image(){ImageUrl="televizyon.jpg"},
                    new Image(){ImageUrl="televizyon-1.jpg"},
                    new Image(){ImageUrl="televizyon-2.jpg"},
                    new Image(){ImageUrl="televizyon-3.jpg"} },
                Description="<p>Cok iyi televizyon"
          },
              new Product(){Name="IPhone 17 256",Price=80000,Images={
                    new Image(){ImageUrl="iphone17.jpg"},
                    new Image(){ImageUrl="iphone17-1.jpg"},
                    new Image(){ImageUrl="iphone17-2.jpg"},
                    new Image(){ImageUrl="iphone17-3.jpg"}},
                Description="<p>IPhone 17 256 gb Beyaz Telefon"
                },
            new Product(){Name="IPhone 14 128",Price=40000,Images={
                    new Image(){ImageUrl="iphone14.jpg"},
                    new Image(){ImageUrl="iphone14-1.jpg"},
                    new Image(){ImageUrl="iphone14-2.jpg"},
                    new Image(){ImageUrl="iphone14-3.jpg"}},
                Description="<p>IPhone 14 128 gb Blue Telefon"
                },
            new Product(){Name="PHILIPS EP5547/90 Tam Otomatik Espresso Makinesi Krom Siyah",Price=30000,Images={
                    new Image(){ImageUrl="PHILIPS.jpg"},
                    new Image(){ImageUrl="PHILIPS-1.jpg"},
                    new Image(){ImageUrl="PHILIPS-2.jpg"},
                    new Image(){ImageUrl="PHILIPS-3.jpg"}},
                Description="Tam Otomatik Espresso Makinesi"
                },
            new Product(){Name="DYSON V12 Detect Slim Absolute Kablosuz Şarjlı Dikey Süpürge Sarı Nikel",Price=40000,Images={
                    new Image(){ImageUrl="DYSON.jpg"},
                    new Image(){ImageUrl="DYSON-1.jpg"},
                    new Image(){ImageUrl="DYSON-2.jpg"},
                    new Image(){ImageUrl="DYSON-3.jpg"}},
                Description="Kablosuz Şarjlı Dikey Süpürge"
                },
            new Product(){Name="TEFAL SuperGrill 3in1 Tost Makinesi Inox",Price=6000,Images={
                    new Image(){ImageUrl="TEFAL.jpg"},
                    new Image(){ImageUrl="TEFAL-1.jpg"},
                    new Image(){ImageUrl="TEFAL-2.jpg"},
                    new Image(){ImageUrl="TEFAL-3.jpg"}},
                Description="Ekstra ızgara seçeneği"
                },
            new Product(){Name="ARZUM AR6000 Steampro Plus Buharlı Ütü Siyah",Price=3000,Images={
                    new Image(){ImageUrl="ARZUM.jpg"},
                    new Image(){ImageUrl="ARZUM-1.jpg"},
                    new Image(){ImageUrl="ARZUM-2.jpg"},
                    new Image(){ImageUrl="ARZUM-3.jpg"}},
                Description="Buharlı Ütü Siyah"
                },
            new Product(){Name="GRUNDIG KMP 4470 G Mutfak Şefi",Price=10000,Images={
                    new Image(){ImageUrl="GRUNDIG.jpg"},
                    new Image(){ImageUrl="GRUNDIG-1.jpg"},
                    new Image(){ImageUrl="GRUNDIG-2.jpg"},
                    new Image(){ImageUrl="GRUNDIG-3.jpg"}},
                Description="Hamur Yoğurma Aparatı, Balon Çırpıcı Aparat"
                },

        };
        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[1],Category=Categories[0]},
            new ProductCategory(){Product=Products[2],Category=Categories[1]},
            new ProductCategory(){Product=Products[3],Category=Categories[1]},
            new ProductCategory(){Product=Products[4],Category=Categories[1]},
            new ProductCategory(){Product=Products[5],Category=Categories[1]},
            new ProductCategory(){Product=Products[6],Category=Categories[1]},
            new ProductCategory(){Product=Products[7],Category=Categories[3]},
            new ProductCategory(){Product=Products[8],Category=Categories[3]},
            new ProductCategory(){Product=Products[9],Category=Categories[3]},
            new ProductCategory(){Product=Products[10],Category=Categories[3]},
            new ProductCategory(){Product=Products[11],Category=Categories[3]},
            new ProductCategory(){Product=Products[12],Category=Categories[0]},
            new ProductCategory(){Product=Products[13],Category=Categories[0]},
            new ProductCategory(){Product=Products[14],Category=Categories[2]},
            new ProductCategory(){Product=Products[15],Category=Categories[2]},
            new ProductCategory(){Product=Products[16],Category=Categories[2]},
            new ProductCategory(){Product=Products[17],Category=Categories[2]},
            new ProductCategory(){Product=Products[18],Category=Categories[2]},
        };


    }
}
