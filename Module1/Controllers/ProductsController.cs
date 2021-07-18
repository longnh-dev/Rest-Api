using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Module1.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){ProductId = 0, ProductName = "Laptop", ProductPrice = "200"},
            new Product(){ProductId = 1, ProductName = "Smartphone", ProductPrice = "100"},
        };


        //GetAll
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_products);
        }


        //Send message to Client when they go to Store Website
        [HttpGet("LoadWelcomeMessage")]
        public IActionResult GetWelcomeMessage()
        {
            return Ok("Welcome to our Store");
        }


        //create
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }


        //Update 
        [HttpPut("{id}")] 
        public void Put(int id, [FromBody] Product product)
        {
            _products[id] = product;
        }

        //Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }
    }
}
