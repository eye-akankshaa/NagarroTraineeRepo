using BusinessLogicLayer.Respositories;
using Grocery_App_Data_Access_Layer.Data;
using Grocery_App_Data_Access_Layer.Entities;
using Grocery_App_Shared_Library.Models;
using DataLayer.IRepository;
using DataLayer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grocery_App_Presentation_Layer.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    // public class GroceryStoreController : ControllerBase
    // {

    //     private readonly IConfiguration _configuration;
    //     public readonly Grocery_Context _context;

    //     public GroceryStoreController(IConfiguration configuration, Grocery_Context context)
    //     {
    //         _configuration = configuration;
    //         _context = context;
    //     }




    //     [HttpGet("GetProducts")]

    //     public IActionResult GetProducts() { 
    //      List<ProductEntity> products = _context.Products.ToList();
    //         return Ok(products);
    //     }


    //     [HttpPost("AddProduct")]

    //     public IActionResult AddProduct([FromBody]ProductEntity product)
    //     {
    //         if (_context.Products.Where(u => u.ProductName == product.ProductName).FirstOrDefault() != null)
    //         {
    //             return Ok("Already Exist");
    //         }
    //         _context.Products.Add(product);
    //         _context.SaveChanges();
    //         return Ok("Success");
    //     }


    //     //Front end se ID aayegi

    //     [HttpGet("FindProduct/{productId}")]
    //     public async Task<IActionResult> FindProduct(int productId)
    //     {
    //         var product = await _context.Products.FindAsync(productId);
    //         if (product == null)
    //         {
    //             return NotFound(new { Message = "No such product exist in the database" });
    //         }
    //         return Ok(product);
    //     }


    //     [HttpDelete("DeleteProduct/{productId}")]
    //     public async Task<IActionResult> DeleteProduct(int productId)
    //     {
    //         var product = await _context.Products.FindAsync(productId);
    //         if (product == null)
    //             return NotFound();
    //         _context.Products.Remove(product);
    //         await _context.SaveChangesAsync();
    //         return Ok(new { Message = "Product Deleted!" });
    //     }

    //     [HttpPut("UpdateProduct")]
    //     public async Task<IActionResult> UpdateProduct([FromBody] ProductEntity updatedProduct)
    //     {
    //         var product = await _context.Products.FindAsync(updatedProduct.ProductId);



    //         if (product == null)
    //             return NotFound(new { Message = "No such product exists in the database" });



    //         product.ProductName = updatedProduct.ProductName;
    //         product.Description = updatedProduct.Description;
    //         product.Quantity = updatedProduct.Quantity;
    //         product.Price = updatedProduct.Price;
    //         product.Discount = updatedProduct.Discount;
    //         product.Specification = updatedProduct.Specification;
    //         product.Data = updatedProduct.Data;
    //         product.Category = updatedProduct.Category;



    //         await _context.SaveChangesAsync();



    //         return Ok(new { Message = "Product updated successfully" });
    //     }


    //     [HttpPost("AddToCart")]

    //     public async Task<IActionResult> AddToCart([FromBody] CartDTO cartObj)

    //     {

    //         if (cartObj == null)

    //             return BadRequest();
    //         try
    //         {

    //             CartEntity cart = new CartEntity
    //             {
    //                 ProductId = cartObj.ProductId,
    //                 RegisterId = cartObj.RegisterId,
    //                 Quantity = cartObj.Quantity,
    //                 Product = null,
    //                 Register = null
    //             };




    //             await _context.Carts.AddAsync(cart);

    //             await _context.SaveChangesAsync();

    //         }
    //         catch (Exception ex)
    //         {

    //         }

    //         return Ok(new { Message = "Product Added to the cart!" });

    //     }

    //     [HttpGet("GetCartItems")]
    //     public async Task<IActionResult> GetCartItems(int registerId)
    //     {
    //         var cartItems = await _context.Carts.Where(x => x.RegisterId == registerId)
    //             .Include(c => c.Product)
    //             .Select(c => new
    //             {
    //                 cartId = c.CartId,
    //                 productId = c.Product.ProductId,
    //                 ProductName = c.Product.ProductName,
    //                 Price = c.Product.Price,
    //                 Data = c.Product.Data,
    //                 Quantity = c.Quantity,
    //                 Discount = c.Product.Discount,
    //                 RegisterId = c.RegisterId
    //             })
    //             .ToListAsync();



    //         return Ok(cartItems);
    //     }




    //     [HttpDelete("RemoveItemFromCart/{productId}")]
    //     public async Task<IActionResult> RemoveItemFromCart(int productId)
    //     {
    //         var cartItem = await _context.Carts.FirstOrDefaultAsync(x => x.ProductId == productId);


    //         _context.Carts.Remove(cartItem);


    //          await _context.SaveChangesAsync();

    //          return Ok(new { Message = "Item removed from cart!" });
    //     }





















    //     [HttpPost("AddReview")]

    //     public async Task<IActionResult> AddReview([FromBody] ReviewDTO reviewObj)

    //     {

    //         if (reviewObj == null)

    //             return BadRequest();
    //         try
    //         {

    //             ReviewEntity review = new ReviewEntity
    //             {
    //                 ProductId = reviewObj.ProductId,
    //                 RegisterId = reviewObj.RegisterId,
    //                 Comment = reviewObj.Comment,

    //                 Product = null,
    //                 Register = null
    //             };




    //             await _context.Reviews.AddAsync(review);

    //             await _context.SaveChangesAsync();

    //         }
    //         catch (Exception ex)
    //         {

    //         }

    //         return Ok(new { Message = "Successfully addded reviews" });

    //     }




    //}




































    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class GroceryStoreController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGroceryStoreRepository _groceryStoreRepository;
        private readonly Grocery_Context _context;

        public GroceryStoreController(IConfiguration configuration, IGroceryStoreRepository groceryStoreRepository)
        {
            _configuration = configuration;
            _groceryStoreRepository = groceryStoreRepository;
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] ProductEntity product)
        {
            var result = _groceryStoreRepository.AddProduct(product);
            return Ok(result);
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = _groceryStoreRepository.GetAllProducts();
            return Ok(products);
        }


        [HttpGet("FindProduct/{productId}")]
        public async Task<IActionResult> FindProduct(int productId)
        {
            var product = await _groceryStoreRepository.FindProduct(productId);
            if (product == null)
            {
                return NotFound(new { Message = "No such product exist in the database" });
            }

            return Ok(product);
        }

        [HttpDelete("DeleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await _groceryStoreRepository.DeleteProduct(productId);

            if (!result)
                return NotFound();
            return Ok(new { Message = "Product Deleted!" });
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductEntity updatedProduct)
        {
            var result = await _groceryStoreRepository.UpdateProduct(updatedProduct);

            if (!result)
                return NotFound(new { Message = "No such product exists in the database" });

            return Ok(new { Message = "Product updated successfully" });
        }


        [HttpPost("AddToCart")]

        public async Task<IActionResult> AddToCart([FromBody] CartDTO cartObj)

        {

            if (cartObj == null)

                return BadRequest();


            var res = await _groceryStoreRepository.AddToCart(cartObj);

            if (res == true)
            {
                return Ok(new { Message = "Product Added to the cart!" });
            }

            return Ok(new { Message = "This product is already in your cart!" });
        }




        [HttpGet("GetCartItems")]

        public async Task<IActionResult> GetCartItems(int registerId)

        {

            var result = await _groceryStoreRepository.GetCartItems(registerId);


            return Ok(result);

        }



        [HttpDelete("RemoveItemFromCart/{productId}/{userId}")]
        public async Task<IActionResult> RemoveItemFromCart(int productId, int userId)
        {
            var result = await _groceryStoreRepository.RemoveItemFromCart(productId, userId);
            if (result == true)
            {
                return Ok(new { Message = "Items removed" });
            }
            else
            {
                return Ok(new { Message = "Items not removed" });
            }
        }


        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDTO orderObj)
        {
            if (orderObj == null)
                return BadRequest();

            var res = await _groceryStoreRepository.PlaceOrder(orderObj);

            if (res == true)
                return Ok(new { Message = "Order placed successfully!" });


            return BadRequest();
        }



        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders(int registerId)
        {
            var result = await _groceryStoreRepository.GetOrders(registerId);

            return Ok(result);
        }
    }




}

