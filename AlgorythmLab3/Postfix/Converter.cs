using System.Text;
using AlgorythmLab3.Stack_and_Queue;

namespace AlgorythmLab3.Postfix;

public static class Converter
{
    public static int GetPrior(char h)
    {
        switch (h)
        {
            case '^': return 6;
            case '*':
            case '/': return 5;
            case '+':
            case '-': return 4;
            case '=': return 3;
            case ')': return 2;
            case '(': return 1;
            default: return 0;
        }
    }

    public static string ConvertToPostfix(string normal)
    {
        Stack<char> s = new Stack<char>();
        StringBuilder postfix = new StringBuilder();
        char last = ' ';
        //здесь преобразуем строку в постфиксную. например 1*2+3  будет 12*3+
        foreach (char x in normal)
        {
            if (x == '-' && Char.IsLetterOrDigit(last) == false)
            {
                postfix.Append(x);
                continue;
            }

            if (char.IsLetterOrDigit(x) || x == '.') postfix.Append(x);
            else if (x == '(')
            {
                s.Push(x);
            }
            else if (x == ')')
            {
                while (s.Peek() != '(')
                {
                    postfix.Append(" ");
                    postfix.Append(s.Pop());
                }

                s.Pop();
            }
            else
            {
                while (s.Count > 0 && GetPrior(s.Peek()) >= GetPrior(x))
                {
                    postfix.Append(" ").Append(s.Pop());
                }

                s.Push(x);
            }

            if (x == '+' || x == '-' || x == '*' || x == '/' || x == '^') postfix.Append(" ");

            last = x;
        }

        while (s.Count > 0)
        {
            postfix.Append(" ");
            postfix.Append(s.Pop());
        }

        return postfix.ToString();
    }
}