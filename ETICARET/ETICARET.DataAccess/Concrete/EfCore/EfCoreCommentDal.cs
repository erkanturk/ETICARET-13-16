using ETICARET.DataAccess.Abstract;
using ETICARET.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ETICARET.DataAccess.Concrete.EfCore
{
    public class EfCoreCommentDal : EfCoreGenericRepository<Comment, DataContext>, ICommentDal
    {
        public async Task<List<Comment>> GetCommentsByProductIdAsync(int productId, CancellationToken ct = default)
        {
            await using var context = new DataContext();
            return await context.Comments
                .Where(c=>c.ProductId==productId)
                .OrderByDescending(c=>c.CreateOn)
                .ToListAsync(ct);
        }
    }
}
