using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Linq;

namespace SendSMS
{
    public static class SmsService
    {
        public static async Task<ServiceResponse> SendOtp( IConfiguration configuration , string Msg_ID, string phoneNumber)
        {
            string ZagelSmsUrlApi =  configuration.GetSection("SmsSettings:ApiUrl").Value ?? "";
            string ZagelSmsMsgContent =  configuration.GetSection("SmsSettings:MSGContent").Value ?? "";
            string ZagelSmsUser = configuration.GetSection("SmsSettings:User").Value ?? "";
            string ZagelSmsPassword = configuration.GetSection("SmsSettings:Password").Value ?? "";
            string ZagelSmsSender = configuration.GetSection("SmsSettings:Sender").Value ?? "";
            string ZagelSmsValidity = configuration.GetSection("SmsSettings:Validity").Value ?? "";
            string ZagelSmsStartTime = configuration.GetSection("SmsSettings:StartTime").Value ?? "";
            string ZagelSmsService = configuration.GetSection("SmsSettings:Service").Value ?? "";
            string ZagelSmsSmsTag = configuration.GetSection("SmsSettings:SmsTag").Value ?? "";

            if (string.IsNullOrEmpty(phoneNumber) || !ValidationService.IsValidPhoneNumber(phoneNumber))
            {
                return new ServiceResponse(false, "Invalid phone number format.");
            }

           
            Random random = new Random();
            string otp = random.Next(100000, 999999).ToString();

            
            if (string.IsNullOrEmpty(phoneNumber) || !ValidationService.IsValidOtp(otp))
            {
                return new ServiceResponse(false, "Generated OTP is invalid.");
            }

            
            string body = ZagelSmsMsgContent.Replace("X" , otp);

            
            if (!ValidationService.IsNotEmpty(body))
            {
                return new ServiceResponse(false, "Message body is empty.");
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    
                    string encodedBody = Uri.EscapeDataString(body);
                    Guid guid = Guid.NewGuid();
                    string requestUrl = $"{ZagelSmsUrlApi}?Msg_ID={guid}&Mobile_NO={phoneNumber}&Body={encodedBody}&Validty={ZagelSmsValidity}&StartTime={ZagelSmsStartTime}&Sender={ZagelSmsSender}&User={ZagelSmsUser}&Password={ZagelSmsPassword}&Service={ZagelSmsService}&SMSTag={ZagelSmsSmsTag}";
                    Uri uri = new Uri(requestUrl);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    string resultMessage = ParseXmlResponse(responseContent);
                    string description = ResponseMapper.GetDescription(resultMessage);

                    
                    return new ServiceResponse(true, description);
                }
                catch (Exception ex)
                {
                    return new ServiceResponse(false, $"Error: {ex.Message}");
                }
            }
        }

        // Method to parse the XML response and extract the message
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
