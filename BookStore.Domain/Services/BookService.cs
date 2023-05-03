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
        private readonly ICategoryBookRepository _categoryRepository;
        public BookService(IBaseRepository<Book> _bookRepository, ICategoryBookRepository _categoryRepository)
        {
            this._bookRepository = _bookRepository;
            this._categoryRepository = _categoryRepository;
        }

        public void Create(Book book)
        {
            this._bookRepository.Create(book);
        }

        public void DeleteById(int id)
        {
            this._bookRepository.DeleteById(id);
        }

        public ServiceResult<IEnumerable<Book>> GetAll()
        {
            List<Book> books = this._bookRepository.GetAll().ToList();
            foreach (var book in books)
            {
                book.Categories = _categoryRepository.GetCategoriesByBooKId(book.Id).ToList();
            }
            return books;
        }

        public ServiceResult<Book> GetById(int id)
        {
            Book book = this._bookRepository.GetById(id);
            book.Categories = this._categoryRepository.GetCategoriesByBooKId(id).ToList();
            return book;
        }

        public ServiceResult<BookResponse> UpdateById(JsonPatchDocument<Book> book, int id)
        {
            Book bookStored = this._bookRepository.GetById(id);
            book.ApplyTo(bookStored);

            return this.ValidateAndSaveBook(bookStored, id);
        }

        public ServiceResult<BookResponse> UpdatePut(Book book, int id)
        {
            return this.ValidateAndSaveBook(book, id);
        }
        public void AddCategory(int bookId, int categoryId)
        {
            this._categoryRepository.AddCategoryBook(categoryId, bookId);
        }

        public void DeleteCategory(int bookId, int categoryId)
        {
            this._categoryRepository.DeleteCategoryBook(categoryId, bookId);
        }


        private ServiceResult<BookResponse> ValidateAndSaveBook(Book book, int id)
        {
            BookValidator validator = new BookValidator();
            ValidationResult validationResult = validator.Validate(book);

            BookResponse bookResponse = new BookResponse();

            if (validationResult.IsValid)
            {
                this._bookRepository.UpdateById(id, book);
                bookResponse.Book = book;
            }
            else
            {
                bookResponse.Errors = validationResult.Errors;
            }

            return bookResponse;
        }
    }
}
