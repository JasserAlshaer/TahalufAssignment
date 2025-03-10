using System.Text.RegularExpressions;

namespace TahalufAssignmentCore.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidInternationalPhone(string phoneNumber)
        {
            // Regular expression for international phone number format
            string pattern = @"^\+\d{1,3}\s?\d{1,14}(\s\d{1,13})?$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        public static bool IsValidCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return false;

            // Check if length is <= 5 and contains no spaces
            return code.Length <= 5 && !code.Contains(" ");
        }
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
    }
}
