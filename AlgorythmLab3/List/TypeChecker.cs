using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.List
{
    public class TypeChecker
    {
        /// <summary>
        /// Метод, проверяющий тип данных на целочисленность.
        /// </summary>
        /// <param name="type">Проверяемый тип данных.</param>
        /// <returns></returns>
        public static bool IsIntegerType(Type type)
        {
            return
                type == typeof(sbyte) ||
                type == typeof(byte) ||
                type == typeof(short) ||
                type == typeof(ushort) ||
                type == typeof(int) ||
                type == typeof(uint) ||
                type == typeof(long) ||
                type == typeof(ulong);
        }

        /// <summary>
        /// Метод, проверяющий, является ли тип данных числовым.
        /// </summary>
        /// <param name="type">Проверяемый тип данных.</param>
        /// <returns></returns>
        public static bool IsNumericType(Type type)
        {
            return type.IsPrimitive && (
                type == typeof(byte) ||
                type == typeof(sbyte) ||
                type == typeof(short) ||
                type == typeof(ushort) ||
                type == typeof(int) ||
                type == typeof(uint) ||
                type == typeof(long) ||
                type == typeof(ulong) ||
                type == typeof(float) ||
                type == typeof(double) ||
                type == typeof(decimal)
            );
        }
    }
}
