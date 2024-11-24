using EfCore.NamingConverter;

namespace Microsoft.EntityFrameworkCore
{
    public static class Extensions
    {
        public static void AddNamingConventions(this ModelConfigurationBuilder configurationBuilder, NamingPolicy namingPolicy = NamingPolicy.Unspecified)
        {
            configurationBuilder.Conventions.Add(_ => new TableNameConvention(namingPolicy));
            configurationBuilder.Conventions.Add(_ => new ColumnNameConvention(namingPolicy));
        }
    }
}