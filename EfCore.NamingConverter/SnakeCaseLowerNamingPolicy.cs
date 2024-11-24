namespace EfCore.NamingConverter
{
    internal sealed class SnakeCaseLowerNamingPolicy : SeparatorNamingPolicy
    {
        public SnakeCaseLowerNamingPolicy() : base(lowercase: true, separator: '_')
        {
        }
    }
}
