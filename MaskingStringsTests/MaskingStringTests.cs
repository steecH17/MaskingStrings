using MaskingStrings;

namespace MaskingStringsTests
{
    public class MaskingStringTests
    {
        [Theory]
        [InlineData("Hello world!!!", "!!!dlrow olleH")]
        [InlineData("Привет мир!!!", "!!!рим тевирП")]
        [InlineData("Иван Иванов 17.10.2000","0002.01.71 вонавИ навИ")]
        public void ReverseMaskingTest(string input, string result) => Assert.Equal(result, MaskingObject.ReverseMask(input));

        [Theory]
        [InlineData("Ivan Romanov 24345")]
        [InlineData("34578 Владимиров - менеджер")]
        public void RandomMaskingNonParameterTest(string input) => Assert.NotEqual(input, MaskingObject.RandomMask(input, false));

        [Theory]
        [InlineData("Dmitriy Solodov 12/12/2000")]
        [InlineData("Никита Мастюгин 12.10.1990 - инженер")]
        public void RandomMaskingParameterTest(string input)
        {
            Assert.Equal(MaskingObject.RandomMask(input, true), MaskingObject.RandomMask(input, true));
        }



    }
}