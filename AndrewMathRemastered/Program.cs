using System;
using System.Collections.Generic;

namespace AndrewMathRemastered
{
    class Program
    {

        static void Main(string[] args)
        {
            Random random = new Random();
            int a = 0, b = 0, c = 0, e = 0, correct = 0;
            int dump;
            char correctsymbol;
            List<string> responses = new List<string>();
            List<string> questions = new List<string>();
            void domath(string type, int donegatives)
            {
                correctsymbol = ' ';
                responses.Clear();
                a = random.Next(1, 50);
                if (donegatives == 1 || type != "sub")
                    b = random.Next(1, 50);
                if (type == "sub" &&  donegatives == 0)
                    while (b == 0 || b > a)
                        b = random.Next(1, 50);
                if (type == "add")
                    c = a + b;
                if (type == "sub")
                    c = a - b;

                getResponses(0, type);
                for (int d = 0; d <= 5;)
                {
                    if (int.TryParse(Console.ReadLine(), out dump))
                        if (c == dump)
                        {
                            correct++;
                            responses.Add(dump + "");
                            Console.Clear();
                            Console.WriteLine("You got it correct!");
                            correctsymbol = '✓';
                            getResponses(1, type);
                            break;
                        }
                        else
                        {
                            responses.Add(dump + "");
                            d++;
                            e++;
                            Console.Clear();
                            Console.WriteLine("You got it wrong. Try again.");
                            getResponses(0, type);
                        }
                    else
                    {
                        Console.Clear();
                        getResponses(0, type);
                    }
                }
                if (e > 3)
                {
                    Console.Clear();
                    getResponses(-1, type);
                    Console.WriteLine("You got it wrong!");
                    Console.WriteLine("The correct response was: {0}", c);
                }
                Console.WriteLine("Press any key to continue to the next question.");
                e = 0;
                Console.ReadKey();
                Console.Clear();
                questions.Add(correctsymbol + "     " + a + " + " + b + " = " + c);
            }
            void getResponses(int questionCorrect, string mathtype)
            {
                if (mathtype == "add")
                {
                    if (questionCorrect != 1)
                        Console.WriteLine("What is {0} + {1}", a, b);
                    if (questionCorrect == 1)
                        Console.WriteLine("{0} + {1} = {2}", a, b, c);
                }
                if (mathtype == "sub")
                {
                    if (questionCorrect != 1)
                        Console.WriteLine("What is {0} - {1}", a, b);
                    if (questionCorrect == 1)
                        Console.WriteLine("{0} - {1} = {2}", a, b, c);
                }
                Console.WriteLine("________________________________");
                Console.WriteLine("Responses:");
                for (int f = 0; f < responses.Count; f++)
                    Console.WriteLine("     " + responses[f]);
                if (responses.Count == 0)
                    Console.WriteLine("     None");
                Console.WriteLine("________________________________");
                if (questionCorrect == 0)
                    Console.Write("Response: ");
            }

            int MathType = 0, questionsAmount = 0, MathTypeStorage = 0;
            Console.Write("Addition (1), Subtraction (2), or Exit (3): ");
            while (MathType != 3)
            {
                if (int.TryParse(Console.ReadLine(), out MathTypeStorage))
                {
                    if ((MathTypeStorage + 2) / 3 == 1)
                        MathType = MathTypeStorage;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Addition (1), Subtraction (2), or Exit (3)");
                    Console.Write("Please input a valid answer: ");
                }
                if ((MathTypeStorage + 2) / 3 == 1 && MathTypeStorage != 3)
                {
                    Console.Write("How many questions? ");
                    while (questionsAmount == 0)
                        int.TryParse(Console.ReadLine(), out questionsAmount);
                }
                if (MathType == 1)
                {
                    for (int z = 1; z <= questionsAmount; z++)
                    {
                        domath("add", 0);
                    }
                    break;
                }
                dump = 0;
                if (MathType == 2)
                {
                    while (dump != 2)
                    {
                        Console.Write("Are negatives allowed? Yes (1) or No (0): ");
                        if (int.TryParse(Console.ReadLine(), out dump) && (dump == 0 | dump == 1))
                        {
                            for (int z = 1; z <= questionsAmount; z++)
                            {
                                domath("sub", dump);
                                dump = 2;
                            }
                        }
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("You have finished all the question(s).");
            Console.WriteLine("Questions:");
            for (int y = 0; y < questions.Count; y++)
            {
                Console.WriteLine("     " + questions[y]);
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("You got {0}/{1} right.", correct, questionsAmount);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
