using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskingStrings
{
    public class ReverseMasking : MaskingObject
    {
        protected override string MaskingAlgorithm(string inputString)
        {
            string maskString = "";

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                maskString += inputString[i];
            }

            return maskString;
        }
    }
}
