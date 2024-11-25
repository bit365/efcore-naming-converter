using EfCore.NamingConverter.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EfCore.NamingConverter.Conventions
{
    public class IndexNameConvention(NameConverter converter) : IIndexAddedConvention
    {
        public void ProcessIndexAdded(IConventionIndexBuilder indexBuilder, IConventionContext<IConventionIndexBuilder> context)
        {
            string? indexName = indexBuilder.Metadata.GetDatabaseName();

            if (indexName != null)
            {
                indexBuilder.HasDatabaseName(converter.ConvertName(indexName));
            }
        }
    }
}
