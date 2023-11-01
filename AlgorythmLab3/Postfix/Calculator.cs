using AlgorythmLab3.Stack_and_Queue;

namespace AlgorythmLab3.Postfix;

public class Calculator
{
    public static int Calculate(string str)
    {
        MyStack<int> stack = new MyStack<int>();
        for (int i = 0; i < str.Length; i++)
        {
            char symbol = str[i];
            if(char.IsDigit(symbol))
            {
                stack.Push(int.Parse(symbol.ToString()));
                continue;
            }

            int num1 = (int)stack.Pop();
            int num2;
            switch (symbol)
            {
                case '+':
                    num2 = (int)stack.Pop();
                    stack.Push(num2 + num1);
                    break;
                
                case '-':
                    num2 = (int)stack.Pop();
                    stack.Push(num2 - num1);
                    break;
                
                case '*':
                    num2 = (int)stack.Pop();
                    stack.Push(num2 * num1);
                    break;
                
                case '/':
                    num2 = (int)stack.Pop();
                    stack.Push((int)Math.Round((double)(num2 / num1)));
                    break;
                
                case '^':
                    num2 = (int)stack.Pop();
                    stack.Push((int)Math.Pow(num2, num1));
                    break;
                
                default:
                    if (str.Substring(i, 2) == "ln")
                    {
                        i++;
                        stack.Push((int)Math.Round(Math.Log(num1, Math.E)));
                    }
                    else if (str.Substring(i, 3) == "cos")
                    {
                        i += 2;
                        stack.Push((int)Math.Round(Math.Cos(num1)));
                    }
                    else if (str.Substring(i, 3) == "sin")
                    {
                        i += 2;
                        stack.Push((int)Math.Round(Math.Sin(num1)));
                    }
                    else if (str.Substring(i, 4) == "sqrt")
                    {
                        i += 3;
                        stack.Push((int)Math.Round(Math.Sqrt(num1)));
                    }
                    break;
            }
        }

        return (int)stack.Pop();
    }
}