using System;
using System.Diagnostics.CodeAnalysis;

public class Temperature
{
    private double celsius;

    public Temperature(double value, string scale)
    {
        switch (scale.ToLower())
        {
            case "c":
                this.celsius = value;
                break;
            case "f":
                this.celsius = (value - 32) * 5 / 9;
                break;
            case "r":
                this.celsius = (value - 491.67) * 5 / 9;
                break;
            case "k":
                this.celsius = value - 273.15;
                break;
            default:
                throw new ArgumentException("Invalid temperature scale.");
        }
    }

    public static Temperature operator +(Temperature t1, Temperature t2)
    {
        return new Temperature(t1.celsius + t2.celsius, "c");
    }

    public static Temperature operator -(Temperature t1, Temperature t2)
    {
        return new Temperature(t1.celsius - t2.celsius, "c");
    }

    public static Temperature operator *(Temperature t1, Temperature t2)
    {
        return new Temperature(t1.celsius * t2.celsius, "c");
    }

    public static Temperature operator /(Temperature t1, Temperature t2)
    {
        if (t2.celsius == 0)
        {
            throw new DivideByZeroException("Error: Division by zero!");
        }
        return new Temperature(t1.celsius / t2.celsius, "c");
    }

    public override string ToString()
    {
        return celsius + "°C";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первую температуру (C - цельсии, F - Фарингейта, R - Ранкина, K - Кельвины):");
        string input1 = Console.ReadLine();
        string[] parts1 = input1.Split(' ');
        double value1 = double.Parse(parts1[0]);
        string scale1 = parts1[1];

        Console.WriteLine("Введите вторую температуру (C - цельсии, F - Фарингейта, R - Ранкина, K - Кельвины):");
        string input2 = Console.ReadLine();
        string[] parts2 = input2.Split(' ');
        double value2 = double.Parse(parts2[0]);
        string scale2 = parts2[1];

        Temperature temp1 = new Temperature(value1, scale1);
        Temperature temp2 = new Temperature(value2, scale2);

        // Сложение
        Temperature resultSum = temp1 + temp2;
        Console.WriteLine("Сумма температур: " + resultSum);

        // Вычитание
        Temperature resultSub = temp1 - temp2;
        Console.WriteLine("Разница температур: " + resultSub);

        // Умножение
        Temperature resultMul = temp1 * temp2;
        Console.WriteLine("Результат умножения температур: " + resultMul);

        // Деление
        Temperature resultDiv = temp1 / temp2;
        Console.WriteLine("Результат деления температур: " + resultDiv);
    }
}
