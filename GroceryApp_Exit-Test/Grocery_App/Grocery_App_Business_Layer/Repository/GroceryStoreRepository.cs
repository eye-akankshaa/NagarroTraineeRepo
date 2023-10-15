using Grocery_App_Data_Access_Layer.Data;
using Grocery_App_Data_Access_Layer.Entities;
using DataLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using Grocery_App_Shared_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class GroceryStoreRepository : IGroceryStoreRepository
    {
        public readonly Grocery_Context _context;
        public GroceryStoreRepository(Grocery_Context context)
        {
            _context = context;
        }
        public string AddProduct(ProductEntity product)
        {
            var result = _context.Products.Where(u => u.ProductName == product.ProductName).FirstOrDefault();
            if (result != null)
            {
                return ("Already Exist");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return ("Success");
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProductEntity> FindProduct(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public List<ProductEntity> GetAllProducts()
        {
            List<ProductEntity> products = _context.Products.ToList();
            return products;
        }

        //public async Task<ProductEntity> GetCartItems(int registerId)
        //{

        //    var cartItems = await _context.Carts.Where(x => x.RegisterId == registerId)
        //        .Include(c => c.Product)
        //        .Select(c => new
        //        {
        //            Product = c.Product,
        //            Quantity = c.Quantity
        //        })
        //        .ToListAsync();



        //    return cartItems;
        //}

        public async Task<ProductEntity> GetProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            //if (product == null)
            //{
            //    return NotFound(new { Message = "No such product exist in the database" });
            //}
            return product;
        }

        public async Task<bool> UpdateProduct(ProductEntity updatedProduct)
        {
            var product = await _context.Products.FindAsync(updatedProduct.ProductId);


            if (product == null)
                return false;

            product.ProductName = updatedProduct.ProductName;
            product.Description = updatedProduct.Description;
            product.Quantity = updatedProduct.Quantity;
            product.Price = updatedProduct.Price;
            product.Discount = updatedProduct.Discount;
            product.Specification = updatedProduct.Specification;
            product.Data = updatedProduct.Data;
            product.Category = updatedProduct.Category;



            await _context.SaveChangesAsync();



            return true;
        }
        internal bool ItemAlreadyInCart(int productId,int registerId)
        {
            var cartItem = _context.Carts.FirstOrDefault(x => x.ProductId == productId && x.RegisterId == registerId);
            if (cartItem == null)
                return false;
            else
                return true;
        }

        internal void ClearCart(int userId)
        {
            var itemsToBeDeleted = _context.Carts.Where(x => x.RegisterId == userId);



            foreach (var item in itemsToBeDeleted)
                _context.Carts.Remove(item);
            _context.SaveChanges();
        }

        internal void UpdateQuantity(int registerId)
        {
            var cartItems = _context.Carts.Where(x => x.RegisterId == registerId)
                .Include(c => c.Product)
                .Select(c => new
                {
                    Product = c.Product,
                    QuantityToBeReduced = c.Quantity
                })
                .ToList();



            foreach (var item in cartItems)
            {
                item.Product.Quantity -= item.QuantityToBeReduced;
                _context.Products.Update(item.Product);
            }



            _context.SaveChanges();
        }

        //public async Task<string> RemoveItemFromCart(int productId)
        //{
        //    var cartItem = await _context.Carts.FirstOrDefaultAsync(x => x.ProductId == productId);

        //    _context.Carts.Remove(cartItem);

        //    await _context.SaveChangesAsync();

        //    return  "Item removed from cart!";
        //}

        //public async Task<ProductEntity> GetOrders(int registerId)
        //{
        //    var orders = await _context.Orders.Where(x => x.RegisterId == registerId).ToListAsync();
        //    var orderList = new List<OrderDTO>();



        //    foreach (var order in orders)
        //    {
        //        var orderDto = new OrderDTO();
        //        orderDto.RegisterId = order.RegisterId;
        //        orderDto.OrderDate = order.OrderDate;
        //        orderDto.TotalPrice = order.TotalPrice;
        //        orderDto.QuantityOfItems = order.QuantityOfItems;

        //        orderList.Add(orderDto);
        //    }
        //    return orderList;
        //}

        public async Task<bool> PlaceOrder(OrderDTO orderObj)
        {
            var cartItemsToBeUpdated = _context.Carts.Where(x => x.RegisterId == orderObj.RegisterId);
            int index = 0;



            foreach (var item in cartItemsToBeUpdated)
            {
                item.Quantity = orderObj.UpdatedQuantities[index];
                _context.Carts.Update(item);
                index++;
            }
            _context.SaveChanges();

            try
            {
                OrderEntity order = new OrderEntity
                {
                    RegisterId = orderObj.RegisterId,
                    TotalPrice = (int) orderObj.TotalPrice,

                    QuantityOfItems = orderObj.QuantityOfItems,
                    OrderDate = DateTime.Now,
                    Register = null
                };
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                UpdateQuantity(orderObj.RegisterId);
                ClearCart(orderObj.RegisterId);
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        public async Task<bool> AddToCart(CartDTO cartObj)
        {
            if (ItemAlreadyInCart(cartObj.ProductId , cartObj.RegisterId) == false)
            {
                try
                {

                    CartEntity cart = new CartEntity
                    {
                        ProductId = cartObj.ProductId,
                        RegisterId = cartObj.RegisterId,
                        Quantity = cartObj.Quantity,
                        Product = null,
                        Register = null
                    };




                    await _context.Carts.AddAsync(cart);

                    await _context.SaveChangesAsync();

                }
                catch (Exception ex)
                {

                }

                return true;
            }
            else
                return false;
        }


        public async Task<List<OrderDTO>> GetOrders(int registerId)
        {
            var orders = await _context.Orders.Where(x => x.RegisterId == registerId).ToListAsync();
            var orderList = new List<OrderDTO>();

            foreach (var order in orders)
            {
                var orderDto = new OrderDTO();
                orderDto.RegisterId = order.RegisterId;
                orderDto.OrderDate = order.OrderDate;
                orderDto.TotalPrice = order.TotalPrice;
                orderDto.QuantityOfItems = order.QuantityOfItems;

                orderList.Add(orderDto);
            }

            return orderList;
        }

        async Task<List<object>>  IGroceryStoreRepository.GetCartItems(int registerId)
        {
            var cartItems = await _context.Carts.Where(x => x.RegisterId == registerId)
         .Include(c => c.Product)
         .Select(c => new
         {
             Product = c.Product,
             Quantity = c.Quantity
         })
         .ToListAsync();

            return cartItems.Cast<object>().ToList();
        }

        

        public async Task<bool> RemoveItemFromCart(int productId, int userId)
        {
            var cartItem = await _context.Carts.FirstOrDefaultAsync(x => x.ProductId == productId && x.RegisterId == userId);



            _context.Carts.Remove(cartItem);



            await _context.SaveChangesAsync();



            return true;
        }

        
    }
}
