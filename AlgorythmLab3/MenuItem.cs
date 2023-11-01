using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3
{
    /// <summary>
    /// Класс реализации элемента меню.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Пространство используемого метода, соответствующего данному элементу.
        /// </summary>
        public string ItemNamespace { get; private set; }
        /// <summary>
        /// Имя класса используемого метода, соответствующего данному элементу.
        /// </summary>
        public string ItemClassName { get; private set; }
        /// <summary>
        /// Имя метода, соответствующего данному элементу.
        /// </summary>
        public string ItemMethodName { get; private set; }
        /// <summary>
        /// Надпись, информирующая о том, что происходит в методе, соответствующем данному элементу.
        /// </summary>
        public string ItemMessage { get; private set; }
        /// <summary>
        /// Флаг для определения того, выбран ли элемент в данный момент.
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="itemMessage">Указанная информация, соответствующая элементу.</param>
        public MenuItem(string itemMessage)
        {
            ItemMessage = itemMessage;
        }

        /// <summary>
        /// Метод для привязки метода к элементу.
        /// </summary>
        /// <param name="itemNamespace">Указанное пространство элемента.</param>
        /// <param name="itemClassName">Указанное имя класса элемента.</param>
        /// <param name="itemMethodName">Указанное имя метода элемента.</param>
        public void SetMethodInfo(string itemNamespace, string itemClassName, string itemMethodName)
        {
            ItemNamespace = itemNamespace;
            ItemClassName = itemClassName;
            ItemMethodName = itemMethodName;
        }
    }
}
