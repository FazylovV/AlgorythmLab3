using AlgorythmLab3.List;
using AlgorythmLab3.Stack_and_Queue;
using System.Runtime.ExceptionServices;
using AlgorythmLab3.Postfix;

namespace AlgorythmLab3
{
    public class Program
    {

        /// <summary>
        /// Основное меню для управления двусвязным списком.
        /// </summary>
        public static Menu? ListMethodsMenu { get; private set; }

        public static List<string> Inputs = new();

        /// <summary>
        /// Метод входа в программу.
        /// </summary>
        public static void Main()
        {
            // Type dataType = ShowTheListTypeMenu();
            // ShowTheListMethodsMenu(dataType);

            /*string normal = "2+2*8+4*6";
            Console.WriteLine(normal);
            string postfix = Converter.ConvertToPostfix(normal);
            Console.WriteLine(postfix);
            Console.WriteLine(Calculator.Calculate(postfix));*/
            ShowChooseMenu();
        }

        public static void ShowChooseMenu ()
        {
            Console.CursorVisible = false;
            string header = "Выберите желаемую структуру для дальнейшей работы:";
            List<MenuItem> listTypeMenuItems = new()
            {
                new MenuItem("Связный список"),
                new MenuItem("Стек"),
                new MenuItem("Очередь")
            };
            Menu listTypeMenu = new(listTypeMenuItems);
            listTypeMenu.MoveThroughForSelect(header);
            MenuItem selectedItem = listTypeMenuItems[listTypeMenu.SelectedItemIndex];
            switch (selectedItem.ItemMessage)
            {
                case "Связный список":
                    {
                        Type dataType = ShowTheListTypeMenu();
                        ShowTheListMethodsMenu(dataType);
                        break;
                    }
                case "Стек": 
                    {
                        MyStack<object> stack = new();
                        ShowTheStackMethodsMenu(stack);
                        break;
                    }
                case "Очередь":
                    {
                        MyQueueList<object> queue = new();
                        ShowTheQueueMethodsMenu(queue);
                        break;
                    } 
                    
                default: return;
            }

        }
        /// <summary>
        /// Метод, отображающий меню для управления очередью.
        /// </summary>
        private static void ShowTheQueueMethodsMenu(MyQueueList<object> queue)
        {
            Console.CursorVisible = false;
            string header = "Очередь"; // Тут пишете заголовок меню
            List<MenuItem> listTypeMenuItems = new()
            {
                new MenuItem("Добавить в очередь"),
                new MenuItem("Удалить из очереди"),
                new MenuItem("Вывести первый элемент в очереди"),
                new MenuItem("Проверка на пустоту"),
                new MenuItem("Вывод очереди"),
                new MenuItem("Сделать замер времени работы очереди, реализованной на списке(входные данные разной длины)"),
                new MenuItem("Сделать замер времени работы очереди, реализованной на стандартной очереди(входные данные разной длины)"),
                new MenuItem("Сделать замер времени работы очереди, реализованной на списке(входные данные одинаковой длины)"),
                new MenuItem("Сделать замер времени работы очереди, реализованной на стандартной очереди(входные данные одинаковой длины)"),
                new MenuItem("Сравнить работу разных реализаций очередей"),
                //тут должны быть созданы итемы с названием кнопок
            };
            Menu listTypeMenu = new(listTypeMenuItems);
            listTypeMenu.MoveThroughForSelect(header);
            string selectedItem = listTypeMenuItems[listTypeMenu.SelectedItemIndex].ItemMessage;

            switch (selectedItem)
            {
                case "Добавить в очередь":
                    queue.PushForConsole();
                    break;
                case "Удалить из очереди":
                    queue.PopForConsole();
                    break;
                case "Вывести первый элемент в очереди":
                    queue.TopForConsole();
                    break;
                case "Проверка на пустоту":
                    queue.IsEmptyForConsole();
                    break;
                case "Вывод очереди":
                    queue.PrintForConsole();
                    break;
                case "Сделать замер времени работы очереди, реализованной на списке(входные данные разной длины)":
                    string[] dataQueueListinput = Measurements.RequestUserInput();
                    Data dataQueueList = Measurements.RequestTheData("QueueList", new MyQueueList<object>(), true, dataQueueListinput);
                    Drawer.Draw("QueueList", Measurements.SavePath, new List<Data> { dataQueueList }, "Количество операций");
                    break;
                case "Сделать замер времени работы очереди, реализованной на стандартной очереди(входные данные разной длины)":
                    string[] dataQueueQueueinput = Measurements.RequestUserInput();
                    Data dataQueueQueue = Measurements.RequestTheData("QueueQueue", new MyQueueQueue<object>(), true, dataQueueQueueinput);
                    Drawer.Draw("QueueQueue", Measurements.SavePath, new List<Data> { dataQueueQueue }, "Количество операций");
                    break;
                case "Сравнить работу разных реализаций очередей":
                    List<Data> dataDifferentQueues = Measurements.RequestTheDataForDifferentQueues();
                    Drawer.Draw("Difference between queues", Measurements.SavePath, dataDifferentQueues, "Количество операций");
                    break;
                case "Сделать замер времени работы очереди, реализованной на списке(входные данные одинаковой длины)":
                    List<Data> differentDataQueueList = Measurements.RequestTheDataForDifferentInput("QueueList");
                    Drawer.Draw("Different inputs for QueueList", Measurements.SavePath, differentDataQueueList, "Количество операций вывода в усложнённых входных данных");
                    break;
                case "Сделать замер времени работы очереди, реализованной на стандартной очереди(входные данные одинаковой длины)":
                    List<Data> differentDataQueueQueue = Measurements.RequestTheDataForDifferentInput("QueueQueue");
                    Drawer.Draw("Different inputs for QueueQueue", Measurements.SavePath, differentDataQueueQueue, "Количество операций вывода в усложнённых входных данных");
                    break;
            }
            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadKey();
            ShowTheQueueMethodsMenu(queue);
            // Дальше можете через выбранный предмет сделать свитч/кейс или рефлексию, как хотите
        }

        /// <summary>
        /// Метод, отображающий меню для управления стэком.
        /// </summary>
        private static void ShowTheStackMethodsMenu(MyStack<object> stack)
        {
            Console.CursorVisible = false;
            string header = ""; // Тут пишете заголовок меню
            List<MenuItem> listTypeMenuItems = new()
            {                
                new MenuItem("Добавить в стек"),
                new MenuItem("Удалить из стека"),
                new MenuItem("Вывести последний элемент в стеке"),
                new MenuItem("Проверка на пустоту"),
                new MenuItem("Вывод стека"),
                new MenuItem("Сделать замер времени работы стека(входные данные разной длины)"),
                new MenuItem("Сделать замер времени работы стека(входные данные одинаковой длины)")
               //тут должны быть созданы итемы с названием кнопок
            };
            Menu listTypeMenu = new(listTypeMenuItems);
            listTypeMenu.MoveThroughForSelect(header);
            string selectedItem = listTypeMenuItems[listTypeMenu.SelectedItemIndex].ItemMessage;

            switch (selectedItem)
            {
                case "Добавить в стек":
                    stack.PushForConsole();
                    break;
                case "Удалить из стека":
                    stack.PopForConsole();
                    break;
                case "Вывести последний элемент в стеке":
                    stack.TopForConsole();
                    break;
                case "Проверка на пустоту":
                    stack.IsEmptyForConsole();
                    break;
                case "Вывод стека":
                    stack.Print();
                    break;
                case "Сделать замер времени работы стека(входные данные разной длины)":
                    string[] dataQueueListinput = Measurements.RequestUserInput();
                    Data dataQueueList = Measurements.RequestTheData("Stack", new MyStack<object>(), true, dataQueueListinput);
                    Drawer.Draw("Stack", Measurements.SavePath, new List<Data> { dataQueueList }, "Количество операций");
                    break;
                case "Сделать замер времени работы стека(входные данные одинаковой длины)":
                    List<Data> differentDataQueueList = Measurements.RequestTheDataForDifferentInput("Stack");
                    Drawer.Draw("Different inputs for Stack", Measurements.SavePath, differentDataQueueList, "Количество операций вывода в усложнённых входных данных");
                    break;
            }
            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadKey();
            ShowTheStackMethodsMenu(stack);
            // Дальше можете через выбранный предмет сделать свитч/кейс или рефлексию, как хотите
        }

        /// <summary>
        /// Метод, отображающий меню выбора типа данных для списка.
        /// </summary>
        public static Type ShowTheListTypeMenu()
        {
            Console.CursorVisible = false;
            string header = "Выберите тип данных для своего списка:";
            List<MenuItem> listTypeMenuItems = new()
            {
                new MenuItem("Число с плавающей запятой"),
                new MenuItem("Число с плавающей запятой одинарной точности"),
                new MenuItem("Целое число"),
                new MenuItem("Целое длинное число"),
                new MenuItem("Строка")
            };
            Menu listTypeMenu = new(listTypeMenuItems);
            listTypeMenu.MoveThroughForSelect(header);

            MenuItem selectedItem = listTypeMenuItems[listTypeMenu.SelectedItemIndex];
            string typeName = TypeChecker.RusTypeSystemTypePairs[selectedItem.ItemMessage];
            Type dataType = Type.GetType(typeName);
            return dataType;
        }

        /// <summary>
        /// Метод, отображающий меню для управления двусвязным списком.
        /// </summary>
        /// <param name="dataType"></param>
        private static void ShowTheListMethodsMenu(Type dataType)
        {
            Console.CursorVisible = false;
            List<MenuItem> listMethodsMenuItems = new()
            {
                new MenuItem("Текущее состояние списка"),
                new MenuItem("Добавить элемент в начало списка"),
                new MenuItem("Добавить элемент в конец списка"),
                new MenuItem("Перевернуть список[1]"),
                new MenuItem("Перенести первый элемент списка в конец[2.1]"),
                new MenuItem("Перенести последний элемент списка в начало[2.2]"),
                new MenuItem("Посчитать число различных элементов ЦЕЛОЧИСЛЕННОГО списка[3]"),
                new MenuItem("Удалить все дубликаты[4]"),
                new MenuItem("Вставить копию списка после заданного ЧИСЛА[5]"),
                new MenuItem("Вставить элемент в отсортированный по не убыванию список ЧИСЕЛ[6]"),
                new MenuItem("Удалить все элементы с заданным значением[7]"),
                new MenuItem("Вставить заданный элемент перед другим указанным элементом[8]"),
                new MenuItem("Добавить заданный список ЦЕЛЫХ ЧИСЛОВЫХ элементов к текущему[9]"),
                new MenuItem("Разбить список ЦЕЛЫХ ЧИСЕЛ на два по заданному элементу. (Вы сами выбираете список для дальнейшей работы)[10]"),
                new MenuItem("Удвоить список[11]"),
                new MenuItem("Поменять местами два заданных элемента[12]"),
                new MenuItem("СБРОСИТЬ ТЕКУЩИЙ СПИСОК"),
                new MenuItem("Выход в меню")
            };

            List<string> methodNames = new()
            {
                "ToString", "AddHead", "AddTail", "Reverse", "HeadToTail", "TailToHead", "DistinctCount", "RemoveDuplicates",  "InsertCopyAfter", "InsertInSortedInAcsOrderList", "Remove", "InsertBefore", "InsertAsTail",
                "Split","InsertCopyAsTail", "Swap",
                "ResetTheList", "Exit"
            };

            for (int i = 0; i < listMethodsMenuItems.Count; i++)
            {
                listMethodsMenuItems[i].SetMethodInfo("Lab_3", "ListMethodsCaller", methodNames[i]);
            }

            object? list = Activator.CreateInstance(typeof(AlgorythmLab3.List.LinkedList<>).MakeGenericType(dataType));
            ListMethodsMenu = new(listMethodsMenuItems)
            {
                Instance = Activator.CreateInstance(typeof(MethodeInvokeList<>).MakeGenericType(dataType), list)
            };
            ListMethodsMenu.InfiniteMoveThrough();
        }
    }
}
    