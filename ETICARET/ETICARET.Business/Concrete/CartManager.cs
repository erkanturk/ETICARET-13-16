using ETICARET.Business.Abstract;
using ETICARET.DataAccess.Abstract;
using ETICARET.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETICARET.Business.Concrete
{
    public class CartManager(ICartDal cartDal) : ICartService
    {
        public void AddToCart(string userId, int productId, int quantity)
        {
           var cart =GetCartByUserId(userId);
            if (cart is not null)
            {
                var index = cart.CartItems.FindIndex(x => x.ProductId == productId);
                if (index < 0)
                {
                    cart.CartItems.Add(
                        new CartItem()
                        {
                            ProductId = productId,
                            Quantity = quantity,
                            CartId = cart.Id
                        });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }
            }
            cartDal.Update(cart);
        }

        public async Task AddToCartAsync(string userId, int productId, int quantity, CancellationToken ct = default)
        {
            var cart =await GetCartByUserIdAsync(userId);
            if (cart is not null)
            {
                var index = cart.CartItems.FindIndex(x => x.ProductId == productId);
                if (index < 0)
                {
                    cart.CartItems.Add(
                        new CartItem()
                        {
                            ProductId = productId,
                            Quantity = quantity,
                            CartId = cart.Id
                        });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }
            }
           await cartDal.UpdateAsync(cart,ct);
        }

        public void ClearCart(string cartId)=>cartDal.ClearCart(cartId);//Lambda expression ile hızlı fonksiyon tanımlama 
       

        public async Task ClearCartAsync(string cartId, CancellationToken ct = default)
        {
            await cartDal.ClearCartAsync(cartId, ct);
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                cartDal.DeleteFromCart(cart.Id, productId);
            }
        }

        public async Task DeleteFromCartAsync(string userId, int productId, CancellationToken ct = default)
        {
            var cart =await GetCartByUserIdAsync(userId);
            if (cart!=null)
            {
                await cartDal.DeleteFromCartAsync(cart.Id, productId, ct);
            }
        }

        public Cart? GetCartByUserId(string userId)=>cartDal.GetCartByUserId(userId);//DI 
        

        public async Task<Cart?> GetCartByUserIdAsync(string userId, CancellationToken ct = default)
        => await cartDal.GetCartByUserIdAsync(userId, ct);

        public void InitialCart(string userId)
        {
            cartDal.Create(new Cart { UserId = userId });
        }

        public async Task InitialCartAsync(string userId, CancellationToken ct = default)
        {
              await cartDal.CreateAsync(new Cart { UserId = userId },ct);
        }
    }
}
