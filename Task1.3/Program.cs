using System;

namespace Task1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Input(out string input);
                ConvertToStringArray(input, out string[] words);
                Print(words);
            }
        }

        static void Input(out string input)
        {
            Console.WriteLine("Введите какие-нибудь слова через пробел");
            input = Console.ReadLine().Trim().ToUpper();
        }

        static void ConvertToStringArray(string input, out string[] words)
        {
            input = input.Insert(input.Length, " ");
            int numberOfSpaces = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    numberOfSpaces++;
                }
            }
            words = new string[numberOfSpaces];
            int j = 0;

            while (input.Length != 0)
            {
                char[] word = new char[input.IndexOf(' ')];
                for (int i = 0; i < input.IndexOf(' '); i++)
                {
                    word[i] = input[i];
                }
                words[j] = new string(word);
                j++;
                input = input.Substring(input.IndexOf(' ') + 1);
            }
        }

        static void Print(string[] words)
        {
            Array.Sort(words);
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
