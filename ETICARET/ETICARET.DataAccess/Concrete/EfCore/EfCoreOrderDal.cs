
using ETICARET.DataAccess.Abstract;
using ETICARET.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETICARET.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderDal : EfCoreGenericRepository<Order, DataContext>, IOrderDal
    {
        public List<Order> GetOrders(string userId)
        {
            using var context = new DataContext();
            var orders = context.Orders
                .Include(i => i.OrderItems)
                .ThenInclude(i => i.Product)
                .ThenInclude(i => i!.Images)
                .AsQueryable();
            if (!string.IsNullOrEmpty(userId))
            {
                orders=orders.Where(i => i.UserId == userId);
            }
            return orders.ToList();
        }

        public async Task<List<Order>> GetOrdersAsync(string userId, CancellationToken ct = default)
        {
            await using var context = new DataContext();
            var orders = context.Orders
                .Include(i => i.OrderItems)
                .ThenInclude(i => i.Product).
                ThenInclude(i => i!.Images)
                .AsQueryable();
            if (!string.IsNullOrEmpty(userId))
            {
                orders = orders.Where(i => i.UserId == userId);
            }
            return await orders.ToListAsync(ct);
        }
    }
}
