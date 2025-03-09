using Urban.Eureka.API.Model;
using Dapper;
using Urban.Eureka.API.Repository.DbContext;
using System.Data;

namespace Urban.Eureka.API.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly IDapperContext _dbcontext;

		public UserRepository(IDapperContext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public async Task<int> Add(User user)
		{
			var query = "INSERT INTO [urban-eureka].[dbo].[Users] ([Name], [Email], [Telephone]) OUTPUT INSERTED.Id VALUES (@Name, @Email, @Telephone);";
			var parameters = new DynamicParameters();
			parameters.Add("Name", user.Name, DbType.String);
			parameters.Add("Email", user.Email, DbType.String);
			parameters.Add("Telephone", user.Telephone, DbType.String);

			using (var connection = _dbcontext.ConnectionCreate())
			{
				return await connection.QuerySingleAsync<int>(query, parameters);
			}
		}

		public async Task Update(User user)
		{
			var query = "UPDATE [urban-eureka].[dbo].[Users] SET [Name] = @Name, [Email] = @Email, [Telephone] = @Telephone WHERE [Id] = @Id;";
			var parameters = new DynamicParameters();
			parameters.Add("Id", user.Id, DbType.Int32);
			parameters.Add("Name", user.Name, DbType.String);
			parameters.Add("Email", user.Email, DbType.String);
			parameters.Add("Telephone", user.Telephone, DbType.String);

			using (IDbConnection db = _dbcontext.ConnectionCreate())
			{
				await db.ExecuteAsync(query, parameters);
			}
		}

		public async Task Delete(int id)
		{
			var query = "DELETE FROM Users WHERE Id = @Id;";
			var parameters = new DynamicParameters();
			parameters.Add("Id", id, DbType.Int32);

			using (var connection = _dbcontext.ConnectionCreate())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<IEnumerable<User>> Get()
		{
			IEnumerable<User> result;
			var query = "SELECT [Id], [Name], [Email], [Telephone] FROM [urban-eureka].[dbo].[Users];";

			using (var db = _dbcontext.ConnectionCreate())
			{
				result = await db.QueryAsync<User>(sql: query, commandType: CommandType.Text);	
			}
			return result;
		}

		public async Task<User> Get(int id)
		{
			User result;
			var query = "SELECT [Id], [Name], [Email], [Telephone] FROM [urban-eureka].[dbo].[Users] WHERE [Id] = @Id;";
			var parameters = new DynamicParameters();
			parameters.Add("Id", id, DbType.Int32);

			using (var db = _dbcontext.ConnectionCreate())
			{
				result = await db.QueryFirstAsync<User>(sql: query, commandType: CommandType.Text, param: parameters);
				return result;
			}
		}
	}
}
