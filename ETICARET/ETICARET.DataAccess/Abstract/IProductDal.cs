using ETICARET.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETICARET.DataAccess.Abstract
{
    public interface IProductDal:IRepository<Product>
    {
        List<Product> GetProductsByCategory(string category, int page, int pageSiz);//Pagination
        Product? GetProductDetails(int id);
        int GetCountByCategory(string category);
        void Update(Product entity, int[] categoryIds);

        Task<List<Product>> GetProductsByCategoryAsync(string category, int page, int pageSize, CancellationToken ct = default);
        Task<Product?> GetProductDetailsAsync(int id, CancellationToken ct = default);
        Task<int> GetCountByCategoryAsync(string category, CancellationToken ct = default);
        Task UpdateAsync(Product entity, int[] categoryIds, CancellationToken ct = default);

    }
}
