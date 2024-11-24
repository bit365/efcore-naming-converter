namespace EfCore.NamingConverter.Tests
{
    public class KebabCaseLowerNamingPolicyTests
    {
        [Fact]
        public void ConvertName_ShouldConvertToKebabCaseLower()
        {
            // Arrange
            var policy = new KebabCaseLowerNamingPolicy();
            var input = "TestName";
            var expected = "test-name";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldThrowOnNullInput()
        {
            // Arrange
            var policy = new KebabCaseLowerNamingPolicy();

            // Act
            void action() => policy.ConvertName(null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void ConvertName_ShouldHandleEmptyString()
        {
            // Arrange
            var policy = new KebabCaseLowerNamingPolicy();
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
            var policy = new KebabCaseLowerNamingPolicy();
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
            var policy = new KebabCaseLowerNamingPolicy();
            var input = "MultipleWordsInString";
            var expected = "multiple-words-in-string";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
