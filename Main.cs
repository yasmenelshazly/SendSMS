using SendSMS;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter an Egyptian phone number:");
        string phoneNumber = Console.ReadLine();

        Console.WriteLine("Enter OTP:");
        string otp = Console.ReadLine();

        Console.WriteLine($"Sending OTP to {phoneNumber}...");

        var result = await SmsService.SendOtp(phoneNumber, otp);

        Console.WriteLine($"Result: {(result._IsSuccess ? "Success" : "Failed")}");
        Console.WriteLine($"Message: {result.Message}");
    }
}

