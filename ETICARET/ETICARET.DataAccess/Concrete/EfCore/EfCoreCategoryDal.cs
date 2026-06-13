using ETICARET.DataAccess.Abstract;
using ETICARET.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETICARET.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, DataContext>, ICategoryDal
    {
        public List<Category> GetAllWithProductCount()
        {
           using var context = new DataContext();
            return context.Categories.Include(c => c.ProductCategories).ToList();
        }

        public async Task<List<Category>> GetAllWithProductCountAsync(CancellationToken ct = default)
        {
           await using var context = new DataContext();
            return await context.Categories.Include(c => c.ProductCategories).ToListAsync(ct);
        }

        public Category? GetCategoryWithProduct(int categoryId)
        {
            using var context = new DataContext();
            return context.Categories
                .Where(i => i.Id == categoryId)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Product)
                .ThenInclude(i => i.Images).FirstOrDefault();
        }

        public async Task<Category?> GetCategoryWithProductAsync(int categoryId, CancellationToken ct = default)
        {
            await using var context = new DataContext();
            return await context.Categories
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Product)
                .ThenInclude(i => i.Images).FirstOrDefaultAsync(c=>c.Id==categoryId,ct);
        }
        public override void Delete(Category entity)
        {
            using var context = new DataContext();
            var category = context.Categories.Include(c => c.ProductCategories).FirstOrDefault(c => c.Id == entity.Id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
        public override async Task DeleteAsync(Category entity, CancellationToken ct = default)
        {
            await using var context = new DataContext();
            var category = await context.Categories.Include(c => c.ProductCategories).FirstOrDefaultAsync(c => c.Id == entity.Id, ct);
            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync(ct);
            }
        }
    }
}
