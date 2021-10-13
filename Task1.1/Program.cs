using System;

namespace Task1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Нажмите какую-нибудь клавишу");
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo input = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Вы нажали на клавишу:\t" + input.KeyChar);
                Console.WriteLine("Её код в 16-ричном формате 0x1234:\t 0x{0:X4}", (int)input.KeyChar);
                Console.WriteLine();
            }
        }
    }
}

