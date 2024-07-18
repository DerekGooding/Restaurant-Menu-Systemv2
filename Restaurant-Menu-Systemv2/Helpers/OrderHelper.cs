﻿using System.Text.RegularExpressions;

namespace Restaurant_Menu_System_V3.Helpers;

internal static partial class OrderHelper
{
    // collects user input and verifies it is valid and within the provided range
    public static int GetIntegerInput(string message, int minValue, int maxValue)
    {
        while (true)
        {
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("That is not a number...Please enter one of the provided numbers");
            }
            else if (input < minValue || input > maxValue)
            {
                Console.WriteLine("Error! Please enter one of the provided numbers");
            }
            else
            {
                return input;
            }
        }
    }

    // displays menu options with their prices
    public static void DisplayOrderOptions(string orderType, MenuOption[] options)
    {
        Console.WriteLine($"\n{orderType}");
        int itemCount = 1;
        foreach (MenuOption item in options)
        {
            if (item.Price == 0.00m)
            {
                Console.WriteLine($"{itemCount}. {item.ItemName.ToUpper()}");
            }
            else
            {
                Console.WriteLine($"{itemCount}. {item.ItemName.ToUpper()}....{item.Price.ToString("c")}");
            }
            itemCount++;
        }
    }

    // asks a yes/no question and returns the user's response as a boolean
    public static bool GetYesNoResponse(string question)
    {
        while (true)
        {
            Console.WriteLine($"{question}(Y/N)");
            string userResponse = Console.ReadLine() ?? string.Empty;

            if (userResponse.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (userResponse.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            Console.WriteLine("Please enter Y/N to continue.");
        }
    }

    // Validates the user's name to ensure it contains only alphabetical characters and spaces, and is between 1 and 26 characters long
    public static bool IsValidName(string? name) => name != null && MyRegex().IsMatch(name);

    [GeneratedRegex(@"^[a-zA-Z\s]{1,26}$")]
    private static partial Regex MyRegex();
}