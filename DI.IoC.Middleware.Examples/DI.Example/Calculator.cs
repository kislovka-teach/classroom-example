namespace DI.Example;

public class Calculator
{
    private ILogger _fileLogger;
    public Calculator(ILogger logger)
    {
        _fileLogger = logger;
    }
    
    public float Divide(float number1, float number2)
    {
        _fileLogger.LogInfo($"Операция деления: {number1} / {number2}");
        return number1 / number2;
    }

    public float Multiply(float number1, float number2)
    {
        _fileLogger.LogInfo($"Операция умножения: {number1} * {number2}");
        return number1 * number2;
    }

    public float Add(float number1, float number2)
    {
        _fileLogger.LogInfo($"Операция сложения: {number1} + {number2}");
        return number1 + number2;
    }

    public float Subtract(float number1, float number2)
    {
        _fileLogger.LogInfo($"Операция вычитания: {number1} - {number2}");
        return number1 - number2;
    }
}