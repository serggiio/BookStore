using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Interfaces;

namespace BookStore.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        public CategoryService(IBaseRepository<Category> _categoryRepository)
        {
            this._categoryRepository = _categoryRepository;
        }

        public void Create(Category category)
        {
            this._categoryRepository.Create(category);
        }

        public void DeleteById(int id)
        {
            this._categoryRepository.DeleteById(id);
        }

        public ServiceResult<IEnumerable<Category>> GetAll()
        {
            return this._categoryRepository.GetAll().ToList();
        }

        public void Update(Category category, int id)
        {
            this._categoryRepository.UpdateById(id, category);
        }
    }
}
