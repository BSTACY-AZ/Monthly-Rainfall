using System;

class Program
{
    static void Main(string[] args)
    {
        // Constants for the number of months in a year
        const int numMonths = 12;

        // Arrays to store month names and rainfall amounts
        string[] monthNames = new string[numMonths];
        double[] rainfall = new double[numMonths];

        // Input monthly rainfall amounts
        for (int i = 0; i < numMonths; i++)
        {
            Console.Write($"Enter rainfall amount for {GetMonthName(i)}: ");
            if (double.TryParse(Console.ReadLine(), out double amount))
            {
                rainfall[i] = amount;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                i--; // Retry the current month
            }
        }

        // Calculate the average rainfall
        double totalRainfall = 0;
        foreach (var amount in rainfall)
        {
            totalRainfall += amount;
        }
        double averageRainfall = totalRainfall / numMonths;

        // Display the report
        Console.WriteLine("\nMonthly Rainfall Report:");
        Console.WriteLine("Month\tRainfall\tVariance from Mean");

        for (int i = 0; i < numMonths; i++)
        {
            double variance = rainfall[i] - averageRainfall;
            Console.WriteLine($"{GetMonthName(i)}\t{rainfall[i]}\t{variance:+0.00;-0.00}");
        }

        Console.WriteLine($"\nAverage Rainfall for the Year: {averageRainfall:F2} inches");
    }

    // Helper method to get month name based on its index
    static string GetMonthName(int monthIndex)
    {
        DateTime date = new DateTime(DateTime.Now.Year, monthIndex + 1, 1);
        return date.ToString("MMMM");
    }
}
