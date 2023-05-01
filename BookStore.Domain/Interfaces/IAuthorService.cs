using BookStore.Domain.Models;
using BookStore.Infrastructure.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStore.Domain.Interfaces
{
    public interface IAuthorService
    {
        public ServiceResult<IEnumerable<Author>> GetAll();

        public ServiceResult<Author> GetById(int id);

        public void Create(Author author);

        public ServiceResult<AuthorResponse> UpdateById(JsonPatchDocument<Author> author, int id);

        public void DeleteById(int id);
    }
}
