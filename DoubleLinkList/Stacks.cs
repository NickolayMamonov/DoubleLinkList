using System;
using System.Collections.Generic;

namespace DoubleLinkList
{
    public class Stacks
    {
        public static void Works()
        {
            Console.WriteLine("Добавление элемента:");
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 15; i++)
            {
                int value = new Random().Next(1, 100);
                Console.Write(value + " ");
                stack.Add(value);
            }
            Console.WriteLine('\n');

            foreach (var ele in stack)
            {
                Console.Write($"{ele} ");
            }

            stack.Remove();
            Console.WriteLine($"\nУдаление элемента:");

            foreach (var ele in stack)
            {
                Console.Write($"{ele} ");
            }
            Console.Write("\n");
        }
    }
}