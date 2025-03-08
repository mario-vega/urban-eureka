using System.Data;

namespace Urban.Eureka.API.Repository.DbContext
{
	public interface IDapperContext
	{
		public IDbConnection ConnectionCreate();
	}
}
