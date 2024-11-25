
namespace EfCore.NamingConverter.Converters
{
    public abstract class NameConverter
    {
        protected NameConverter() { }

        public static NameConverter CamelCase { get; } = new CamelCaseConverter();

        public static NameConverter SnakeCaseLower { get; } = new SnakeCaseLowerConverter();

        public static NameConverter SnakeCaseUpper { get; } = new SnakeCaseUpperConverter();

        public static NameConverter KebabCaseLower { get; } = new KebabCaseLowerConverter();

        public static NameConverter KebabCaseUpper { get; } = new KebabCaseUpperConverter();

        public static NameConverter None { get; } = new NoneCaseConverter();

        public abstract string ConvertName(string name);

        public static NameConverter From(NamingPolicy namingPolicy)
        {
            return namingPolicy switch
            {
                NamingPolicy.Unspecified => None,
                NamingPolicy.CamelCase => CamelCase,
                NamingPolicy.SnakeCaseLower => SnakeCaseLower,
                NamingPolicy.SnakeCaseUpper => SnakeCaseUpper,
                NamingPolicy.KebabCaseLower => KebabCaseLower,
                NamingPolicy.KebabCaseUpper => KebabCaseUpper,
                _ => throw new ArgumentOutOfRangeException(nameof(namingPolicy))
            };
        }
    }
}
