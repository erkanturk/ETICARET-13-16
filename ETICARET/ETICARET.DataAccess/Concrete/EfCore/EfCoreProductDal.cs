using ETICARET.DataAccess.Abstract;
using ETICARET.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace ETICARET.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, DataContext>, IProductDal
    {
        public int GetCountByCategory(string category)
        {
            using var context = new DataContext();
            var products = context.Products.AsQueryable();//Linq sorgusuna hazır hale getir
            if (!string.IsNullOrWhiteSpace(category) && category != "all")
            {
                products = products
                    .Include(p => p.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a => a.Category!.Name.ToLower() == category.ToLower()));
                return products.Count();
            }
            else
            {
                Console.WriteLine(products);
                return products.Include(i => i.ProductCategories).ThenInclude(i => i.Category).Where(i => i.ProductCategories.Any()).Count();
            }
        }

        public async Task<int> GetCountByCategoryAsync(string category, CancellationToken ct = default)
        {
           await using var context = new DataContext();
            var products = context.Products.AsQueryable();//Linq sorgusuna hazır hale getir
            if (!string.IsNullOrWhiteSpace(category) && category != "all")
            {
                products = products
                    .Include(p => p.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a => a.Category!.Name.ToLower() == category.ToLower()));
                return products.Count();
            }
            else
            {
                Console.WriteLine(products);
                return await products.Include(i => i.ProductCategories).ThenInclude(i => i.Category).Where(i => i.ProductCategories.Any()).CountAsync(ct);
            }
        }

        public Product? GetProductDetails(int id)
        {
            using var context = new DataContext();
            return context.Products
                .Include(i => i.Images)
                .Include(i => i.ProductCategories)
                .ThenInclude(a => a.Category)
                .Include(i => i.Comments)
                .FirstOrDefault(i => i.Id == id);
        }

        public async Task<Product?> GetProductDetailsAsync(int id, CancellationToken ct = default)
        {
            await using var context = new DataContext();
            return await context.Products
                .Include (i => i.Images)
                .Include(i => i.ProductCategories)
                .ThenInclude(a => a.Category)
                .Include(i => i.Comments)
                .FirstOrDefaultAsync(i=>i.Id==id,ct);
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using var context = new DataContext();
            var products = context.Products.Include("Images").AsQueryable();
            if (!string.IsNullOrWhiteSpace(category) && category != "all")
            {
                products = products
                    .Include(p => p.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a => a.Category!.Name.ToLower() == category.ToLower()));
               
            }
            return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category, int page, int pageSize, CancellationToken ct = default)
        {
           await using var context = new DataContext();
            var products =  context.Products.Include("Images").AsQueryable();
            if (!string.IsNullOrWhiteSpace(category) && category != "all")
            {
                products = products
                    .Include(p => p.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a => a.Category!.Name.ToLower() == category.ToLower()));

            }
            return await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public override void Update(Product entity)
        {
            using var context = new DataContext();
            var product = context.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == entity.Id);
            if (product != null)
            {
                product.Name=entity.Name;
                product.Description=entity.Description;
                product.Price=entity.Price;
                context.Products.Add(product);
            }
        }
        public void Update(Product entity, int[] categoryIds)
        {
            using var context=new DataContext();
            var product = context.Products.Include(p => p.ProductCategories).FirstOrDefault(p => p.Id == entity.Id);
            if (product != null)
            {
                product.Name = entity.Name;
                product.Description=entity.Description;
                product.Price=entity.Price;
                product.ProductCategories = categoryIds.Select(id => new ProductCategory { ProductId = entity.Id, CategoryId = id }).ToList();
            }
        }
        //async delete getall ve bunların async si yazılacak.
        public Task UpdateAsync(Product entity, int[] categoryIds, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
