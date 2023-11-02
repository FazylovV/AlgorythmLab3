using AlgorythmLab3.Stack_and_Queue;

namespace AlgorythmLab3.Postfix;

public static class Calculator
{
    public static int Calculate(string str)
    {
        MyStack<int> stack = new MyStack<int>();
        string[] elements = str.Split(" ");
        for (int i = 0; i < elements.Length; i++)
        {
            string smth = elements[i];
            if(int.TryParse(smth, out int num))
            {
                stack.Push(num);
                continue;
            }

            int num1 = (int)stack.Pop();
            int num2;
            switch (smth)
            {
                case "+":
                    num2 = (int)stack.Pop();
                    stack.Push(num2 + num1);
                    break;
                
                case "-":
                    num2 = (int)stack.Pop();
                    stack.Push(num2 - num1);
                    break;
                
                case "*":
                    num2 = (int)stack.Pop();
                    stack.Push(num2 * num1);
                    break;
                
                case "/":
                    num2 = (int)stack.Pop();
                    stack.Push((int)Math.Round((double)(num2 / num1)));
                    break;
                
                case "^":
                    num2 = (int)stack.Pop();
                    stack.Push((int)Math.Pow(num2, num1));
                    break;
                
                case "ln":
                    stack.Push((int)Math.Round(Math.Log(num1, Math.E)));
                    break;
                    
                case "cos":
                    stack.Push((int)Math.Round(Math.Cos(num1)));
                    break;
                    
                case "sin":
                    stack.Push((int)Math.Round(Math.Sin(num1)));
                    break;
                
                case "sqrt":
                    stack.Push((int)Math.Round(Math.Sqrt(num1)));
                    break;
            }
        }

        return (int)stack.Pop();
    }
}