using Microsoft.Data.SqlClient;
using System.Data;

namespace Urban.Eureka.API.Repository.DbContext
{
	public class DapperContext : IDapperContext
	{
		private readonly IConfiguration _configuration;

		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IDbConnection ConnectionCreate()
		{
			return new SqlConnection(_configuration.GetConnectionString("DbConnection"));
		}
	}
}
