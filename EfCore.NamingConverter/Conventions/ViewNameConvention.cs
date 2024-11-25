using EfCore.NamingConverter.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EfCore.NamingConverter.Conventions
{
    public class ViewNameConvention(NameConverter nameConverter) : IEntityTypeAddedConvention
    {
        public void ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, IConventionContext<IConventionEntityTypeBuilder> context)
        {
            string? viewName = entityTypeBuilder.Metadata.GetViewName();

            if (viewName != null && entityTypeBuilder.Metadata.GetViewNameConfigurationSource() == ConfigurationSource.Convention)
            {
                entityTypeBuilder.ToView(nameConverter.ConvertName(viewName));
            }
        }
    }
}
