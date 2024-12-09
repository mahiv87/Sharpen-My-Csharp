class Program
{
      // Addition
      static int Add(int x, int y) => x + y;

      // Subtraction
      static int Subtract(int x, int y) => x - y;
      
      // Multiplication
      static int Multiply(int x, int y) => x * y;

      // Division
      static int Divide(int x, int y) => x / y;

  static void Main(string[] args)
    {
      Console.WriteLine("Let's calculate!");

      var operations = new Dictionary<string, Func<int, int, int>>()
      {
        {"+", Add},
        {"-", Subtract},
        {"*", Multiply},
        {"/", Divide},
      };

      Calculator(operations);
    }

    static void Calculator(Dictionary<string, Func<int, int, int>>? operations)
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

          Console.WriteLine($"Type \"y\" to continue calculating with {answer}, or type \"n\" to start a new calculation. Type \"x\" to exit");

          string proceed = Console.ReadLine();

          if (proceed.ToLower().Equals("y"))
          {
            numX = answer;
          }
          else if (proceed.ToLower().Equals("n"))
          {
            shouldContinue = false;
            Calculator(operations);
          }
          else
          {
          shouldContinue = false;
          }
        }
      }
}