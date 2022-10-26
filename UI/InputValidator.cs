namespace UI
{
    internal class InputValidator
    {
        internal static bool IsValidInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }

            return true;
        }

        internal static bool IsValidNumber(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsDigit(c) && c != '.')
                    return false;
            }

            if (decimal.Parse(input) < 0)
                return false;

            return true;
        }
    }
}