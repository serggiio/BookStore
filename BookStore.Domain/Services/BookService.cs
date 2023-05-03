using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Domain.Validators;
using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public class BookService : IBookService
    {

        private readonly IBaseRepository<Book> _bookRepository;
        public BookService(IBaseRepository<Book> _bookRepository)
        {
            this._bookRepository = _bookRepository;
        }

        public void Create(Book book)
        {
            this._bookRepository.Create(book);
        }

        public void DeleteById(int id)
        {
            this._bookRepository.DeleteById(id);
        }

        public void DeleteCategory(int bookId, int languageId)
        {
            throw new NotImplementedException();
        }

        public void DeleteLanguage(int bookId, int languageId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<IEnumerable<Book>> GetAll()
        {
            return this._bookRepository.GetAll().ToList();
        }

        public ServiceResult<Book> GetById(int id)
        {
            return this._bookRepository.GetById(id);
        }

        public ServiceResult<BookResponse> UpdateById(JsonPatchDocument<Book> book, int id)
        {
            Book bookStored = this._bookRepository.GetById(id);
            BookResponse bookResponse = new BookResponse();
            book.ApplyTo(bookStored);

            BookValidator validator = new BookValidator();
            ValidationResult validationResult = validator.Validate(bookStored);

            if (validationResult.IsValid)
            {
                this._bookRepository.UpdateById(id, bookStored);
                bookResponse.Book= bookStored;
            }
            else
            {
                bookResponse.Errors = validationResult.Errors;
            }

            return bookResponse;
        }
    }
}
