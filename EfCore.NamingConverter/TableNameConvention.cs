using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EfCore.NamingConverter
{
    public class TableNameConvention(NamingPolicy namingPolicy) : IEntityTypeAddedConvention
    {
        public void ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, IConventionContext<IConventionEntityTypeBuilder> context)
        {
            ConvertNamingPolicy convertNamingPolicy = ConvertNamingPolicy.From(namingPolicy);

            string? tableName = entityTypeBuilder.Metadata.GetTableName();
            if (tableName != null)
            {
                entityTypeBuilder.ToTable(convertNamingPolicy.ConvertName(tableName));
            }
        }
    }
}
