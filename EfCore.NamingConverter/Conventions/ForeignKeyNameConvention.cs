using EfCore.NamingConverter.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EfCore.NamingConverter.Conventions
{
    public class ForeignKeyNameConvention(NameConverter converter) : IForeignKeyAddedConvention, IForeignKeyPropertiesChangedConvention
    {
        public void ProcessForeignKeyAdded(IConventionForeignKeyBuilder foreignKeyBuilder, IConventionContext<IConventionForeignKeyBuilder> context)
        {
            string? foreignKeyName = foreignKeyBuilder.Metadata.GetDefaultName();

            if (foreignKeyName != null)
            {
                foreignKeyBuilder.HasConstraintName(converter.ConvertName(foreignKeyName));
            }
        }

        public void ProcessForeignKeyPropertiesChanged(IConventionForeignKeyBuilder relationshipBuilder, IReadOnlyList<IConventionProperty> oldDependentProperties, IConventionKey oldPrincipalKey, IConventionContext<IReadOnlyList<IConventionProperty>> context)
        {
            string? foreignKeyName = relationshipBuilder.Metadata.GetDefaultName();

            if (foreignKeyName != null && relationshipBuilder.Metadata.IsInModel)
            {
                relationshipBuilder.HasConstraintName(converter.ConvertName(foreignKeyName));
            }
        }
    }
}
