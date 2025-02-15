using MaskingStrings;

namespace MaskingStringsTests
{
    public class MaskingStringTests
    {
        [Theory]
        [InlineData("Hello world!!!", "!!!dlrow olleH")]
        [InlineData("������ ���!!!", "!!!��� ������")]
        [InlineData("���� ������ 17.10.2000","0002.01.71 ������ ����")]
        public void ReverseMaskingTest(string input, string result) => Assert.Equal(result, MaskingObject.ReverseMask(input));

        [Theory]
        [InlineData("Ivan Romanov 24345")]
        public void RandomMaskingNonParameterTest(string input) => Assert.NotEqual(input, MaskingObject.RandomMask(input, false));



    }
}