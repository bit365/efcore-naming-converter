namespace EfCore.NamingConverter.Tests
{
    public class ConvertNamingPolicyTests
    {
        [Theory]
        [InlineData(NamingPolicy.Unspecified, typeof(NoneCaseNamingPolicy))]
        [InlineData(NamingPolicy.CamelCase, typeof(CamelCaseNamingPolicy))]
        [InlineData(NamingPolicy.SnakeCaseLower, typeof(SnakeCaseLowerNamingPolicy))]
        [InlineData(NamingPolicy.SnakeCaseUpper, typeof(SnakeCaseUpperNamingPolicy))]
        [InlineData(NamingPolicy.KebabCaseLower, typeof(KebabCaseLowerNamingPolicy))]
        [InlineData(NamingPolicy.KebabCaseUpper, typeof(KebabCaseUpperNamingPolicy))]
        public void From_ShouldReturnCorrectPolicy(NamingPolicy namingPolicy, Type expectedType)
        {
            // Act
            var result = ConvertNamingPolicy.From(namingPolicy);

            // Assert
            Assert.IsType(expectedType, result);
        }

        [Fact]
        public void From_ShouldThrowArgumentOutOfRangeExceptionForInvalidPolicy()
        {
            // Arrange
            var invalidPolicy = (NamingPolicy)999;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ConvertNamingPolicy.From(invalidPolicy));
        }

        [Theory]
        [InlineData("TestName", "testName", NamingPolicy.CamelCase)]
        [InlineData("TestName", "test_name", NamingPolicy.SnakeCaseLower)]
        [InlineData("TestName", "TEST_NAME", NamingPolicy.SnakeCaseUpper)]
        [InlineData("TestName", "test-name", NamingPolicy.KebabCaseLower)]
        [InlineData("TestName", "TEST-NAME", NamingPolicy.KebabCaseUpper)]
        [InlineData("TestName", "TestName", NamingPolicy.Unspecified)]
        public void ConvertName_ShouldConvertNameAccordingToPolicy(string input, string expected, NamingPolicy namingPolicy)
        {
            // Arrange
            var policy = ConvertNamingPolicy.From(namingPolicy);

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

