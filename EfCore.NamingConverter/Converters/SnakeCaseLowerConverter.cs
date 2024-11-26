namespace EfCore.NamingConverter.Converters
{
    internal sealed class SnakeCaseLowerConverter : SeparatorConverter
    {
        public SnakeCaseLowerConverter() : base(lowercase: true, separator: '_')
        {
        }
    }
}