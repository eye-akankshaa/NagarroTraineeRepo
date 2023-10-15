using Grocery_App_Data_Access_Layer.Entities;
using Grocery_App_Shared_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IRepository
{
    public interface IGroceryStoreRepository
    {
        string AddProduct(ProductEntity product);
        List<ProductEntity> GetAllProducts();
        Task<ProductEntity> FindProduct(int  productId);

        Task<bool> DeleteProduct(int productId);
        Task<bool> UpdateProduct(ProductEntity updatedProduct);
        Task<List<object>> GetCartItems(int registerId);
        Task<List<OrderDTO>> GetOrders(int registerId);
        Task<bool> PlaceOrder(OrderDTO orderObj);
        
        Task<bool> AddToCart(CartDTO cartObj);

        Task<bool> RemoveItemFromCart(int productId, int userId);



    }
}
