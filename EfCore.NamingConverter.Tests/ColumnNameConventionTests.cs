namespace EfCore.NamingConverter.Tests
{
    public class ColumnNameConventionTests
    {
        [Theory]
        [InlineData(NamingPolicy.CamelCase, "TestName", "testName")]
        [InlineData(NamingPolicy.SnakeCaseLower, "TestName", "test_name")]
        [InlineData(NamingPolicy.SnakeCaseUpper, "TestName", "TEST_NAME")]
        [InlineData(NamingPolicy.KebabCaseLower, "TestName", "test-name")]
        [InlineData(NamingPolicy.KebabCaseUpper, "TestName", "TEST-NAME")]
        public void ProcessPropertyAdded_ShouldConvertColumnName(NamingPolicy namingPolicy, string originalName, string expectedName)
        {
            // TODO: The test is not complete. You need to create a mock for IConventionPropertyBuilder and IConventionContext<IConventionPropertyBuilder>
        }
    }
}

