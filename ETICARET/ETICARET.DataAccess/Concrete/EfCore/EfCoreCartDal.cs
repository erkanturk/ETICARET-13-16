using ETICARET.DataAccess.Abstract;
using ETICARET.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETICARET.DataAccess.Concrete.EfCore
{
    public class EfCoreCartDal : EfCoreGenericRepository<Cart, DataContext>, ICartDal
    {
        public void ClearCart(string cartId)
        {
            using var context = new DataContext();
            context.Database.ExecuteSqlRaw(@"delete from CartItem where CartId=@p0",cartId);

        }

        public async Task ClearCartAsync(string cartId, CancellationToken ct = default)
        {
           await using var context = new DataContext();
           await context.Database.ExecuteSqlRawAsync(@"delete from CartItem where CartId=@p0",new object[] {cartId},ct);
        }

        public void DeleteFromCart(int cartId, int productId)
        {
            using var context = new DataContext();
            context.Database.ExecuteSqlRaw("delete from CartItem where CartId=@p0 and ProductId=@p1", cartId, productId);
        }

        public async Task DeleteFromCartAsync(int cartId, int productId, CancellationToken ct = default)
        {
            await using var context = new DataContext();
           await context.Database.ExecuteSqlRawAsync
                ("delete from CartItem where CartId=@p0 and ProductId=@p1", new object[] { cartId ,productId}, ct);
        }

        public Cart? GetCartByUserId(string userId)
        {
            using var context = new DataContext();
            return context.Carts
                .Include(i => i.CartItems)
                .ThenInclude(i => i.Product)
                .ThenInclude(i => i!.Images)
                .FirstOrDefault(i=>i.UserId==userId);
        }

        public async Task<Cart?> GetCartByUserIdAsync(string userId, CancellationToken ct = default)
        {
            await using var context = new DataContext();
            return await context.Carts
                .Include(i => i.CartItems)
                .ThenInclude(i => i.Product)
                .ThenInclude(i => i!.Images)
                .FirstOrDefaultAsync(i => i.UserId == userId, ct);
        }
        public override void Update(Cart entity)
        {
            using (var context = new DataContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }
        public  override async Task UpdateAsync(Cart entity, CancellationToken ct = default)
        {
           await using var context = new DataContext();
           context.Update(entity);
            await context.SaveChangesAsync(ct);
        
        }
    }
}
