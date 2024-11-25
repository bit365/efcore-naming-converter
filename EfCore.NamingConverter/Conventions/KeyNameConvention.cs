using EfCore.NamingConverter.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EfCore.NamingConverter.Conventions
{
    public class KeyNameConvention(NameConverter converter) : IKeyAddedConvention
    {
        public void ProcessKeyAdded(IConventionKeyBuilder keyBuilder, IConventionContext<IConventionKeyBuilder> context)
        {
            string? keyName = keyBuilder.Metadata.GetName();

            if (keyName != null)
            {
                keyBuilder.HasName(converter.ConvertName(keyName));
            }
        }
    }
}
