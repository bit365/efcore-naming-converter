namespace EfCore.NamingConverter
{
    internal class NoneCaseNamingPolicy : ConvertNamingPolicy
    {
        public override string ConvertName(string name) => name;
    }
}
