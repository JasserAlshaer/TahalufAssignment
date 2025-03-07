using Microsoft.Extensions.Configuration;

namespace TahalufAssignmentCore.Helpers.Settings
{
    public static class EmailSetting
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string SmtpServer => _configuration["EmailSetting:SmtpServer"];
        public static int Port => int.Parse(_configuration["EmailSetting:Port"]);
        public static string SenderUserName => _configuration["EmailSetting:SenderUserName"];
        public static string SenderEmail => _configuration["EmailSetting:SenderEmail"];
        public static string SenderName => _configuration["EmailSetting:SenderName"];
        public static string Password => _configuration["EmailSetting:Password"];
        public static bool UseSSL { get; set; } = true;
    }
}
