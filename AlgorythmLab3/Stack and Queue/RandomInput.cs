using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    public static class Input
    {
        public static string CreateInput(int lenght)
        {
            StringBuilder sb = new();
            int countElementsInStructure = 0;
            for(int i = 0; i < lenght; i++)
            {
                int operation = new Random().Next(1, 5);
                switch(operation)
                {
                    case 1:
                        CreateAddOperation(sb, ref countElementsInStructure);
                        break;
                    case 2:
                        CreateRemoveOperation(sb, ref countElementsInStructure, 2);
                        break;
                    case 3:
                        CreateRemoveOperation(sb, ref countElementsInStructure, 3);
                        break;
                    case 4:
                        sb.Append("4 ");
                        break;
                    case 5:
                        sb.Append("5 ");
                        break;
                }
            }

            return sb.ToString().Trim();
        }

        private static string CreateValue()
        {
            Random random = new();
            if(random.Next(0, 1) == 0)
            {
                return CreateString(random);
            }

            return random.Next().ToString();
        }

        private static string CreateString(Random random)
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            int maxLength = 25;
            int wordLength = new Random().Next(1, maxLength);

            StringBuilder sb = new();
            for (int i = 0; i < wordLength; i++)
            {
                int letter_num = random.Next(0, letters.Length - 1);
                sb.Append(letters[letter_num]);
            }

            return sb.ToString();
        }

        private static void CreateRemoveOperation(StringBuilder sb, ref int countElementsInStructure, int operation)
        {
            if (countElementsInStructure > 1)
            {
                sb.Append($"{operation} ");
                if(operation == 2)
                {
                    countElementsInStructure--;
                }
            }
            else
            {
                CreateAddOperation(sb, ref countElementsInStructure);
            }
        }

        private static void CreateAddOperation(StringBuilder sb, ref int countElementsInStructure)
        {
            countElementsInStructure++;
            sb.Append($"1,{CreateValue()} ").ToString();
        }
    }
}
