namespace EfCore.NamingConverter.Converters
{
    internal sealed class KebabCaseUpperConverter : SeparatorConverter
    {
        public KebabCaseUpperConverter() : base(lowercase: false, separator: '-')
        {
        }
    }
}