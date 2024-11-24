using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EfCore.NamingConverter
{
    public class ColumnNameConvention(NamingPolicy namingPolicy) : IPropertyAddedConvention
    {
        public void ProcessPropertyAdded(IConventionPropertyBuilder propertyBuilder, IConventionContext<IConventionPropertyBuilder> context)
        {
            ConvertNamingPolicy convertNamingPolicy = ConvertNamingPolicy.From(namingPolicy);

            string propertyName = propertyBuilder.Metadata.GetColumnName();

            if (propertyName != null)
            {
                propertyBuilder.HasColumnName(convertNamingPolicy.ConvertName(propertyName));
            }
        }
    }
}
