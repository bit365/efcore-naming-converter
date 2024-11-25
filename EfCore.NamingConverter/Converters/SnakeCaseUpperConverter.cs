namespace EfCore.NamingConverter.Converters
{
    internal class SnakeCaseUpperConverter : SeparatorConverter
    {
        public SnakeCaseUpperConverter() : base(lowercase: false, separator: '_')
        {
        }
    }
}
