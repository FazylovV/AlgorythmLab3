using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3
{
    /// <summary>
    /// Класс реализации меню.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Индекс выбранного элемента.
        /// </summary>
        public int SelectedItemIndex { get; set; }

        /// <summary>
        /// Элементы, содержащиеся в меню.
        /// </summary>
        public List<MenuItem> Items { get; private set; }

        /// <summary>
        /// Экземпляр необходимого класса для работы с ним.
        /// </summary>
        public object? Instance { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="items">Указанные элементы меню.</param>
        public Menu(List<MenuItem> items)
        {
            Items = items;
            SelectedItemIndex = 0;
        }

        /// <summary>
        /// Метод, отслеживающий нажатия клавиши для передвижения по меню до выхода из программы при наличии соответствующего элемента.
        /// </summary>
        public void InfiniteMoveThrough()
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Show();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (SelectedItemIndex == Items.Count - 1)
                            SelectedItemIndex = 0;
                        else
                            SelectedItemIndex++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (SelectedItemIndex == 0)
                            SelectedItemIndex = Items.Count - 1;
                        else
                            SelectedItemIndex--;
                        break;
                    case ConsoleKey.Enter:
                        ConsoleHelper.ClearScreen();
                        Execute();
                        ConsoleHelper.ClearScreen();
                        break;
                }
            }
        }

        /// <summary>
        /// Метод, отслеживающий нажатия клавиши для передвижения по меню до выбора одного из элементов.
        /// </summary>
        public void MoveThroughForSelect(string header)
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.WriteLine($"{header}\n");
                Show();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (SelectedItemIndex == Items.Count - 1)
                            SelectedItemIndex = 0;
                        else
                            SelectedItemIndex++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (SelectedItemIndex == 0)
                            SelectedItemIndex = Items.Count - 1;
                        else
                            SelectedItemIndex--;
                        break;
                    case ConsoleKey.Enter:
                        return;
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий операцию с заданным объектом.
        /// </summary>
        private void Execute()
        {
            MenuItem selectedItem = Items[SelectedItemIndex];
            string methodName = selectedItem.ItemMethodName;
            MethodInfo methodInfo = Instance.GetType().GetMethod(methodName);
            methodInfo.Invoke(Instance, null);
        }

        /// <summary>
        /// Метод, отображающий меню в консоли.
        /// </summary>
        private void Show()
        {
            if (Items.Count > 0)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (i == SelectedItemIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(Items[i].ItemMessage);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(Items[i].ItemMessage);
                    }
                }
            }
        }
    }
}
