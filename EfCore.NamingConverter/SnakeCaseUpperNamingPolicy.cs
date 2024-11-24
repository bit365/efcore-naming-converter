
namespace EfCore.NamingConverter
{
    internal class SnakeCaseUpperNamingPolicy : SeparatorNamingPolicy
    {
        public SnakeCaseUpperNamingPolicy() : base(lowercase: false, separator: '_')
        {
        }
    }
}
