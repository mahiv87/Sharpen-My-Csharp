class Program
{

      // Addition
      static int add(int x, int y)
      {
        return x + y;
      }

      // Subtraction
      static int subtract(int x, int y)
      {
        return x - y;
      }

      // Multiplication
      static int multiply(int x, int y)
      {
        return x * y;
      }

      // Division
      static int divide(int x, int y)
      {
        return x / y;
      }
  static void Main(string[] args)
    {
      Console.WriteLine("Let's calculate!");

      var operations = new Dictionary<string, Func<int, int, int>>()
      {
        {"+", add},
        {"-", subtract},
        {"*", multiply},
        {"/", divide},
      };

      calculator(operations);
    }

    static void calculator(Dictionary<string, Func<int, int, int>>? operations)
      {
        Console.WriteLine("What is the first number?");
        int numX = Convert.ToInt32(Console.ReadLine());

        foreach (var op in operations)
        {
          Console.WriteLine($"{op.Key} : {op.Value.Method.Name}");
        }

        bool shouldContinue = true;

        while (shouldContinue)
        {
          Console.WriteLine("Pick an operation: ");
          string opSelection = Console.ReadLine();

          Console.WriteLine("What is the second number?");
          int numY = Convert.ToInt32(Console.ReadLine());
          Func<int, int, int> calc = operations[opSelection];
          int answer = calc(numX, numY);

          Console.WriteLine($"{numX} {opSelection} {numY} = {answer}");

          shouldContinue = false;
        }

      }
}