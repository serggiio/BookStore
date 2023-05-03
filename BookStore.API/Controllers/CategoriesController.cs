using BookStore.API.Constants;
using BookStore.API.DTOs.ApiResult;
using BookStore.API.DTOs.Errors;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ServiceResult<IEnumerable<Category>> serviceResult = this._categoryService.GetAll();
            ApiResult<IEnumerable<Category>> apiResult = new(serviceResult.Result!);
            return this.Ok(apiResult);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            this._categoryService.Create(category);
            return this.Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            this._categoryService.Update(category, id);
            return this.Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._categoryService.DeleteById(id);
            return this.Ok();
        }
    }
}
