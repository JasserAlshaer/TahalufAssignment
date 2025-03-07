namespace TahalufAssignmentCore.Helpers
{
    public static class OTPHelper
    {
        public static string GenerateOTP()
        {
            Random random = new Random();
            string digits = "0123456789";
            char[] chars = new char[6];
            for (int i = 0; i < 6; i++)
            {
                chars[i] = digits[random.Next(digits.Length)];
            }
            return new string(chars);
        }
    }
}
