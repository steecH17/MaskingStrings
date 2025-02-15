using System.Text;

namespace MaskingStrings
{
    public class MaskingObject
    {
        static readonly char[] charsMask =
            "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();

        public static string ReverseMask(string inputString)
        {
            string maskString = "";
            
            for(int i = inputString.Length - 1; i >= 0; i--)
            {
                maskString += inputString[i];
            }

            return maskString;
        }

        public static string RandomMask(string inputString, bool predictable)
        {
            Random random = new();
            byte[] maskForString = new byte[inputString.Length];
            byte parameter = 10;


            for (int i = 0; i < maskForString.Length; i++)
            {
                if (!(inputString[i] == ' ' || inputString[i] == '\t' || inputString[i] == '\n' || inputString[i] == '\v'))
                {
                    if (predictable)
                    {
                        if (Array.IndexOf(charsMask, inputString[i]) != -1)
                        {
                            maskForString[i] = (byte)(33 + Array.IndexOf(charsMask, inputString[i]));
                        }
                        else if ((byte)(Convert.ToByte(inputString[i]) + parameter) > 127)
                        {
                            maskForString[i] = (byte)(33 + (byte)(Convert.ToByte(inputString[i]) + parameter) - 127);
                        }
                        else maskForString[i] = (byte)(Convert.ToByte(inputString[i]) + parameter);
                    }
                    else maskForString[i] = (byte)random.Next(33, 127);
                }
                else maskForString[i] = Convert.ToByte(inputString[i]);


            }

            return Encoding.ASCII.GetString(maskForString);
        }
    }
}
