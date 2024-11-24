namespace EfCore.NamingConverter.Tests
{
    public class SnakeCaseUpperNamingPolicyTests
    {
        [Fact]
        public void ConvertName_ShouldConvertToSnakeCaseUpper()
        {
            // Arrange
            var policy = new SnakeCaseUpperNamingPolicy();
            var input = "TestName";
            var expected = "TEST_NAME";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldThrowArgumentNullException()
        {
            // Arrange
            var policy = new SnakeCaseUpperNamingPolicy();
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => policy.ConvertName(null));
        }

        [Fact]
        public void ConvertName_ShouldHandleEmptyString()
        {
            // Arrange
            var policy = new SnakeCaseUpperNamingPolicy();
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
            var policy = new SnakeCaseUpperNamingPolicy();
            var input = "Word";
            var expected = "WORD";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleMultipleWords()
        {
            // Arrange
            var policy = new SnakeCaseUpperNamingPolicy();
            var input = "MultipleWordsInString";
            var expected = "MULTIPLE_WORDS_IN_STRING";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleSpaces()
        {
            // Arrange
            var policy = new SnakeCaseUpperNamingPolicy();
            var input = "Multiple Words In String";
            var expected = "MULTIPLE_WORDS_IN_STRING";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleNonAlphanumericCharacters()
        {
            // Arrange
            var policy = new SnakeCaseUpperNamingPolicy();
            var input = "Test@Name#With$Special%Characters";
            var expected = "TEST@NAME#WITH$SPECIAL%CHARACTERS";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}