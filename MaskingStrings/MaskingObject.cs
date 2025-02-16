using System.Net.Http.Headers;
using System.Text;

namespace MaskingStrings
{
    public class MaskingObject
    {
        static readonly char[] charsMask =
            "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
        static readonly Dictionary<char, byte> parametersForMask = new Dictionary<char, byte>();

        public static string ReverseMask(string inputString)
        {
            string maskString = "";
            
            for(int i = inputString.Length - 1; i >= 0; i--)
            {
                maskString += inputString[i];
            }

            return maskString;
        }

        public static string RandomSwapMask(string inputString)
        {
            char temp;
            char[] buffer = inputString.ToCharArray();
            int position;
            Random random = new Random();

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == ' ') continue;

                do
                {
                    position = random.Next(buffer.Length);
                } while (buffer[position] == ' ');

                temp = buffer[position];
                buffer[position] = buffer[i];
                buffer[i] = temp;

            }
            return new string(buffer);
        }

        public static string RandomMask(string inputString, bool predictable)
        {
            Random random = new();
            byte[] maskForString = new byte[inputString.Length];


            for (int i = 0; i < maskForString.Length; i++)
            {
                if (IsCorrect(inputString[i]))
                {
                    if (predictable)
                    {
                        if (!parametersForMask.ContainsKey(inputString[i])) AddNewParameter(inputString[i]);

                        maskForString[i] = parametersForMask[inputString[i]];
                    }
                    else maskForString[i] = (byte)random.Next(33, 127);
                }
                else maskForString[i] = Convert.ToByte(inputString[i]);


            }

            return Encoding.ASCII.GetString(maskForString);
        }

        private static bool IsCorrect(char inputChar) => !(inputChar == ' ' || inputChar == '\t' || inputChar == '\n' || inputChar == '\v');

        private static void AddNewParameter(char token)
        {
            Random random = new Random();
            byte parameter = (byte)random.Next(1, 20);
            byte tokenMask;

            if (Array.IndexOf(charsMask, token) != -1)
            {
                tokenMask = (byte)(33 + Array.IndexOf(charsMask, token));
            }
            else tokenMask = (byte)(Convert.ToByte(token) + parameter);

            if (tokenMask > 127) tokenMask = (byte)(33 + tokenMask - 127);

            parametersForMask.Add(token, tokenMask);

        }
    }
}
