using System.Text;
using System;

namespace SmartHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Menu menu = new Menu();
            menu.Options();
        }
    }
}
