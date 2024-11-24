namespace EfCore.NamingConverter.Tests
{
    public class TableNameConventionTests
    {
        [Theory]
        [InlineData(NamingPolicy.CamelCase, "TestTable", "testTable")]
        [InlineData(NamingPolicy.SnakeCaseLower, "TestTable", "test_table")]
        [InlineData(NamingPolicy.SnakeCaseUpper, "TestTable", "TEST_TABLE")]
        [InlineData(NamingPolicy.KebabCaseLower, "TestTable", "test-table")]
        [InlineData(NamingPolicy.KebabCaseUpper, "TestTable", "TEST-TABLE")]
        [InlineData(NamingPolicy.Unspecified, "TestTable", "TestTable")]
        public void ProcessEntityTypeAdded_ShouldConvertTableName(NamingPolicy namingPolicy, string originalName, string expectedName)
        {
            // TODO: This test is not complete. You need to create a mock for IConventionEntityTypeBuilder and call the ProcessEntityTypeAdded method.
        }
    }
}

