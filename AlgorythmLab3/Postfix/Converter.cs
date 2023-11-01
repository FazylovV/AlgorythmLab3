using System.Text;
using AlgorythmLab3.Stack_and_Queue;

namespace AlgorythmLab3.Postfix;

public class Converter
{
    MyStack<char> st = new MyStack<char>();
    private Stack<char> s = new Stack<char>();
    private string str_in = Console.ReadLine();
    private char last = ' ';
    protected StringBuilder str_out = new StringBuilder();

    public int prior(char h)
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

    public void algorithm()
    {
        //здесь преобразуем строку в постфиксную. например 1*2+3  будет 12*3+
        foreach (char x in str_in)
        {
            if (x == '-' && Char.IsLetterOrDigit(last) == false)
            {
                str_out.Append(x);
                continue;
            }

            if (char.IsLetterOrDigit(x) || x == '.') str_out.Append(x);
            else if (x == '(')
            {
                s.Push(x);
            }
            else if (x == ')')
            {
                while (s.Peek() != '(')
                {
                    str_out.Append(" ");
                    str_out.Append(s.Pop());
                }

                s.Pop();
            }
            else
            {
                while (s.Count > 0 && prior(s.Peek()) >= prior(x))
                {
                    str_out.Append(" ").Append(s.Pop());
                }

                s.Push(x);
            }

            if (x == '+' || x == '-' || x == '*' || x == '/' || x == '^') str_out.Append(" ");

            last = x;
        }

        while (s.Count > 0)
        {
            str_out.Append(" ");
            str_out.Append(s.Pop());
        }
        //Console.WriteLine(str_out);            
    }

    public void calculate(string s)
    {
        MyStack<int> stack = new MyStack<int>();
    }

    public double operation(string a, string b, string c)
    {
        double d = 0;
        switch (c)
        {
            case "*":
            {
                d = Convert.ToDouble(a) * Convert.ToDouble(b);
                break;
            }
            case "/":
            {
                d = Convert.ToDouble(a) / Convert.ToDouble(b);
                break;
            }
            case "+":
            {
                d = Convert.ToDouble(a) + Convert.ToDouble(b);
                break;
            }
            case "-":
            {
                d = Convert.ToDouble(a) * Convert.ToDouble(b);
                break;
            }
        }

        return d;
    }
}