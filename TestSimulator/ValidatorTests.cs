using Simulator;
using Xunit;

namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5, 0, 10, 5)]
        [InlineData(15, 0, 10, 10)]
        [InlineData(-5, 0, 10, 0)]
        public void Limiter_Test(int value, int min, int max, int expected)
        {
            var result = Validator.Limiter(value, min, max);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("short", 5, 10, '#', "short")]
        [InlineData("  ", 3, 5, '#', "###")]
        [InlineData("hello", 3, 5, ' ', "hello")]
        [InlineData("too long", 5, 7, '#', "too lon")]
        [InlineData("long text", 5, 5, '#', "long ")]
        public void Shortener_Test(string input, int min, int max, char placeholder, string expected)
        {
            var result = Validator.Shortener(input, min, max, placeholder);
            Assert.Equal(expected, result);
        }
    }
}
