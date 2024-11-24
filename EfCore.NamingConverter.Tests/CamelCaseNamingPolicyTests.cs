namespace EfCore.NamingConverter.Tests
{
    public class CamelCaseNamingPolicyTests
    {
        [Fact]
        public void ConvertName_ShouldConvertToCamelCase()
        {
            // Arrange
            var policy = new CamelCaseNamingPolicy();
            var input = "TestName";
            var expected = "testName";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleNullInput()
        {
            // Arrange
            var policy = new CamelCaseNamingPolicy();

            // Act
            var result = policy.ConvertName(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ConvertName_ShouldHandleEmptyString()
        {
            // Arrange
            var policy = new CamelCaseNamingPolicy();
            var input = string.Empty;
            var expected = string.Empty;

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleSingleWord()
        {
            // Arrange
            var policy = new CamelCaseNamingPolicy();
            var input = "Word";
            var expected = "word";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleMultipleWords()
        {
            // Arrange
            var policy = new CamelCaseNamingPolicy();
            var input = "MultipleWordsInString";
            var expected = "multipleWordsInString";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldNotChangeAlreadyCamelCase()
        {
            // Arrange
            var policy = new CamelCaseNamingPolicy();
            var input = "alreadyCamelCase";
            var expected = "alreadyCamelCase";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
