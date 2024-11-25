using EfCore.NamingConverter.Conventions;
using EfCore.NamingConverter.Converters;
using Microsoft.EntityFrameworkCore;

namespace EfCore.NamingConverter
{
    public static class Extensions
    {
        public static void AddNamingConventions(this ModelConfigurationBuilder configurationBuilder, NamingPolicy namingPolicy = NamingPolicy.Unspecified)
        {
            NameConverter converter = NameConverter.From(namingPolicy);

            configurationBuilder.Conventions.Add(_ => new TableNameConvention(converter));
            configurationBuilder.Conventions.Add(_ => new ViewNameConvention(converter));
            configurationBuilder.Conventions.Add(_ => new ColumnNameConvention(converter));
            configurationBuilder.Conventions.Add(_ => new IndexNameConvention(converter));
            configurationBuilder.Conventions.Add(_ => new KeyNameConvention(converter));
            configurationBuilder.Conventions.Add(_ => new ForeignKeyNameConvention(converter));
        }
    }
}