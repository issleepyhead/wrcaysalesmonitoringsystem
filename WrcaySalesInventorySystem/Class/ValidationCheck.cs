using System.Text.RegularExpressions;

namespace WrcaySalesInventorySystem.Class
{
    public class ValidationCheck
    {
        public static bool ValidateInput(string input, InputType type, int length = 3)
        {
            input = input.Trim();
            switch (type)
            {
                case InputType.STRING_INPUT:
                    if (string.IsNullOrEmpty(input) || input.Length < length)
                        return false;
                    break;
                case InputType.NUMERIC_INPUT:
                    input = input.TrimStart('0');
                    if (!Regex.IsMatch(input, @"^(\d+)?\.?(\d+)$"))
                        return false;
                    break;
                case InputType.PHONE_INPUT:
                    if (!Regex.IsMatch(input, @"^(\+639|09)\d{2}[-\s]?\d{3}[-\s]?\d{4}$"))
                        return false;
                    break;
                case InputType.PASSWORD_INPUT:
                    break;
                case InputType.USERNAME_INPUT:
                    break;
            }
            return true;
        }

    }

    public enum InputType
    {
        STRING_INPUT,
        NUMERIC_INPUT,
        PHONE_INPUT,
        PASSWORD_INPUT,
        USERNAME_INPUT
    }
}
