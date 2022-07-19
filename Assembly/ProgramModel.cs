using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class ProgramModel
    {
        static void Main(string[] args)
        {
            var number = 5;
            var result = Square(number);
            Console.WriteLine($"Квадрат {number} равен {result}");
        }
        static int Square(int n) => n * n;
    }
}
