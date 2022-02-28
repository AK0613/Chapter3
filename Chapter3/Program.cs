using System;
using System.Collections.Generic;

namespace Chapter3
{
    public class Program
    {
        static void Main(string[] args)
        {

            string choice;
            int problem;

            Console.WriteLine("Problems from the book. Chapter 1");

            do
            {
                problem = Menu();
                switch (problem)
                {
                    case 1:
                        P1();
                        break;
                    case 2:
                        P2();
                        break;
                    case 3:
                        P3();
                        break;
                        /*case 5:
                            p5();
                            break;
                        case 6:
                            p6();
                            break;
                        case 7:
                            p7();
                            break;
                        case 8:
                            p8();
                            break;
                        case 9:
                            p9();
                            break;*/
                }


                Console.WriteLine("Would you like to try another problem? (Enter y or Y to proceed)");
                choice = Console.ReadLine();

            } while (choice == "y" || choice == "Y");




        }

        private static int Menu()
        {
            string input;
            int problem;
            bool valid;

            Console.Clear();
            Console.WriteLine("Problem 1: Implement a stack using an array. Test push//pop/peek/print\n" +
                "Problem 2: Write a method to determine if there are duplicates in the stack\n" +
                "Problem 3: Write a method that find if there is a missing number in a sequence stored in a stack\n");

            do
            {
                Console.WriteLine("Please enter a number to select a problem: ");
                input = Console.ReadLine();
                valid = int.TryParse(input, out problem);
                if (!valid || problem > 10 || problem < 0)
                {
                    Console.WriteLine("Invalid input. You entered {0}", input);
                }

            } while (!valid || problem > 10 || problem < 0);

            return problem;

        }

        #region Problems

        static public void P1()
        {
            Stack stack = new();

            stack.push(15);
            stack.peek();
            stack.push(25);
            stack.push(16);
            stack.push(18);
            stack.push(11);
            stack.push(32);
            stack.push(49);
            stack.push(197);
            stack.print();
            stack.pop();
            stack.pop();
            stack.pop();
            stack.pop();
            stack.pop();
            stack.pop();
            stack.pop();
            stack.pop();
            stack.pop();
            stack.pop();
            stack.print();
        }

        static public void P2()
        {
            Stack stack = new();

            stack.push(15);
            stack.push(15);
            stack.push(16);
            stack.push(16);
            stack.push(11);
            stack.push(32);
            stack.push(32);
            stack.push(197);
            Console.WriteLine(stack.FindDupes() ? "There are duplicates in the stack" : "There are no duplicates in the stack");
        }

        static void P3()
        {
            Stack stack = new();

            int x = 5, y = 6, z = 7;

            for(int i = 1; i <=20; i++)
            {
                if(i != x && i != y && i != z)
                {
                    stack.push(i);
                }
            }

            stack.print();

            Console.WriteLine(stack.FindMissing() ? "There are missing numbers" : "There are no missing numbers");
        }

        #endregion

        #region Stack Class
        class Stack
        {
            private const int size = 1000;
            private int[] stack;
            private int top; 
            public Stack()
            {
                stack = new int[size];
                top = 0;
            }

            public bool push( int value)
            {
                if (top <size)
                {
                    stack[top] = value;
                    top++;
                    return true;
                }
                else
                    return false;
            }

            public int pop()
            {
                int val;

                if (top >= 0)
                {
                    val = stack[top];
                    top--;
                    return val;
                }
                else
                { 
                    Console.WriteLine("The stack is empty");
                    return -1;
                }
            }

            public void peek()
            {
                Console.WriteLine("The value at the top of the stack is: " + stack[top - 1]);
            }

            public void print()
            {
                Console.WriteLine("The elements in the stack are: ");
                for(int i = 0; i < top; i++)
                {
                    Console.WriteLine(stack[i]);
                }
            }

            public bool FindDupes()
            {
                bool dupes = false;
                for (int i = 0; i < top; i++)
                {
                    if (stack[i] == stack[i + 1])
                    {
                        dupes = true;
                        return dupes;
                    }
                }
                return dupes;
            }

            public bool FindMissing()
            {
                Dictionary<int, int> missing = new();
                
                bool flag = false;

                for (int i = 0; i < top -1; i++)
                {
                    //Get difference between i and i+1 if greater than 1 (missing numbers) then we add all numbers from i to n to the dictionary
                    int dif = stack[i + 1] - stack[i];
                    Console.WriteLine(dif);
                    if (dif > 1)
                    {
                        flag = true;
                        int count = 1;
                        int misNum = stack[i] + 1;

                        while (count != dif)
                        {
                            if(missing.TryGetValue(misNum, out int val))
                                missing[misNum] = val + 1;
                            else
                                missing.Add(misNum, 1);
                            
                            count++;
                            misNum++;
                        }
                    }
                }
                if (flag)
                {
                    Console.Write("The missing number(s) is/are: ");
                    foreach( var x in missing)
                        Console.WriteLine(x);
                }

                return flag;
            }
        }
    }
    #endregion
}