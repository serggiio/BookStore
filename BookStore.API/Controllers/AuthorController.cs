using BookStore.API.DTOs.ApiResult;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IActionResult Get()
        {
            ServiceResult<IEnumerable<Author>> serviceResult = this._authorService.GetAll();
            ApiResult<IEnumerable<Author>> apiResult = new(serviceResult.Result!);
            return this.Ok(apiResult);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ServiceResult<Author> serviceResult = this._authorService.GetById(id);
            ApiResult<Author> apiResult = new(serviceResult.Result!);
            return this.Ok(apiResult);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromBody] Author newAuthor)
        {
            this._authorService.Create(newAuthor);
            return this.Ok();
        }

        // PUT api/<AuthorController>/5
        [HttpPatch("{id}")]
        public void UpdateAplicant(int id, [FromBody] JsonPatchDocument<Author> personPatch)
        {
            
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._authorService.DeleteById(id);
            return this.Ok();
        }
    }
}
