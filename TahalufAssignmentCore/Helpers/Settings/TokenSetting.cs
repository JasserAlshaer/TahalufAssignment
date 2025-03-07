using Microsoft.Extensions.Configuration;

namespace TahalufAssignmentCore.Helpers.Settings
{
    public static class TokenSetting
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string Secret => _configuration["TokenSetting:Secret"];
        public static int ValidityTime => int.Parse(_configuration["TokenSetting:ValidityTime"]);
    }
}
