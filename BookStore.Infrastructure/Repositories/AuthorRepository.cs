using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BookStore.Infrastructure.Repositories
{
    public class AuthorRepository : IBaseRepository<Author>
    {
        private readonly SQLConnection connection;

        public AuthorRepository(SQLConnection sqlConnection)
        {
            this.connection = sqlConnection;
        }

        public void Create(Author entity)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Create_Author";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorName", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@AuthorCountry", entity.Country, DbType.String, ParameterDirection.Input);
            db.Query<Author>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public void DeleteById(int id)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Delete_Author";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorId", id, DbType.Int32, ParameterDirection.Input);
            db.Query<Author>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Author> GetAll()
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Get_Authors";
            var parameters = new DynamicParameters();
            return db.Query<Author>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public Author GetById(int id)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Get_Author_By_Id";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorId", id, DbType.Int32, ParameterDirection.Input);
            return db.Query<Author>(procedure, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void UpdateById(int id, Author entity)
        {
            using IDbConnection db = new SqlConnection(this.connection.ConnectionString);
            var procedure = "Update_Author";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorId", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AuthorName", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@AuthorCountry", entity.Country, DbType.String, ParameterDirection.Input);
            db.Query<Author>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
