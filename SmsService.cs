using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SendSMS
{
    public static class SmsService
    {
        public static async Task<ServiceResponse> SendOtp(string apiUrl, string phoneNumber, string validity, string startTime, string sender, string user, string password, string service, string smsTag)
        {
           
            Random random = new Random();
            string otp = random.Next(100000, 999999).ToString();

            
            string validationMessage = ValidationService.ValidateInputs(phoneNumber, otp);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                return new ServiceResponse(false, validationMessage); 
            }

            
            string body = $"Your OTP is {otp}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    
                    string encodedBody = Uri.EscapeDataString(body);

                    
                    Guid guid = Guid.NewGuid();
                    string requestUrl = $"{apiUrl}?Msg_ID={guid}&Mobile_NO={phoneNumber}&Body={encodedBody}&Validty={validity}&StartTime={startTime}&Sender={sender}&User={user}&Password={password}&Service={service}&SMSTag={smsTag}";

                    
                    Uri uri = new Uri(requestUrl);

                    
                    HttpResponseMessage response = await client.GetAsync(uri);
                    string responseContent = await response.Content.ReadAsStringAsync();

                    
                    string resultMessage = ParseXmlResponse(responseContent);

                    
                    if (resultMessage.Equals("Success", StringComparison.OrdinalIgnoreCase))
                    {
                        return new ServiceResponse(true, "OTP sent successfully.");
                    }
                    else
                    {
                        return new ServiceResponse(false, $"Failed to send OTP: {resultMessage}");
                    }
                }
                catch (Exception ex)
                {
                    return new ServiceResponse(false, $"Error: {ex.Message}");
                }
            }
        }

       
        private static string ParseXmlResponse(string responseContent)
        {
            try
            {
                XElement xml = XElement.Parse(responseContent);
                return xml.Value;
            }
            catch (Exception ex)
            {
                return $"Error parsing XML response: {ex.Message}";
            }
        }
    }
}
