using BookStore.API.Constants;
using BookStore.API.DTOs.ApiResult;
using BookStore.API.DTOs.Errors;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ServiceResult<IEnumerable<Book>> serviceResult = this._bookService.GetAll();
            ApiResult<IEnumerable<Book>> apiResult = new(serviceResult.Result!);
            return this.Ok(apiResult);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ServiceResult<Book> serviceResult = this._bookService.GetById(id);
            ApiResult<Book> apiResult = new(serviceResult.Result!);
            return this.Ok(apiResult);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book newBook)
        {
            this._bookService.Create(newBook);
            return this.Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            ServiceResult<BookResponse> serviceResult = this._bookService.UpdateById(bookPatch, id);

            if (!serviceResult.IsValid)
            {
                List<BaseError> errors = serviceResult.Errors!.Select(x => new BaseError(x)).ToList();
                return this.BadRequest(new ApiErrorResult(errors, ResponseMessages.BadRequestMessage));
            }
            return this.Ok(new ApiResult<BookResponse>(serviceResult.Result!));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._bookService.DeleteById(id);
            return this.Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            ServiceResult<BookResponse> serviceResult = this._bookService.UpdatePut(book, id);

            if (!serviceResult.IsValid)
            {
                List<BaseError> errors = serviceResult.Errors!.Select(x => new BaseError(x)).ToList();
                return this.BadRequest(new ApiErrorResult(errors, ResponseMessages.BadRequestMessage));
            }
            return this.Ok(new ApiResult<BookResponse>(serviceResult.Result!));
        }

        [HttpDelete("{id}/Category/{categoryId}")]
        public IActionResult Delete(int id, int categoryId)
        {
            this._bookService.DeleteById(id);
            return this.Ok();
        }
    }
}
