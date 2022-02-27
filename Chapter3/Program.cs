using System;

namespace Chapter3
{
    public class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine(stack.FindDupes() ? "There are duplicates in the stack" : "There are no duplicates in the stack");



        }

        class Stack
        {
            protected int size = 1000;
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

            public int pop(int value)
            {
                int val;

                if(top >= 0)
                {
                    val = stack[top];
                    top--;
                    return val;
                }
                else 
                    return -1;
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
        }
    }
}