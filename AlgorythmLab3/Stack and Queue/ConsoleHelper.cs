using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    public class ConsoleHelper
    {
        private static int FrameLength = 3;
        private static int CursorTop = 0;

        private static void DefineLength(IStorable<object> structure)
        {
            foreach (var item in structure)
            {
                FrameLength = Math.Max(FrameLength, item.ToString().Length);
            }
        }

        public static void PrintOldStructure(IStorable<object> structure, bool isNotOnlyPrint)
        {
            CursorTop = Console.CursorTop;
            if(isNotOnlyPrint)
            {
                Console.WriteLine("Старое:");
            }
            DefineLength(structure);
            StringBuilder sb = new();
            foreach (var item in structure)
            {
                AddFrame(item, sb);
            }
            Console.WriteLine(sb.ToString());
            Console.Write("\r\n\r\n\r\n");
            Console.WriteLine("----------------------------------------------------");
            FrameLength = 3;
        }

        public static void PrintNewStructure(IStorable<object> structure)
        {
            Console.CursorTop = CursorTop;
            Console.CursorLeft = 20;
            Console.WriteLine("Новое:");
            DefineLength(structure);
            StringBuilder sb = new();
            foreach (var item in structure)
            {
                AddFrame(item, sb);
            }
            Console.CursorTop = CursorTop + 1;
            foreach (string str in sb.ToString().Split("\r\n"))
            {
                Console.CursorLeft = 20;
                Console.WriteLine(str);
            }
            Console.WriteLine();
            FrameLength = 3;
        }

        public static void AddFrame(object item, StringBuilder sb)
        {
            sb.Append(new string('-', FrameLength + 2) + "\r\n");

            sb.Append($"|{new string(' ', FrameLength / 2 - item.ToString().Length / 2)}" +
                $"{item}" +
                $"{new string(' ', FrameLength / 2 - item.ToString().Length / 2)}|" + "\r\n");

            sb.Append(new string('-', FrameLength + 2) + "\r\n");
        }
    }
}
