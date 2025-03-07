using Microsoft.Extensions.Options;
using MimeKit;
using TahalufAssignmentCore.Helpers.Settings;

namespace TahalufAssignmentCore.Helpers
{
    public static class EmailService
    {
        public static async Task<string> SendEmailUsingMailKetService(string? subject = "", string? email = "", string? code = "", string? message = "")
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("Interview Lab", EmailSetting.SenderEmail));
                mimeMessage.To.Add(new MailboxAddress("Interview Lab User", email));
                mimeMessage.Subject = subject;
                var builder = new BodyBuilder();
                string htmlTemplate = GenerateEmail(subject, email, code, message);
                builder.HtmlBody = htmlTemplate;
                mimeMessage.Body = builder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(EmailSetting.SmtpServer, EmailSetting.Port, false);
                    await client.AuthenticateAsync(EmailSetting.SenderUserName, EmailSetting.Password); // Use your username and password
                    var result = await client.SendAsync(mimeMessage);
                    await client.DisconnectAsync(true);
                }
                return $"Verification OTP Sent Successfully";
            }
            catch (Exception ex)
            {
                return $"Issue While Sending Email {ex.Message}";
            }
        }
        public static string GenerateEmail(string subject, string email, string code, string message)
        {
            // HTML Email Template with placeholders for dynamic content
            string emailTemplate = $@"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>{subject}</title>
            </head>
            <body style='font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f4f4f9; color: #333333;'>
                <table role='presentation' style='width: 100%; background-color: #f4f4f9; padding: 20px;'>
                    <tr>
                        <td>
                            <!-- Main Email Container -->
                            <table role='presentation' style='max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);'>
                                <!-- Header Section -->
                                <tr>
                                    <td style='background-color: #FF9B85; padding: 20px; text-align: center; border-top-left-radius: 8px; border-top-right-radius: 8px;'>
                                        <h1 style='color: white; font-size: 32px; margin: 0;'>Verification Process</h1>
                                    </td>
                                </tr>
                                <!-- Body Section -->
                                <tr>
                                    <td style='padding: 20px;'>
                                        <p style='font-size: 18px; color: #555555; line-height: 1.6;'>Dear {email},</p>
                                        <p style='font-size: 16px; color: #555555; line-height: 1.6;'>Welcome to [Interview Lab]! </p>
                                        <p style='font-size: 16px; color: #555555; line-height: 1.6;'>We are excited to inform you that {message}</p>
                                        <p style='font-size: 16px; color: #555555; line-height: 1.6;'>To complete Operation, please use the following verification code: </p>
                                        <p style='font-size: 16px; color: #555555; line-height: 1.6;'>Code: {code}</p>
                                        <p style='font-size: 16px; color: #555555; line-height: 1.6;'>Best regards, </p>
                                    </td>
                                </tr>
                                <!-- Footer Section -->
                                <tr>
                                    <td style='background-color: #FF9B85; padding: 10px; text-align: center; border-bottom-left-radius: 8px; border-bottom-right-radius: 8px;'>
                                        <p style='color: white; font-size: 14px; margin: 0;'>With warmth and kindness,</p>
                                        <p style='color: white; font-size: 14px; margin: 5px 0 0;'>Interview Lab Team</p>
                                    </td>
                                </tr>
                            </table>
                            <!-- End of Main Email Container -->
                        </td>
                    </tr>
                </table>
            </body>
            </html>";

            // Return the generated HTML template
            return emailTemplate;
        }
    }
}
