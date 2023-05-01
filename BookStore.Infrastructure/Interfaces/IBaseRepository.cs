using BookStore.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Interfaces
{
    public interface IBaseRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T GetById(int id);

        public void Create(T entity);

        public void UpdateById(int id, T entity);

        public void DeleteById(int id);

    }
}
