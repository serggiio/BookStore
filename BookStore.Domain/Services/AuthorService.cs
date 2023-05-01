using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Domain.Validators;
using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Interfaces;
using BookStore.Infrastructure.Repositories;
using FluentValidation.Results;
using Microsoft.AspNetCore.JsonPatch;
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

        public ServiceResult<AuthorResponse> UpdateById(JsonPatchDocument<Author> author, int id)
        {
            Author authorStored = this._authorRepository.GetById(id);
            AuthorResponse authorResponse = new AuthorResponse();
            author.ApplyTo(authorStored);

            AuthorValidator validator = new AuthorValidator();
            ValidationResult validationResult = validator.Validate(authorStored);

            if (validationResult.IsValid)
            {
                this._authorRepository.UpdateById(id, authorStored);
                authorResponse.Author = authorStored;
            }
            else
            {
                authorResponse.Errors = validationResult.Errors;
            }

            return authorResponse;
        }
    }
}
