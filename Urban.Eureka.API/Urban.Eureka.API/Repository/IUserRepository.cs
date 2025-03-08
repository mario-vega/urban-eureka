using Urban.Eureka.API.Model;

namespace Urban.Eureka.API.Repository
{
	public interface IUserRepository
	{
		public Task<IEnumerable<User>> Get();
		public Task<User> Get(int id);
		public Task<int> Add(User user);
		public Task Update(User user);
		public Task Delete(int id);
	}
}
