using AlgorythmLab3.List;
using AlgorythmLab3.Stack_and_Queue;
using System.Runtime.ExceptionServices;

namespace AlgorythmLab3
{
    public class Program
    {

        /// <summary>
        /// Основное меню для управления двусвязным списком.
        /// </summary>
        public static Menu? ListMethodsMenu { get; private set; }

        /// <summary>
        /// Метод входа в программу.
        /// </summary>
        public static void Main()
        {
            Type dataType = ShowTheListTypeMenu();
            ShowTheListMethodsMenu(dataType);
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
                new MenuItem("ВЫХОД")
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
    