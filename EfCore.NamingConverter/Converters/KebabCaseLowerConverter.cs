namespace EfCore.NamingConverter.Converters
{
    internal sealed class KebabCaseLowerConverter : SeparatorConverter
    {
        public KebabCaseLowerConverter() : base(lowercase: true, separator: '-')
        {
        }
    }
}