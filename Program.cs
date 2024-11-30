using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SendSMS
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json") 
                .Build();

            
            var smsSettings = configuration.GetSection("SmsSettings");

            string apiUrl = smsSettings["ApiUrl"];
            string sender = smsSettings["Sender"];
            string user = smsSettings["User"];
            string password = smsSettings["Password"];
            string service = smsSettings["Service"];
            string smsTag = smsSettings["SmsTag"];

            Console.Write("Enter an Egyptian phone number: ");
            string phoneNumber = Console.ReadLine();
            string validity = "";  
            string startTime = "";

            // Send OTP request
            var result = await SmsService.SendOtp(apiUrl, phoneNumber, validity, startTime, sender, user, password, service, smsTag);
            Console.WriteLine($"Result: {(result._IsSuccess ? "Success" : "Failed")}");
            Console.WriteLine($"Message: {result.Message}");
        }
    }
}
