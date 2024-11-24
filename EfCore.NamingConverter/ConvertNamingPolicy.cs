
namespace EfCore.NamingConverter
{
    public abstract class ConvertNamingPolicy
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ConvertNamingPolicy"/>.
        /// </summary>
        protected ConvertNamingPolicy() { }

        /// <summary>
        /// Returns the naming policy for camel-casing.
        /// </summary>
        public static ConvertNamingPolicy CamelCase { get; } = new CamelCaseNamingPolicy();

        /// <summary>
        /// Returns the naming policy for lower snake-casing.
        /// </summary>
        public static ConvertNamingPolicy SnakeCaseLower { get; } = new SnakeCaseLowerNamingPolicy();

        /// <summary>
        /// Returns the naming policy for upper snake-casing.
        /// </summary>
        public static ConvertNamingPolicy SnakeCaseUpper { get; } = new SnakeCaseUpperNamingPolicy();

        /// <summary>
        /// Returns the naming policy for lower kebab-casing.
        /// </summary>
        public static ConvertNamingPolicy KebabCaseLower { get; } = new KebabCaseLowerNamingPolicy();

        /// <summary>
        /// Returns the naming policy for upper kebab-casing.
        /// </summary>
        public static ConvertNamingPolicy KebabCaseUpper { get; } = new KebabCaseUpperNamingPolicy();

        /// <summary>
        /// Returns the naming policy for no conversion.
        /// </summary>
        public static ConvertNamingPolicy None { get; } = new NoneCaseNamingPolicy();

        /// <summary>
        /// When overridden in a derived class, converts the specified name according to the policy.
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The converted name.</returns>
        public abstract string ConvertName(string name);

        public static ConvertNamingPolicy From(NamingPolicy namingPolicy)
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
