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
        
        public void ReverseMaskingTest(object input, string result) => Assert.Equal(result, new ReverseMasking().MaskingData(input));

        [Theory]
        [InlineData("Ivan Romanov 24345")]
        [InlineData("34578 ���������� - ��������")]
        [InlineData(12345898)]
        public void RandomMaskingNonParameterTest(object input) => Assert.NotEqual(input, new RandomMasking(false).MaskingData(input));

        [Theory]
        [InlineData("Dmitriy Solodov 12/12/2000")]
        [InlineData("������ �������� 12.10.1990 - �������")]
        [InlineData(34357)]
        public void RandomMaskingParameterTest(object input) => Assert.Equal(new RandomMasking(true).MaskingData(input), new RandomMasking(true).MaskingData(input));
        

        [Theory]
        [InlineData(new object[] { 42, "Hello World" }, "")]
        public void RandomMaskingForObjectArrayTest(object[] input, string p)
        {
            string[] result1 = new RandomMasking(true).MaskingData(input);
            string[] result2 = new RandomMasking(true).MaskingData(input);
            Assert.Equal(result1, result2);

        }

        [Theory] 
        [InlineData(new object[] { 42, "Hello World"}, "24", "dlroW olleH")]
        public void ReverseMaskingForObjectArrayTest(object[] input,string result1, string result2)
        {
            string[] result = new ReverseMasking().MaskingData(input);
            Assert.Equal(result1, result[0]);
            Assert.Equal(result2, result[1]);
        }

        [Theory]
        [InlineData(null)]
        [InlineData('a')]
        public void ReverseExceptionsTest(object input) => Assert.Throws<Exception>(() => new ReverseMasking().MaskingData(input));

        [Theory]
        [InlineData(null)]
        [InlineData('a')]
        public void SwapExceptionsTest(object input) => Assert.Throws<Exception>(() => new SwapMasking().MaskingData(input));

        [Theory]
        [InlineData(null)]
        [InlineData('a')]
        public void RandomExceptionsTest(object input) => Assert.Throws<Exception>(() => new RandomMasking(false).MaskingData(input));

        



    }
}