namespace EfCore.NamingConverter
{
    internal sealed class KebabCaseUpperNamingPolicy : SeparatorNamingPolicy
    {
        public KebabCaseUpperNamingPolicy() : base(lowercase: false, separator: '-')
        {
        }
    }
}
