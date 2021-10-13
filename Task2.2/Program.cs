
using System;
using System.Text;

namespace Task2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(Input());
        }

        static string[,] LowerLetter = new string[,] {
            { "а", "a" },
            { "б", "b" },
            { "в", "v" },
            { "г", "g" },
            { "д", "d" },
            { "е", "e" },
            { "ё", "yo" },
            { "ж", "zh" },
            { "з", "z" },
            { "и", "i" },
            { "й", "j" },
            { "к", "k" },
            { "л", "l" },
            { "м", "m" },
            { "н", "n" },
            { "о", "o" },
            { "п", "p" },
            { "р", "r" },
            { "с", "s" },
            { "т", "t" },
            { "у", "u" },
            { "ф", "f" },
            { "х", "h" },
            { "ц", "c" },
            { "ч", "ch" },
            { "ш", "sh" },
            { "щ", "shh" },
            { "ъ", "``" },
            { "ы", "y`" },
            { "ь", "`" },
            { "э", "e`" },
            { "ю", "yu" },
            { "я", "ya" }
        };
        static string[,] UpperLetter = new string[,] {
            { "А", "A" },
            { "Б", "B" },
            { "В", "V" },
            { "Г", "G" },
            { "Д", "D" },
            { "Е", "E" },
            { "Ё", "YO" },
            { "Ж", "ZH" },
            { "З", "Z" },
            { "И", "I" },
            { "Й", "J" },
            { "К", "K" },
            { "Л", "L" },
            { "М", "M" },
            { "Н", "N" },
            { "О", "O" },
            { "П", "P" },
            { "Р", "R" },
            { "С", "S" },
            { "Т", "T" },
            { "У", "U" },
            { "Ф", "F" },
            { "Х", "H" },
            { "Ц", "C" },
            { "Ч", "CH" },
            { "Ш", "SH" },
            { "Щ", "SHH" },
            { "Ъ", "``" },
            { "Ы", "Y`" },
            { "Ь", "`" },
            { "Э", "E`" },
            { "Ю", "YU" },
            { "Я", "YA" }
        };

        static string Input()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Введите текст для транслитерации");
            return Console.ReadLine();
        }

        static string Translit(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(Letter(input[i].ToString()));
            }
            return sb.ToString();
        }

        static string Letter(string letter)
        {
            for (int i = 0; i < 33; i++)
            {
                if (letter.ToString() == UpperLetter[i, 0])
                {
                    letter = UpperLetter[i, 1];
                }
                if (letter.ToString() == LowerLetter[i, 0])
                {
                    letter = LowerLetter[i, 1];
                }
            }
            return letter;
        }
        static void Print(string input)
        {
            Console.WriteLine("Ваш текст после транслитерации:");
            Console.WriteLine(Translit(input));
        }
    }
}