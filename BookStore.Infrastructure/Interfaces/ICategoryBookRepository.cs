using BookStore.Infrastructure.Entities;

namespace BookStore.Infrastructure.Interfaces
{
    public interface ICategoryBookRepository
    {
        public IEnumerable<Category> GetCategoriesByBooKId(int id);

        public void AddCategoryBook(int categoryId, int bookId);

        public void DeleteCategoryBook(int categoryId, int bookId);
    }
}
