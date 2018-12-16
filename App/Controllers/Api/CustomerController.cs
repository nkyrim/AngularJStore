using System.Linq;
using System.Web.Http;
using AngularJStore.App.Models.Customer;
using AngularJStore.DAL;

namespace AngularJStore.App.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private readonly StoreContext _db = new StoreContext();

        public IHttpActionResult GetAll()
        {
            var customers = _db.Customers
                .Select(c => new Customer
                {
                    Id = c.Id,
                    Name = c.Name,
                    Phone = c.Phone,
                    Email = c.Email,
                    Company = c.Company
                });

            return Ok(new { Data = customers });
        }

        public IHttpActionResult Get(int id)
        {
            var customer = _db.Customers
                .Where(c => c.Id == id)
                .Select(c => new Customer
                {
                    Id = c.Id,
                    Name = c.Name,
                    Phone = c.Phone,
                    Email = c.Email,
                    Company = c.Company
                })
                .FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(new { Data = customer });
        }

        public IHttpActionResult Add(AddCustomer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerToAdd = new DAL.Models.Customer
            {
                Name = customer.Name,
                Company = customer.Company,
                Email = customer.Email,
                Phone = customer.Phone
            };

            var customerAdded = _db.Customers.Add(customerToAdd);
            _db.SaveChanges();

            var customerToReturn = new Customer
            {
                Id = customerAdded.Id,
                Name = customerAdded.Name,
                Phone = customerAdded.Phone,
                Email = customerAdded.Email,
                Company = customerAdded.Company
            };

            return Ok(new { Date = customerToReturn });
        }

        public IHttpActionResult Edit(EditCustomer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerToEdit = _db.Customers.SingleOrDefault(c => c.Id == customer.Id);
            if (customerToEdit == null)
            {
                return BadRequest();
            }

            customerToEdit.Name = customer.Name;
            customerToEdit.Company = customer.Company;
            customerToEdit.Email = customer.Email;
            customerToEdit.Phone = customer.Phone;

            _db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete(DeleteCustomer customer)
        {
            var customerToDelete = _db.Customers.Find(customer.Id);
            if (customerToDelete == null)
            {
                return NotFound();
            }

            _db.Customers.Remove(customerToDelete);
            _db.SaveChanges();

            return Ok();
        }
    }
}
