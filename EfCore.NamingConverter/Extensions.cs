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

            configurationBuilder.Conventions.Add(services => new NamingConvention(services, converter));
        }
    }
}