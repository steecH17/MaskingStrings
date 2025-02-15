using MaskingStrings;

namespace MaskingStringsTests
{
    public class MaskingStringTests
    {
        [Theory]
        [InlineData("Hello world!!!", "!!!dlrow olleH")]
        public void ReverseMaskingTest(string input, string result) => Assert.Equal(result, MaskingObject.ReverseMask(input));

    }
}