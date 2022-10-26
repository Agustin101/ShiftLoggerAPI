using System.Globalization;

namespace UI
{
    public static class Helpers
    {
        public static DateTime GetDate()
        {
            string input = Console.ReadLine();
            DateTime date;

            while (!DateTime.TryParseExact(input,"yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine("Invalid format. Try again");
                input = Console.ReadLine();
            }

            return date;
        }

        internal static decimal GetValidDecimal()
        {
            string input = Console.ReadLine();

            while (!InputValidator.IsValidNumber(input))
            {
                Console.WriteLine("Please enter a valid number. Try again.");
                input = Console.ReadLine();
            }

            return decimal.Parse(input);
        }

        public static string? GetString()
        {
            string? input = Console.ReadLine();

            while (!InputValidator.IsValidInput(input))
            {
                Console.WriteLine("Please enter a valid number. Try again.");
                input = Console.ReadLine();
            }

            return input;
        }
    }
}