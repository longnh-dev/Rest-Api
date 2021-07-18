using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Module1.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> _customer = new List<Customer>()
        {
            new Customer(){Id = 0, Name = "Nguyen Van A", Email = "nguyenvana@gmail.com"},
            new Customer(){Id = 0, Name = "Nguyen Van A", Email = "nguyenvana@gmail.com"}


        };

        public IEnumerable<Customer> Get()
        {
            return _customer;
        }
        

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customer.Add(customer);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
