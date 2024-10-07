using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(Order ToAdd)
        {

            var available = new OrderProccesingAvailableProduct();
            var prices = new OrderProccesingTotal();
            var sender = new SendOrder();
            var quantity = new OrderProccesingQuantityProducts();
            quantity.AddNext(sender);//4.- se envia el producto
            prices.AddNext(quantity);//3.- valida la cantidad del producto
            available.AddNext(prices);//2.- se checa el precio del producto
            available.Processing(ToAdd);//1.- se checa disponibilidad del producto
            return Ok(sender);
        }
    }

    
}
