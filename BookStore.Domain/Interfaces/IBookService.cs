using BookStore.Domain.Models;
using BookStore.Infrastructure.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IBookService
    {
        public ServiceResult<IEnumerable<Book>> GetAll();

        public ServiceResult<Book> GetById(int id);

        public void Create(Book book);

        public ServiceResult<BookResponse> UpdateById(JsonPatchDocument<Book> book, int id);

        public ServiceResult<BookResponse> UpdatePut(Book book, int id);

        public void DeleteById(int id);

        public void DeleteLanguage(int bookId, int languageId);

        public void DeleteCategory(int bookId, int languageId);

    }
}
