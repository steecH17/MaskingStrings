using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MaskingStrings
{
    public abstract class MaskingObject
    {
        public string MaskingData(object inputData)
        {
            string inputString = TypeConverterToString(inputData);
            string maskString = MaskingAlgorithm(inputString);
            return maskString;
        }
       
        public string[] MaskingData(object[] inputData)
        {
            string[] maskStrings = new string[inputData.Length];
            for(int i = 0; i < inputData.Length; i++)
            {
                maskStrings[i] = MaskingData(inputData[i]);
            }
            return maskStrings;
        }
        protected abstract string MaskingAlgorithm(string inputString);
        private string TypeConverterToString(object data)
        {
            string dataString = "";
            if (data is System.String) dataString = (string)data;
            else if (data is Int32) dataString = data.ToString();
            else if (data is DateTime) dataString = data.ToString();

            else
            {
                throw new Exception("Неверный тип входных данных! Тип данных для работы с данным методом : String, DateTime, Int32.");
            }

            return dataString;
        }
    }
}
