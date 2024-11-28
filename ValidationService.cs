using System;
using System.Text.RegularExpressions;

namespace SendSMS
{
    public static class ValidationService
    {
        public static string ValidateInputs(string phoneNumber, string otp)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return "Phone number cannot be empty.";
            }

            if (!Regex.IsMatch(phoneNumber, @"^01[0125]\d{8}$"))
            {
                return "Invalid Egyptian mobile number. It must start with 01 followed by 0, 1, 2, or 5 and contain 11 digits.";
            }

            // Validate OTP
            if (string.IsNullOrWhiteSpace(otp))
            {
                return "OTP cannot be empty.";
            }

            if (!Regex.IsMatch(otp, @"^\d{6}$"))
            {
                return "Invalid OTP. It must be a 6-digit numeric value.";
            }

            return null; 
        }
    }
}
