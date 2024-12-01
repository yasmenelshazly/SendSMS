using System;
using System.Text.RegularExpressions;

public static class ValidationService
{
    
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        
        var phonePattern = @"^\+?20\d{10}$"; 
        return Regex.IsMatch(phoneNumber, phonePattern);
    }

    
    public static bool IsValidOtp(string otp)
    {
        return otp.Length == 6 && int.TryParse(otp, out _);
    }

    
    public static bool IsNotEmpty(string input)
    {
        return !string.IsNullOrEmpty(input);
    }
}
