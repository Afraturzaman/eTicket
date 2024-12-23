using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public interface IOrderServices
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items,string userId,string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
        
    }
}
