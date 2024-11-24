namespace EfCore.NamingConverter
{
    internal sealed class KebabCaseLowerNamingPolicy : SeparatorNamingPolicy
    {
        public KebabCaseLowerNamingPolicy() : base(lowercase: true, separator: '-')
        {
        }
    }
}