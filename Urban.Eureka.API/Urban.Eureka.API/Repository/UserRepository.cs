using Urban.Eureka.API.Model;
using Dapper;
using Urban.Eureka.API.Repository.DbContext;

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
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<User>> Get()
		{
			throw new NotImplementedException();
		}

		public async Task<User> Get(int id)
		{
			throw new NotImplementedException();
		}

		public async Task Update(User user)
		{
			throw new NotImplementedException();
		}
	}
}
