using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> square = new List<double>();
            int evenCount = 0, oddCount = 0;
            for (int x = 1; x < 21; x++)
            {
                double value = Math.Pow(x, 2);
                square.Add(value);
            }
            Console.WriteLine("List of first 20 square numbers : ");

            var even = from sq in square where sq % 2 == 0 select sq;
            var odd = from sq in square where sq % 2 != 0 select sq;

            foreach (var item in square)
            {
                Console.Write("{0} ", item);

            }
            Console.WriteLine();

            Console.WriteLine("List of Even numbers : \n");
            foreach (var item in even)
            {
                Console.Write("{0} ", item);
                evenCount++;
            }
            Console.WriteLine();

            Console.WriteLine("Amount of even square numbers is : {0} ", evenCount);
            Console.WriteLine("Total value for even square numbers is : {0} ", even.Sum());
            Console.WriteLine("Average value for even square numbers is : {0} ", even.Average());
            Console.WriteLine("Minimum value for even square numbers is : {0} ", even.Min());
            Console.WriteLine("Maximum value for even square numbers is : {0} ", even.Max());
                                   
            Console.WriteLine();
            //////////////////////////////////ODD/////////////////////////////////////////////////////////////////////////

            Console.WriteLine("List of odd numbers : \n");
            foreach (var item in odd)
            {
                Console.Write("{0} ", item);
                oddCount++;

            }
            Console.WriteLine();
            Console.WriteLine("Amount of odd square numbers is : {0} ", oddCount);
            Console.WriteLine("Total value for odd square numbers is : {0} ", odd.Sum());
            Console.WriteLine("Average value for odd square numbers is : {0} ", odd.Average());
            Console.WriteLine("Minimum value for odd square numbers is : {0} ", odd.Min());
            Console.WriteLine("Maximum value for odd square numbers is : {0} ", odd.Max());

            Console.Read();
        }
    }
}
