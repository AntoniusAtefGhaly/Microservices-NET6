using Basket.API.Data.Interfaces;
using Basket.API.Entities;
using Basket.API.Repositories.Interface;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext _context;

        public BasketRepository(IBasketContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            var basket = _context.BasketCarts.Include(b => b.BasketCartItems).FirstOrDefault(b => b.UserName == userName);
            if (basket == null)
            {
                //var cart = new BasketCart(userName);
                //_context.BasketCarts.Add(cart);
                //_context.SaveChanges();
                //return _context.BasketCarts.Include(b => b.BasketCartItems).FirstOrDefault(b => b.UserName == userName); ;
            }
            return basket;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        public async Task<BasketCart> UpdateBasket(BasketCart basket)
        {
            try
            {
                _context.BasketCarts.Update(basket);
                _context.SaveChanges();
                var baskt = _context.BasketCarts.FirstOrDefault(b => b.UserName == basket.UserName);
                return await GetBasket(basket.UserName);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            var baskt = _context.BasketCarts.FirstOrDefault(b => b.UserName == userName);

            var items = _context.BasketCarts.Include(b => b.BasketCartItems).FirstOrDefault(b => b.UserName == userName).BasketCartItems;
            if (items != null)
                _context.BasketCartItems.RemoveRange(items);
            _context.SaveChanges();

            baskt = _context.BasketCarts.FirstOrDefault(b => b.UserName == userName);
            if (baskt == null)
                return false;
            _context.BasketCarts.Remove(baskt);
            _context.SaveChanges();

            return true;
        }

        public async Task<BasketCart> CreateBasket(BasketCart basket)
        {
            try
            {
                _context.BasketCarts.Add(basket);
                _context.SaveChanges();
                //                var baskt = _context.BasketCarts.First(b => b.UserName == basket.UserName);
                return await GetBasket(basket.UserName);
            }
            catch (Exception ex)
            {
                _context.BasketCarts.Update(basket);
                _context.SaveChanges();
                //                var baskt = _context.BasketCarts.First(b => b.UserName == basket.UserName);
                return await GetBasket(basket.UserName);
            }
        }
    }
}