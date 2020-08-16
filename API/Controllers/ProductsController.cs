using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using core.Entities;
using  System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {

            _context = context;
        }
        [HttpGet]
        public ActionResult<List<product>> Getproducts()
        {
            var products = _context.products.ToList();
            return  Ok(products);
        }
        [HttpGet("{id}")]
        public  async Task<ActionResult<product>> Getproduct(int id)
        {
             
            return  await  _context.products.FindAsync(id);

        }
         
    }
}