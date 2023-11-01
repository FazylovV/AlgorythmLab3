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
                Console.WriteLine($"Ваш список выглядит как-то так: {list}");
            else
                Console.WriteLine("Вы не увидите здесь своего списка... Но это не мы виноваты!" +
                    " Просто он неотразим (пустой, получается).");
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
                Console.Write("Введите значение нового головастика списка: ");
                if (!EnterOneData(out T newData)) continue;

                list.AddHead(newData);
                Console.WriteLine($"Лучше и быть не может: {list}. Вам же нравится, правда?");
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
                Console.Write("Введите значение нового хвостика списка: ");
                if (!EnterOneData(out T newData)) continue;

                list.AddTail(newData);
                Console.WriteLine($"А у нас пополнение! Только взгляните на эту счастливую семью: {list}");
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
                Console.WriteLine("Извините, а что тут, собственно, переворачивать? Мы жаждем больше элементов!");
            }
            else
            {
                list.Reverse();
                Console.WriteLine($"Красивое, не правда ли: {list}");
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
                Console.WriteLine("А переносить-то и нечего! Добавьте элементиков - получите результат.");
            }
            else
            {
                list.HeadToTail();
                Console.WriteLine($"Не знаем, зачем вам это, но держите: {list}");
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
                Console.WriteLine("Сейчас-сейчас... А, ой! Вот то что вы пытаетесь сделать, вот это и невозможно... Мало элементов помоту что!");
            }
            else
            {
                list.TailToHead();
                Console.WriteLine($"Вот ваш заказ, держите и радуйтесь: {list}");
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
                Console.WriteLine("Мы не работаем со списками, где недостаточно уникальных элементов! Ну вот что, скажите, тут можно поменять?");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите два переменчивых значения через ПРОБЕЛЬЧИК.\n" +
                    "Если для значения необходимы пробелы, замените их на значок доллара $: ");
                string errorMessage = "Мы слишком глупенькие, чтобы воспринимать то, что вы написали. Пожалуйста, следуйте условиям.";
                if (!EnterTwoData(errorMessage, out T? data1, out T? data2)) continue;

                if (data1.Equals(data2))
                {
                    Console.WriteLine("Наташ, они одинаковые! Введите что-то нормальное, пожалуйста, иначе мы вас не отпустим.");
                    Console.ReadKey();
                    continue;
                }
                list.Swap(data1, data2);
                Console.WriteLine($"Обмен совершён. Надеемся, это была выгодная сделка: {list}");
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
                Console.WriteLine("Список пустует... Как в нём можно найти хоть какой-то элемент?");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите два значения через ПРОБЕЛЬЧИК. Первое - значение вставляемого элемента,\n" +
                    "второе - до которого совершается вставка.\n" +
                    "Если для значения необходимы пробелы, замените их на значок доллара $: ");
                string errorMessage = "Что-то написано не так... Перечитайте условия работы данного метода.";
                if (!EnterTwoData(errorMessage, out T? insertData, out T? requiredData)) continue;

                list.InsertBefore(insertData, requiredData);
                Console.WriteLine($"Мы сделали всё, что могли... Но не то чтобы вы ожидали от нас чего-то большего: {list}");
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
                Console.WriteLine("Копия пустого списка, конечно, звучит заманчиво, но мы на это не поведёмся!");
                return;
            }
            else
            {
                list.InsertCopyAsTail();
                Console.WriteLine($"Поздравляем, у вас близняшки: {list}");
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
                Console.WriteLine("Прочитайте запрос внимательно. Там же прямо написано: \"Удалить все дубликаты\".\n" +
                    "Ну какие дубликаты могут быть в вашем масеньком списке?");
            }
            else
            {
                list.RemoveDuplicates();
                Console.WriteLine($"Того, чего вы так боялись, больше нет. Взгляните: {list}");
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
                Console.WriteLine("Ну допустим мы можем удалить воздух из этого списка, но элементов-то нет, удалять-то больше нечего.");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение удаляемого элементика списка: ");
                if (!EnterOneData(out T removeData)) continue;

                list.Remove(removeData);
                Console.WriteLine($"Вы видите это страшненькое значение в списке: {list}? Вот и мы не видим. И его нет.");
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
                Console.WriteLine("Этому методу нужен новый герой! То есть, другие типы данных списка.");
                Console.ReadKey();
                return;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Какое бы значение вы не указали, всё будет тщетно... Вам когда-нибудь говорили про то, что пустой список пуст?");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение-указатель (Вы же в курсе, что оно должно быть в списке?): ");
                if (!EnterOneData(out T newData)) continue;

                list.InsertCopyAfter(newData);
                Console.WriteLine($"Вот такая магия произошла: {list}.\n" +
                    $"Говорят, если не знать, что делает этот метод, можно в попытках разгадать его тайну сломать мозг.");
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
                Console.WriteLine("Извините, мы не знаем, как это всё сравнивать... Укажите целочисленный тип данных для своего списка.");
                Console.ReadKey();
                return;
            }
            else if (!list.IsSortedInAcsendingOrder())
            {
                Console.WriteLine("Перечитываем название метода... Ага-а... А вы уверены, что ваш список отсортирован по неубыванию?");
                Console.ReadKey();
                return;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Списочек пустует, а этого быть не должно! Добавьте хотя бы один элементик.");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение для его добавления в какое-то местечко среди элементов: ");
                if (!EnterOneData(out T newData)) continue;

                list.InsertInSortedInAcsOrderList(newData);
                Console.WriteLine($"Новый элементик уже в строю: {list}. Уверены, он справится со своей службой!");
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
                Console.WriteLine("Капс был единственным нашим оружием... И оно не помогло...");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значения добавляемого в качестве хвостика списка через ПРОБЕЛЬЧИК.\n" +
                    "Если для значения необходимы пробелы, замените их на значок доллара $: ");
                if (!EnterListData(out LinkedList<T>? newList)) continue;

                list.InsertAsTail(newList);
                Console.WriteLine($"У вашего списочка вырос хвостик в соответствиями с вашими ожиданиями: {list}");
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
                Console.WriteLine("Принимаем только целочисленные списки для этого метода!\n" +
                    "Поменяйте списочек на тот, что с другим типом, если хотите увидеть что-то интересненькое.");
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Этот список был слишком пустым внутри... Может, сам по себе он и уникален, но только не его элементы.");
            }
            else
            {
                Console.WriteLine($"Интересный факт, который вам нужно знать: уникального в вашем списке ровно {list.DistinctCount()}");
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
                Console.WriteLine("ДЛЯ ЦЕЛЫХ ЧИСЕЛ! Да-да, там было написано именно так.");
                Console.ReadKey();
                return;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("А вы знали, что в пустом списке нечего делить?");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение элемента, который мощно разорвёт этот список на две части: ");
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
                Console.WriteLine("Упс... Введённое значение не соответствует типу элементов списка.\n" +
                    "Попробуйте снова, на этот раз грехом будет ошибиться!");
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
                Console.WriteLine($"Итак, теперь у нас есть два списочка. Первый би лайк: {firstList}. Второй: {secondList}\n" +
                    $"Выбирайте списочек, с которым хотите работать нажатием на циферку 1 или 2 соответственно.");
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
                    Console.WriteLine("Кажется, вы нажали не ту кнопочку... Попробуйте ещё раз");
                    Console.ReadKey();
                    continue;
                }

                ConsoleHelper.ClearScreen();
                Console.WriteLine($"Вам удалось нажать верную кнопку! А потому ваш текущий список теперь выглядит вот так: {list}");
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

