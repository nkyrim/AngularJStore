using System.Linq;
using System.Web.Http;
using AngularJStore.DAL;
using AngularJStore.Models.Order;

namespace AngularJStore.App.Controllers.Api
{
    public class OrderController : ApiController
    {
        private readonly StoreContext _db = new StoreContext();
        
        [HttpPost]
        public IHttpActionResult GetOrders(GetOrders request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var orders = _db.Orders
                .Where(c => c.CustomerId == request.Id)
                .Select(q => new Order
                {
                    Id = q.Id,
                    Quantity = q.Quantity,
                    Product = q.Product,
                    Price = q.Price
                });

            return Ok(new { Data = orders });
        }
    }
}
