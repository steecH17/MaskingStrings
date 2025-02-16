using MaskingStrings;

namespace MaskingStringsTests
{
    public class MaskingStringTests
    {
        [Theory]
        [InlineData("Hello world!!!", "!!!dlrow olleH")]
        [InlineData("������ ���!!!", "!!!��� ������")]
        [InlineData("���� ������ 17.10.2000","0002.01.71 ������ ����")]
        [InlineData(12345, "54321")]
        
        public void ReverseMaskingTest(object input, string result) => Assert.Equal(result, MaskingObject.ReverseMask(input));

        [Theory]
        [InlineData("Ivan Romanov 24345")]
        [InlineData("34578 ���������� - ��������")]
        [InlineData(12345898)]
        public void RandomMaskingNonParameterTest(object input) => Assert.NotEqual(input, MaskingObject.RandomMask(input, false));

        [Theory]
        [InlineData("Dmitriy Solodov 12/12/2000")]
        [InlineData("������ �������� 12.10.1990 - �������")]
        [InlineData(34357)]
        public void RandomMaskingParameterTest(object input)
        {
            Assert.Equal(MaskingObject.RandomMask(input, true), MaskingObject.RandomMask(input, true));
        }



    }
}