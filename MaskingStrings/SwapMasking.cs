using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskingStrings
{
    public class SwapMasking : MaskingObject
    {
        protected override string MaskingAlgorithm(string inputString)
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
    }
}
