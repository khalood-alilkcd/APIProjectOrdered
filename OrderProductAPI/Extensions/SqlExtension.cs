

using DomainCore.Context;

namespace OrderProductAPI.Extensions
{
    public static class SqlExtension
    {
        public static void ConfigeSql(this IServiceCollection services, IConfiguration configuration)
            => services.AddSqlServer<DataContext>(configuration.GetConnectionString("SqlConnections"));
       
    }
}
