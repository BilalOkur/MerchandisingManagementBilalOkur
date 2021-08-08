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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        public CategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Category category)
        {
            _categoryManager.AddCategory(category);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryListe =_categoryManager.GetAllCategory();
            return Ok(categoryListe);
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string categoryName)
        {
            var categoryListe = _categoryManager.GetCategoryByName(categoryName);
            return Ok(categoryListe);
        }
    }
}
