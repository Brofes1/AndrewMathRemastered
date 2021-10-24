using System;
using System.Collections.Generic;

namespace AndrewMathRemastered
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int a, b, c, e = 0, h = 0;
            int dump;
            List<string> responses = new List<string>();

            a = random.Next(1, 50);
            b = random.Next(1, 50);
            c = a + b;

            Console.WriteLine("What is {0} + {1}", a, b);
            Console.Write("Response: ");
            for (int d = 0; d <= 5;)
            {
                if (int.TryParse(Console.ReadLine(), out dump))
                    if (c == dump)
                    {
                        Console.WriteLine("You got it correct!");
                        break;
                    }
                    else
                    {
                        responses.Add(dump + "");
                        d++;
                        e++;
                        Console.Clear();
                        Console.WriteLine("You got it wrong. Try again.");
                        getResponses();
                        Console.Write("Response: ");
                    }
                else
                {
                    Console.Clear();
                    getResponses();
                    Console.Write("Response: ");
                }
            }
            if (e > 3)
                Console.Clear();
            getResponses();
            Console.WriteLine("You lose!");
            Console.WriteLine("The correct response was: {0}", c);
            Console.ReadKey();

            void getResponses()
            {
                Console.WriteLine("What is {0} + {1}", a, b);
                Console.WriteLine("________________________________");
                Console.WriteLine("Responses:");
                for (int f = 0; f < responses.Count;)
                {
                    Console.WriteLine("     " + responses[f]);
                    f++;
                    h++;
                }
                if (h == 0)
                    Console.WriteLine("     None");
                Console.WriteLine("________________________________");
            }
        }
    }
}