using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskingStrings
{
    public class RandomMasking(bool predictable) : MaskingObject
    {
        private bool _predictable = predictable; //Отвечает за предсказуемость маскировки true - одинаковые результаты, false - произвольные результаты
        static readonly char[] charsMask =
            "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();

        static readonly Dictionary<char, byte> parametersForMask = new Dictionary<char, byte>();

        protected  override string MaskingAlgorithm(string inputString)
        {
            Random random = new();
            byte[] maskForString = new byte[inputString.Length];


            for (int i = 0; i < maskForString.Length; i++)
            {
                if (IsCorrect(inputString[i]))
                {
                    if (_predictable)
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

        /*
          Метод генерирует рандомный символ(маску) в пару к символам встречаемым во входных данных
          То есть по сути создает алфавит маскирования(parametersForMask)
         */
        private static void AddNewParameter(char token)
        {
            Random random = new Random();
            byte parameter = (byte)random.Next(1, 20);
            byte tokenMask;

            if (Array.IndexOf(charsMask, token) != -1) //Проверка на кириллицу
            {
                tokenMask = (byte)(33 + Array.IndexOf(charsMask, token));
            }
            else tokenMask = (byte)(Convert.ToByte(token) + parameter);

            if (tokenMask > 127) tokenMask = (byte)(33 + tokenMask - 127);

            parametersForMask.Add(token, tokenMask);

        }
    }
}
