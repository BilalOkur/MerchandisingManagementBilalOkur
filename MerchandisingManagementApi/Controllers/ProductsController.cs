using MerchandisingManagementDTOs.DTO;
using MerchandisingManagementServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchandisingManagementApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult SearchProducts([FromQuery]string keyword)
        {
           var result = _productManager.SearchProduct(keyword);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            var result = _productManager.AddProduct(product);
            return Ok(result);
        }
    }
}
