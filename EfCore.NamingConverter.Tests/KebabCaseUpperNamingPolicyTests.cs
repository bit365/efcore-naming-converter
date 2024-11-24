namespace EfCore.NamingConverter.Tests
{
    public class KebabCaseUpperNamingPolicyTests
    {
        [Fact]
        public void ConvertName_ShouldConvertToKebabCaseUpper()
        {
            // Arrange
            var policy = new KebabCaseUpperNamingPolicy();
            var input = "TestName";
            var expected = "TEST-NAME";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldThrowArgumentNullException()
        {
            // Arrange
            var policy = new KebabCaseUpperNamingPolicy();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => policy.ConvertName(null));
        }

        [Fact]
        public void ConvertName_ShouldHandleEmptyString()
        {
            // Arrange
            var policy = new KebabCaseUpperNamingPolicy();
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
            var policy = new KebabCaseUpperNamingPolicy();
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
            var policy = new KebabCaseUpperNamingPolicy();
            var input = "MultipleWordsInString";
            var expected = "MULTIPLE-WORDS-IN-STRING";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}