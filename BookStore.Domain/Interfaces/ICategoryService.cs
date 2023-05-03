using BookStore.Domain.Models;
using BookStore.Infrastructure.Entities;

namespace BookStore.Domain.Interfaces
{
    public interface ICategoryService
    {
        public ServiceResult<IEnumerable<Category>> GetAll();

        public void Create(Category category);

        public void Update(Category category, int id);

        public void DeleteById(int id);
    }
}
