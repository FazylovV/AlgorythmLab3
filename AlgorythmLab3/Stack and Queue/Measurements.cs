using System;
using System.Collections.Generic;
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

        public static Data RequestTheData(string name)
        {
            Console.WriteLine($"Введите максимальный размер входных данных, шаг и количество проверок(через одиночные пробелы) для алгоритма {name.Replace(".Timer", "")}");

            string[] input = Console.ReadLine().Split(" ");
            if (IsInputCorrect(input) == false)
            {
                Console.WriteLine("Некоректный ввод, попробуйте снова");
                RequestTheData(name);
            }
            int variablesCount = Int32.Parse(input[0]);
            int steps = Int32.Parse(input[1]);
            int testsCount = Int32.Parse(input[2]);
            return MeasureTheTime(name, variablesCount, testsCount, steps);
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

        private static Data MeasureTheTime(string name, int variablesCount, int testsCount, int steps)
        {
            long[] timeNotes = new long[testsCount];
            List<double> doubleTimeNotes = new();
            string[] times = new string[variablesCount];
            List<double> stepList = new();
            for (int i = steps; i <= variablesCount; i += steps)
            {
                for (int j = 0; j < testsCount; j++)
                {
                    timeNotes[j] = ReflexChooseAlg(name, i);
                }
                stepList.Add(i);
                long avarageTime = timeNotes.Sum() / testsCount;
                times[i / steps - 1] = $"{i} {avarageTime}";
                doubleTimeNotes.Add(avarageTime);
            }
            return new Data(stepList, doubleTimeNotes, name);
        }

        private static long ReflexChooseAlg(string name, int variablesCount)
        {
            string[] algClassAndMeth = name.Split('.');
            string className = $"AlgorythmLab3.Stack_and_Queue.{algClassAndMeth[0]}";
            string methodName = algClassAndMeth[1];
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType(className);
            MethodInfo methodInfo = type.GetMethod(methodName, new Type[] { typeof(int) });
            object instance = Activator.CreateInstance(type);
            return (long)methodInfo.Invoke(instance, new object[] { variablesCount });
        }
        public static long Timer(int variableCount, IExecutable executable)
        {
            Stopwatch timer = new();

            if (Program.Inputs[variableCount] == null)
            {
                Program.Inputs[variableCount] = Input.CreateInput(variableCount);
            }

            timer.Start();
            executable.Execute(variableCount);
            timer.Stop();

            return timer.ElapsedMilliseconds;
        }
    }
}
