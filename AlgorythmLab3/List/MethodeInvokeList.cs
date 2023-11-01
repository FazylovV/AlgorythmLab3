using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorythmLab3;

namespace AlgorythmLab3.List
{
    /// <summary>
    /// Класс для отображения данных в консоли для пользователя.
    /// </summary>
    /// <typeparam name="T">Тип данных в списке.</typeparam>
    public class MethodeInvokeList<T>
    {
        /// <summary>
        /// Текущий список для управления.
        /// </summary>
        private LinkedList<T>? list;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="list">Указанный список для управления.</param>
        public MethodeInvokeList(LinkedList<T>? list)
        {
            this.list = list;
        }

        /// <summary>
        /// Метод, отображающий текущий список в строковом формате.
        /// </summary>
        public new void ToString()
        {
            if (list.Count != 0)
                Console.WriteLine($"Текущее состояние списка: {list}");
            else
                Console.WriteLine("Список пуст");
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий добавить новый элемент в начало списка.
        /// </summary>
        public void AddHead()
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение нового первого элемента: ");
                if (!EnterOneData(out T newData)) continue;

                list.AddHead(newData);
                Console.WriteLine($"Теперь список выглядит так: {list}.");
                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий добавить новый элемент в конец списка.
        /// </summary>
        public void AddTail()
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение нового последнего элемента:  ");
                if (!EnterOneData(out T newData)) continue;

                list.AddTail(newData);
                Console.WriteLine($"Теперь список выглядит так: {list}.");
                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий развернуть элементы в списке.
        /// </summary>
        public void Reverse()
        {
            if (list.Count <= 1)
            {
                Console.WriteLine("Список содержит меньше элементов, чем требуется для разворота");
            }
            else
            {
                list.Reverse();
                Console.WriteLine($"Теперь список выглядит так: {list}.");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий перенести первый элемент в конец.
        /// </summary>
        public void HeadToTail()
        {
            if (list.Count <= 1)
            {
                Console.WriteLine("Список содержит меньше элементов, чем требуется");
            }
            else
            {
                list.HeadToTail();
                Console.WriteLine($"Теперь список выглядит так: {list}.");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий перенести последний элемент в начало.
        /// </summary>
        public void TailToHead()
        {
            if (list.Count <= 1)
            {
                Console.WriteLine("Список содержит меньше элементов, чем требуется");
            }
            else
            {
                list.TailToHead();
                Console.WriteLine($"Теперь список выглядит так: {list}");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий поменять местами два элемента.
        /// </summary>
        public void Swap()
        {
            if (list.Count <= 1 || list.DistinctCount() == 1)
            {
                Console.WriteLine("Список содержит слишком мало уникальных элементов");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите два значения через пробел.\n" +
                    "Если для значения необходимы пробелы, замените их на значок доллара $: ");
                string errorMessage = "Ввод не соотвествует требованиям.";
                if (!EnterTwoData(errorMessage, out T? data1, out T? data2)) continue;

                if (data1.Equals(data2))
                {
                    Console.WriteLine("Введены одинаковые элементы.");
                    Console.ReadKey();
                    continue;
                }
                list.Swap(data1, data2);
                Console.WriteLine($"Теперь список выглядит так: {list}");
                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий вставить элемент с указанным значением перед первым вхождением элемента с заданным значением.
        /// </summary>
        public void InsertBefore()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите два значения через пробел. Первое - значение вставляемого элемента,\n" +
                    "второе - до которого совершается вставка.\n" +
                    "Если для значения необходимы пробелы, замените их на значок доллара $: ");
                string errorMessage = "Ввод не соотвествует требованиям.";
                if (!EnterTwoData(errorMessage, out T? insertData, out T? requiredData)) continue;

                list.InsertBefore(insertData, requiredData);
                Console.WriteLine($"Теперь список выглядит так: {list}");
                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий вставить в конец списка его копию.
        /// </summary>
        public void InsertCopyAsTail()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            else
            {
                list.InsertCopyAsTail();
                Console.WriteLine($"Теперь список выглядит так: {list}");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий удалить дублирующиеся элементы.
        /// </summary>
        public void RemoveDuplicates()
        {
            if (list.Count <= 1)
            {
                Console.WriteLine("Список содержит слишком мало элементов");
            }
            else
            {
                list.RemoveDuplicates();
                Console.WriteLine($"Теперь список выглядит так: {list}");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий удалить элементы с указанным значением.
        /// </summary>
        public void Remove()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение удаляемого элемента списка: ");
                if (!EnterOneData(out T removeData)) continue;

                list.Remove(removeData);
                Console.WriteLine($"Теперь список выглядит так: {list}.");
                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий вставить копию всего списка после первого вхождения указанного значения элемента.
        /// </summary>
        public void InsertCopyAfter()
        {
            if (!TypeChecker.IsIntegerType(typeof(T)))
            {
                Console.WriteLine("Неподходящий тип данных.");
                Console.ReadKey();
                return;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение-указатель (Оно должно быть в списке): ");
                if (!EnterOneData(out T newData)) continue;

                list.InsertCopyAfter(newData);
                Console.WriteLine($"Теперь список выглядит так: {list}.\n");
                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий добавить в отсортированный по не убыванию список указанный элемент без нарушения сортировки.
        /// </summary>
        public void InsertInSortedInAcsOrderList()
        {
            if (!TypeChecker.IsNumericType(typeof(T)))
            {
                Console.WriteLine("Неверный тип данных.");
                Console.ReadKey();
                return;
            }
            else if (!list.IsSortedInAcsendingOrder())
            {
                Console.WriteLine("Отсутствует сортировка");
                Console.ReadKey();
                return;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение для добавления: ");
                if (!EnterOneData(out T newData)) continue;

                list.InsertInSortedInAcsOrderList(newData);
                Console.WriteLine($"Теперь список выглядит так: {list}.");
                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий вставить в конец существующего списка другой.
        /// </summary>
        public void InsertAsTail()
        {
            if (!TypeChecker.IsIntegerType(typeof(T)))
            {
                Console.WriteLine("Неверный тип данных");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значения добавляемого в конец списка через пробел.\n" +
                    "Если для значения необходимы пробелы, замените их на значок доллара $: ");
                if (!EnterListData(out LinkedList<T>? newList)) continue;

                list.InsertAsTail(newList);
                Console.WriteLine($"Теперь список выглядит так: {list}");
                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, отображающий число различных элементов списка, содержащего целые числа.
        /// </summary>
        public void DistinctCount()
        {
            if (!TypeChecker.IsIntegerType(typeof(T)))
            {
                Console.WriteLine("Неверный тип данных.");
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                Console.WriteLine($"Количество уникальных элементов в списке: {list.DistinctCount()}");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, позволяющий разделить список на две части по указанному значению с последующим выбором текущего списка.
        /// </summary>
        public void Split()
        {
            if (!TypeChecker.IsIntegerType(typeof(T)))
            {
                Console.WriteLine("Неверный тип данных.");
                Console.ReadKey();
                return;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение элемента, по которому будет произведено разделение: ");
                if (!EnterOneData(out T splitData)) continue;

                LinkedList<T>? leftList = list;
                LinkedList<T>? rightList = list.Split(splitData);
                ChooseBetweenTwo(leftList, rightList);
                break;
            }
        }

        /// <summary>
        /// Метод, проверяющий верно ли указано значение соответствующего списку типа данных.
        /// </summary>
        /// <param name="data">Проверяемое значение.</param>
        /// <param name="result">Конвертированное в нужный тип данных значение.</param>
        private static bool CheckTheType(string? data, out T? result)
        {
            if (typeof(T).FullName == "System.Single" || typeof(T).FullName == "System.Double")
                data = data.Replace('.', ',');

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                result = (T?)converter.ConvertFrom(data);
                return true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Неверный тип данных");
                Console.ReadKey();
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Метод для ввода одного значения и его проверки.
        /// </summary>
        /// <param name="data">Введённое значение.</param>
        private static bool EnterOneData(out T data)
        {
            Console.CursorVisible = true;
            string? dataStr = Console.ReadLine();
            Console.CursorVisible = false;
            ConsoleHelper.ClearScreen();

            if (!MethodeInvokeList<T>.CheckTheType(dataStr, out data))
            {
                data = default;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Метод для ввода двух значений и их проверки.
        /// </summary>
        /// <param name="errorMessage">Сообщение в случае если число введённых значений не соответствует двум.</param>
        /// <param name="firstData">Первое введённое значение.</param>
        /// <param name="secondData">Второе введённое значение.</param>
        private static bool EnterTwoData(string errorMessage, out T? firstData, out T? secondData)
        {
            Console.CursorVisible = true;
            string? dataStr = Console.ReadLine();
            Console.CursorVisible = false;
            ConsoleHelper.ClearScreen();

            string[] dataArr = dataStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (dataArr.Length != 2)
            {
                Console.WriteLine(errorMessage);
                Console.ReadKey();
                firstData = default;
                secondData = default;
                return false;
            }

            dataArr[0] = dataArr[0].Replace('$', ' ');
            dataArr[1] = dataArr[1].Replace('$', ' ');

            if (!MethodeInvokeList<T>.CheckTheType(dataArr[0], out firstData) ||
                !MethodeInvokeList<T>.CheckTheType(dataArr[1], out secondData))
            {
                firstData = default;
                secondData = default;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метод для ввода списка значений.
        /// </summary>
        /// <param name="list">Введённый список значений.</param>
        private static bool EnterListData(out LinkedList<T>? list)
        {
            Console.CursorVisible = true;
            string? listStr = Console.ReadLine();
            Console.CursorVisible = false;
            ConsoleHelper.ClearScreen();

            string[] dataArr = listStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            list = new LinkedList<T>();

            for (int i = 0; i < dataArr.Length; i++)
            {
                dataArr[i] = dataArr[i].Replace('$', ' ');
                if (!MethodeInvokeList<T>.CheckTheType(dataArr[i], out T? data))
                {
                    list = default;
                    return false;
                }
                else
                {
                    list.AddTail(data);
                }
            }

            return true;
        }

        /// <summary>
        /// Метод для выбора текущего списка между двумя указанными.
        /// </summary>
        /// <param name="firstList">Первый список.</param>
        /// <param name="secondList">Второй список.</param>
        private void ChooseBetweenTwo(LinkedList<T>? firstList, LinkedList<T>? secondList)
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.WriteLine($"Теперь существует два списка. Первый: {firstList}. Второй: {secondList}\n" +
                    $"Выбирите список, с которым хотите работать нажатием на цифру 1 или 2 соответственно.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.NumPad1 || keyInfo.Key == ConsoleKey.D1)
                {
                    list = firstList;
                }
                else if (keyInfo.Key == ConsoleKey.NumPad2 || keyInfo.Key == ConsoleKey.D2)
                {
                    list = secondList;
                }
                else
                {
                    Console.WriteLine("Нажата не та клавиша");
                    Console.ReadKey();
                    continue;
                }

                ConsoleHelper.ClearScreen();
                Console.WriteLine($"Теперь список выглядит так: {list}");
                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод сброса списка.
        /// </summary>
        public void ResetTheList()
        {
            Type dataType = Program.ShowTheListTypeMenu();
            object? list = Activator.CreateInstance(typeof(LinkedList<>).MakeGenericType(dataType));
            Program.ListMethodsMenu.Instance = Activator.CreateInstance(typeof(MethodeInvokeList<>).MakeGenericType(dataType), list);
        }

        /// <summary>
        /// Метод выхода из программы.
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}

