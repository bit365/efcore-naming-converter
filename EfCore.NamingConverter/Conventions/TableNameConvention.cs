using EfCore.NamingConverter.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EfCore.NamingConverter.Conventions
{
    public class TableNameConvention(NameConverter converter) : IEntityTypeAddedConvention
    {
        public void ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, IConventionContext<IConventionEntityTypeBuilder> context)
        {
            string? tableName = entityTypeBuilder.Metadata.GetTableName();

            if (tableName != null)
            {
                entityTypeBuilder.ToTable(converter.ConvertName(tableName));
            }
        }
    }
}
