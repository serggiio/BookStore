using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Interfaces;
using BookStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IBaseRepository<Author> _authorRepository;
        public AuthorService(IBaseRepository<Author> authorRepository)
        {
            this._authorRepository = authorRepository;
        }

        public void Create(Author author)
        {
            this._authorRepository.Create(author);
        }

        public void DeleteById(int id)
        {
            this._authorRepository.DeleteById(id);
        }

        public ServiceResult<IEnumerable<Author>> GetAll()
        {
            return this._authorRepository.GetAll().ToList();
        }

        public ServiceResult<Author> GetById(int id)
        {
            return this._authorRepository.GetById(id);
        }

        public ServiceResult<Author> UpdateById(Author author, int id)
        {
            throw new NotImplementedException();
        }
    }
}
