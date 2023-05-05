using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IEnumerable<Product> Get() => API.Data.data_for.products;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = API.Data.data_for.products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            API.Data.data_for.products.Remove(API.Data.data_for.products.SingleOrDefault(p => p.Id == id));
            return Ok(new {message = "Nixua sebe"});
        }

        private int NextProductId => API.Data.data_for.products.Count() == 0 ? 1 : API.Data.data_for.products.Max(x => x.Id) +1;

        [HttpGet("GetNextProductId")]
        public int GetNextProductId()
        {
            return NextProductId;
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            product.Id = NextProductId;
            API.Data.data_for.products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPost("AddProduct")]
        public IActionResult PostBody([FromBody] Product product) => Post(product);

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var storedProduct = API.Data.data_for.products.SingleOrDefault(p => p.Id == product.Id);
            if (storedProduct == null) return NotFound();
            storedProduct.Name =   product.Name;
            storedProduct.Price = product.Price;
            return Ok(storedProduct);
        }

        [HttpPut("PutProduct")]
        public IActionResult PutBody([FromBody] Product product) => Put(product);

    }
}
