using System.Text;
using AlgorythmLab3.Stack_and_Queue;

namespace AlgorythmLab3.Postfix;

public static class Converter
{
    public static int GetPrior(string h)
    {
        switch (h)
        {
            case "sqrt": return 6;
            case "sin": return 6;
            case "cos": return 6;
            case "ln": return 6;
            case "^": return 6;
            case "*": return 5;
            case "/": return 5;
            case "+": return 4;
            case "-": return 4;
            case "=": return 3;
            case ")": return 2;
            case "(": return 1;
            default: return 0;
        }
    }

    public static string ConvertToPostfix(string normal)
    {
        Stack<string> s = new Stack<string>();
        StringBuilder postfix = new StringBuilder();
        string last = " ";
        
        foreach (string x in normal.Split(" "))
        {
            if (x == "-" && Char.IsDigit(last[0]) == false)
            {
                postfix.Append(x);
                continue;
            }

            if (char.IsDigit(x[0]) || x == ".") postfix.Append(x);
            else if (x == "(")
            {
                s.Push(x);
            }
            else if (x == ")")
            {
                while (s.Peek() != "(")
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

            if (x == "+" || x == "-" || x == "*" || x == "/" || x == "^" || x == "ln" || x == "cos" || x == "sin" || x == "sqrt") postfix.Append(" ");

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