using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : IBaseRepository<Book>
    {

        private readonly SQLConnection connection;

        public BookRepository(SQLConnection sqlConnection)
        {
            this.connection = sqlConnection;
        }

        public void Create(Book entity)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Create_Book";
            var parameters = new DynamicParameters();
            parameters.Add("@BookTitle", entity.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("@BookPages", entity.Pages, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@BookDescription", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@BookPublisher", entity.Publisher, DbType.String, ParameterDirection.Input);
            parameters.Add("@BookReleaseDate", entity.ReleaseDate, DbType.DateTime, ParameterDirection.Input);
            db.Query<Book>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void DeleteById(int id)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Delete_Book";
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", id, DbType.Int32, ParameterDirection.Input);
            db.Query<Book>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Book> GetAll()
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Get_Books";
            var parameters = new DynamicParameters();
            return db.Query<Book>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public Book GetById(int id)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Get_Book_By_Id";
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", id, DbType.Int32, ParameterDirection.Input);
            return db.Query<Book>(procedure, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void UpdateById(int id, Book entity)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Update_Book";
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@BookTitle", entity.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("@BookPages", entity.Pages, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@BookDescription", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@BookPublisher", entity.Publisher, DbType.String, ParameterDirection.Input);
            parameters.Add("@BookReleaseDate", entity.ReleaseDate, DbType.DateTime, ParameterDirection.Input);
            db.Query<Book>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
