namespace EfCore.NamingConverter.Tests
{
    public class SnakeCaseLowerNamingPolicyTests
    {
        [Fact]
        public void ConvertName_ShouldConvertToSnakeCaseLower()
        {
            // Arrange
            var policy = new SnakeCaseLowerNamingPolicy();
            var input = "TestName";
            var expected = "test_name";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldThrowArgumentNullExceptionOnNullInput()
        {
            // Arrange
            var policy = new SnakeCaseLowerNamingPolicy();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => policy.ConvertName(null));
        }

        [Fact]
        public void ConvertName_ShouldHandleEmptyString()
        {
            // Arrange
            var policy = new SnakeCaseLowerNamingPolicy();
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
            var policy = new SnakeCaseLowerNamingPolicy();
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
            var policy = new SnakeCaseLowerNamingPolicy();
            var input = "MultipleWordsInString";
            var expected = "multiple_words_in_string";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleSpaces()
        {
            // Arrange
            var policy = new SnakeCaseLowerNamingPolicy();
            var input = "Multiple Words In String";
            var expected = "multiple_words_in_string";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleNonAlphanumericCharacters()
        {
            // Arrange
            var policy = new SnakeCaseLowerNamingPolicy();
            var input = "Test@Name#With$Special%Characters";
            var expected = "test@name#with$special%characters";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
