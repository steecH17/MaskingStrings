namespace MaskingStrings
{
    public class MaskingObject
    {
        public static string ReverseMask(string inputString)
        {
            string maskString = "";
            
            for(int i = inputString.Length - 1; i >= 0; i--)
            {
                maskString += inputString[i];
            }

            return maskString;
        }
    }
}
