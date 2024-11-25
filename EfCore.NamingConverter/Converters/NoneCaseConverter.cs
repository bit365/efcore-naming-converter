namespace EfCore.NamingConverter.Converters
{
    internal class NoneCaseConverter : NameConverter
    {
        public override string ConvertName(string name) => name;
    }
}
