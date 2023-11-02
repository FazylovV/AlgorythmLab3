using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    public class Measurements
    {
        public static readonly string SavePath = "C:\\test";

        public static Data RequestTheData(string plotName, IExecutable clas, bool isNeedToCreateData, string[] input)
        {
            int variablesCount = Int32.Parse(input[0]);
            int steps = Int32.Parse(input[1]);
            int testsCount = Int32.Parse(input[2]);

            if (isNeedToCreateData)
            {
                CreateData(variablesCount, steps);
            }

            return MeasureTheTime(clas, variablesCount, testsCount, steps, plotName);
        }

        private static void CreateData(int variablesCount, int steps)
        {
            StringBuilder sb = new();
            for (int i = 0; i < variablesCount; i += steps)
            {
                sb.Append(Input.CreateInput(steps)).Append(" ");
                string result = sb.ToString();
                Program.Inputs.Add(result.Trim());
            }
        }

        public static string[] RequestUserInput()
        {
            Console.WriteLine($"Введите максимальный размер входных данных, шаг и количество проверок(через одиночные пробелы)");

            string[] input = Console.ReadLine().Split(" ");
            while(!IsInputCorrect(input))
            {
                Console.WriteLine("Некоректный ввод, попробуйте снова");
                input = Console.ReadLine().Split(" ");
            }

            return input;
        }
        private static bool IsInputCorrect(string[] input)
        {
            if (input.Count() != 3)
            {
                return false;
            }
            foreach (string s in input)
            {
                if (Int32.TryParse(s, out int _) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private static Data MeasureTheTime(IExecutable clas , int variablesCount, int testsCount, int steps, string plotName)
        {
            long[] timeNotes = new long[testsCount];
            List<double> doubleTimeNotes = new();
            List<double> stepList = new();
            for (int i = 1; i <= Program.Inputs.Count; i++)
            {
                for (int j = 0; j < testsCount; j++)
                {
                    timeNotes[j] = clas.Execute(i - 1);
                }
                stepList.Add(i * steps);
                long avarageTime = timeNotes.Sum() / testsCount;
                doubleTimeNotes.Add(avarageTime);
            }
            return new Data(stepList, doubleTimeNotes, plotName);
        }

        public static long ProcessInput(string input, IStorable<object> storable)
        {
            string[] operations = input.Split(" ");

            Stopwatch timer = new();
            Console.WriteLine($"Число операций: {operations.Length}");
            timer.Start();
            foreach (string s in operations)
            {
                switch (s[0])
                {
                    case '1':
                        /*timer.Stop();
                        Console.WriteLine($"Добавлен элемент {s.Split(",")[1]}");
                        ConsoleHelper.PrintOldStructure(storable, true);
                        timer.Start();*/
                        storable.Push(s.Split(",")[1]);
                        
                        /*timer.Stop();
                        Console.WriteLine("Добавлен новый элемент");
                        timer.Start();*/

                        /*timer.Stop();
                        ConsoleHelper.PrintNewStructure(storable);
                        timer.Start();*/
                        break;
                    case '2':
                        /*timer.Stop();
                        Console.WriteLine($"Извлечён элемент {storable.Top()}");
                        ConsoleHelper.PrintOldStructure(storable, true);
                        timer.Start();*/
                        storable.Pop();
                        
                        /*timer.Stop();
                        Console.WriteLine("Извлечён элемент");
                        timer.Start();*/

                        /*timer.Stop();
                        ConsoleHelper.PrintNewStructure(storable);
                        Console.Write("\r\n\r\n\r\n");
                        Console.Write("\r\n\r\n\r\n");
                        timer.Start();*/
                        break;
                    case '3':
                        /*timer.Stop();
                        Console.WriteLine($"Показан элемент {storable.Top()}");
                        ConsoleHelper.PrintOldStructure(storable, true);
                        timer.Start();*/
                        storable.Top();

                        /*timer.Stop();
                        Console.WriteLine("Показан последний элемент");
                        timer.Start();*/

                        /*timer.Stop();
                        ConsoleHelper.PrintNewStructure(storable);
                        Console.Write("\r\n\r\n\r\n");
                        timer.Start();*/
                        break;
                    case '4':
                        /*timer.Stop();
                        Console.WriteLine("Вызвана проверка на пустоту.");
                        Console.WriteLine($"{storable.IsEmpty()}");
                        ConsoleHelper.PrintOldStructure(storable, true);
                        timer.Start();*/
                        storable.IsEmpty();

                        /*timer.Stop();
                        Console.WriteLine("Вызвана проверка на пустоту");
                        timer.Start();*/

                        /*timer.Stop();
                        ConsoleHelper.PrintNewStructure(storable);
                        Console.Write("\r\n\r\n\r\n");
                        timer.Start();*/
                        break;
                    case '5':
                        /*timer.Stop();
                        Console.WriteLine("Структура выведена в консоль.");
                        timer.Start();*/
                        storable.Print();
                        break;
                }
            }
            timer.Stop();

            return timer.ElapsedTicks;
        }

        public static List<Data> RequestTheDataForDifferentQueues()
        {
            List<Data> result = new();

            string[] input = RequestUserInput();
            int variablesCount = Int32.Parse(input[0]);
            int steps = Int32.Parse(input[1]);
            CreateData(variablesCount, steps);
            result.Add(RequestTheData("QueueList", new MyQueueList<object>(), false, input));
            result.Add(RequestTheData("QueueQueue", new MyQueueQueue<object>(), false, input));

            return result;
        }

        public static List<Data> RequestTheDataForDifferentInput(string typeOfStructure)
        {
            List<Data> result = new();

            string[] input = RequestUserInput();
            int variablesCount = Int32.Parse(input[0]);
            int steps = Int32.Parse(input[1]);
            CreateSimpleData(variablesCount, steps);

            List<string> harderInput = new();
            for(int i = Program.Inputs.Count - 1; i > 0; i--)
            {
                string[] operations = Program.Inputs[i].Split(' ');
                StringBuilder sb = new();
                for(int j = 0; j < i; j++)
                {
                    sb.Append(operations[j]).Append(" ");
                }
                for (int j = i; j < operations.Length; j++)
                {
                    sb.Append("5 ");
                }
                harderInput.Add(sb.ToString().Trim());
            }
            List<string> oldInputs = Program.Inputs;

            switch (typeOfStructure)
            {
                case "QueueList":
                    result.Add(RequestTheData("QueueListSimpleInput", new MyQueueList<object>(), false, input));
                    Program.Inputs = harderInput;
                    result.Add(RequestTheData("QueueListHardInput", new MyQueueList<object>(), false, input));
                    break;
                case "QueueQueue":
                    result.Add(RequestTheData("QueueQueueSimpleInput", new MyQueueQueue<object>(), false, input));
                    Program.Inputs = harderInput;
                    result.Add(RequestTheData("QueueQueueHardInput", new MyQueueQueue<object>(), false, input));
                    break;
                case "Stack":
                    result.Add(RequestTheData("StackSimpleInput", new MyStack<object>(), false, input));
                    Program.Inputs = harderInput;
                    result.Add(RequestTheData("StackHardInput", new MyStack<object>(), false, input));
                    break;
            }
            Program.Inputs = oldInputs;
            return result;
        }

        private static void CreateSimpleData(int variablesCount, int steps)
        {
            for (int i = 0; i < variablesCount; i += steps)
            {
                Program.Inputs.Add(Input.CreateSimpleInput(variablesCount));
            }
        }
    }
}
