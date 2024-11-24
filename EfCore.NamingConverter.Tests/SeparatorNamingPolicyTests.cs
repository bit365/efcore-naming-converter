namespace EfCore.NamingConverter.Tests
{
    public class SeparatorNamingPolicyTests
    {
        private class TestSeparatorNamingPolicy(bool lowercase, char separator) : SeparatorNamingPolicy(lowercase, separator)
        {
        }

        [Fact]
        public void ConvertName_ShouldConvertToLowercaseWithSeparator()
        {
            // Arrange
            var policy = new TestSeparatorNamingPolicy(lowercase: true, separator: '-');
            var input = "TestName";
            var expected = "test-name";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldConvertToUppercaseWithSeparator()
        {
            // Arrange
            var policy = new TestSeparatorNamingPolicy(lowercase: false, separator: '-');
            var input = "TestName";
            var expected = "TEST-NAME";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleNullInput()
        {
            // Arrange
            var policy = new TestSeparatorNamingPolicy(lowercase: true, separator: '-');

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => policy.ConvertName(null));
        }

        [Fact]
        public void ConvertName_ShouldHandleEmptyString()
        {
            // Arrange
            var policy = new TestSeparatorNamingPolicy(lowercase: true, separator: '-');
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
            var policy = new TestSeparatorNamingPolicy(lowercase: true, separator: '-');
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
            var policy = new TestSeparatorNamingPolicy(lowercase: true, separator: '-');
            var input = "MultipleWordsInString";
            var expected = "multiple-words-in-string";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleSpaces()
        {
            // Arrange
            var policy = new TestSeparatorNamingPolicy(lowercase: true, separator: '-');
            var input = "Multiple Words In String";
            var expected = "multiple-words-in-string";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleNonAlphanumericCharacters()
        {
            // Arrange
            var policy = new TestSeparatorNamingPolicy(lowercase: true, separator: '-');
            var input = "Test@Name#With$Special%Characters";
            var expected = "test@name#with$special%characters";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}