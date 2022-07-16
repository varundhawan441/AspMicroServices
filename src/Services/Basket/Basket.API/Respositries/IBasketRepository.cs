using Basket.API.Entities;
using System.Threading.Tasks;

namespace Basket.API.Respositries
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string UserName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart);
        Task DeleteBasket(string UserName);
    }
}
