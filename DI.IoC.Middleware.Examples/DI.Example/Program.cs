using DI.Example;

var number1 = GetNumber("Enter the first number: > ");
var number2 = GetNumber("Enter the second number: > ");
var operation = GetOperator();
var calc = new Calculator();
var result = GetResult(calc, number1, number2, operation);
Console.WriteLine($"{number1} {operation} {number2} = {result}");
Console.Write("Press any key to continue...");
Console.ReadKey();


static float GetNumber(string message)
{
    var isValid = false;
    while (!isValid)
    {
        Console.Write(message);
        var input = Console.ReadLine();
        isValid = float.TryParse(input, out var number);
        if (isValid)
            return number;

        Console.WriteLine("Please enter a valid number. Press ^C to quit.");
    }

    return -1;
}

static char GetOperator()
{
    var isValid = false;
    while (!isValid)
    {
        Console.Write("Please type the operator (/*+-) > ");
        var input = Console.ReadKey();
        Console.WriteLine();
        var operation = input.KeyChar;
        if ("/*+-".Contains(operation))
        {
            isValid = true;
            return operation;
        }

        Console.WriteLine("Please enter a valid operator (/, *, +, or -). " +
                          "Press ^C to quit.");
    }

    return ' ';
}

static float GetResult(Calculator calc, float number1, float number2, 
    char operation)
{
    switch (operation)
    {
        case '/': return calc.Divide(number1, number2);
        case '*': return calc.Multiply(number1, number2);
        case '+': return calc.Add(number1, number2);
        case '-': return calc.Subtract(number1, number2);
        default:
            // Такого произойти не должно, если с предыдущими валидациями все было нормально 
            throw new InvalidOperationException("Invalid operation passed: " + 
                                                operation);
    }
}


