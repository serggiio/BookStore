using BookStore.Domain.Models;
using BookStore.Infrastructure.Entities;

namespace BookStore.Domain.Interfaces
{
    public interface IAuthorService
    {
        public ServiceResult<IEnumerable<Author>> GetAll();

        public ServiceResult<Author> GetById(int id);

        public void Create(Author author);

        public ServiceResult<Author> UpdateById(Author author, int id);

        public void DeleteById(int id);
    }
}
