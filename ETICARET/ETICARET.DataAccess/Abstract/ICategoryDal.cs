using ETICARET.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETICARET.DataAccess.Abstract
{
    public interface ICategoryDal:IRepository<Category>
    {

        Category? GetCategoryWithProduct(int categoryId);
        List<Category> GetAllWithProductCount();
        Task<Category?> GetCategoryWithProductAsync(int categoryId, CancellationToken ct = default);
        Task<List<Category>> GetAllWithProductCountAsync(CancellationToken ct = default);
    }
}
