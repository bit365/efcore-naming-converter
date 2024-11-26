using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace EfCore.NamingConverter.Tests
{
    public class MyTestHelpers : TestHelpers
    {
        private static readonly Lazy<MyTestHelpers> _instance = new Lazy<MyTestHelpers>(() => new MyTestHelpers());

        private MyTestHelpers() { }

        public override IServiceCollection AddProviderServices(IServiceCollection services)
        {
            return services.AddEntityFrameworkSqlite();
        }

        public override DbContextOptionsBuilder UseProviderOptions(DbContextOptionsBuilder optionsBuilder)
        {
            return optionsBuilder.UseSqlite("DataSource=:memory:");
        }

        public static MyTestHelpers Instance => _instance.Value;
    }
}
