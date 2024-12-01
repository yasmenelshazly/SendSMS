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

            
            string msgId = Guid.NewGuid().ToString(); 
            string phoneNumber = "+201021545146";  
            string validity = "";  
            string startTime = ""; 

            
            var result = await SmsService.SendOtp(configuration , msgId, phoneNumber);

            
            Console.WriteLine($"Result: {(result._IsSuccess ? "Success" : "Failed")}");
            Console.WriteLine($"Message: {result.Message}");
        }
    }
}
