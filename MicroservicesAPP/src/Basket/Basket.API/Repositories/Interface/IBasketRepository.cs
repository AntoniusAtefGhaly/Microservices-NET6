using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories.Interface
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasket(string userName);

        Task<BasketCart> UpdateBasket(BasketCart basket);

        Task<BasketCart> CreateBasket(BasketCart basket);

        Task<bool> DeleteBasket(string userName);
    }
}