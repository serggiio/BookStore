using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Interfaces;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace BookStore.Infrastructure.Repositories
{
    public class CategoryRepository : IBaseRepository<Category>, ICategoryBookRepository
    {
        private readonly SQLConnection connection;

        public CategoryRepository(SQLConnection sqlConnection)
        {
            this.connection = sqlConnection;
        }

        public void Create(Category entity)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Create_Category";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", entity.Name, DbType.String, ParameterDirection.Input);
            db.Query<Category>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void DeleteById(int id)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Delete_Category";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id, DbType.Int32, ParameterDirection.Input);
            db.Query<Category>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Category> GetAll()
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Get_Categories";
            var parameters = new DynamicParameters();
            return db.Query<Category>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int id, Category entity)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Update_Category";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CategoryName", entity.Name, DbType.String, ParameterDirection.Input);
            db.Query<Category>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Category> GetCategoriesByBooKId(int id)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Get_Categories_By_Book_Id";
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", id, DbType.Int32, ParameterDirection.Input);
            return db.Query<Category>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void AddCategoryBook(int categoryId, int bookId)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Add_Category_Book";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", categoryId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@bookId", bookId, DbType.Int32, ParameterDirection.Input);
            db.Query<Category>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategoryBook(int categoryId, int bookId)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Delete_Category_Book";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", categoryId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@bookId", bookId, DbType.Int32, ParameterDirection.Input);
            db.Query<Category>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
