namespace AlgorythmLab3.Postfix;

public class PostfixConsole
{
    public static void GetPostfixAndCalculate()
    {
        Console.WriteLine("Введите выражение, которое вы хотите посчитать, разделяя числа и операции пробелами.");
        string normal = Console.ReadLine();;
        while (normal == null)
        {
            Console.WriteLine("Выражение не должно быть пустое!");
            Console.Write("Ввод: ");
            normal = Console.ReadLine();
        }
        
        Console.Write("В постфиксной записе: ");
        string postfix = Converter.ConvertToPostfix(normal).Substring(0);
        Console.WriteLine(postfix);
        
        Console.Write("Ответ: ");
        Console.WriteLine(Calculator.Calculate(postfix));
    }
}