using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SendSMS
{
    public class SmsService
    {
        private const string ApiUrl = "https://www.ezagel.com/portex_ws/service.asmx/Send_SMS";
        private const string User = "Edge-pro";
        private const string Password = "hM8-59";
        private const string Sender = "RSC";
        private const string Validity = "";
        private const string StartTime = "";
        private const string Service = "";
        private const string SmsTag = "OTP";

        public static async Task<ServiceResponse> SendOtp(string phoneNumber, string otp)
        {
            // Validate inputs
            string validationError = ValidationService.ValidateInputs(phoneNumber, otp);
            if (!string.IsNullOrEmpty(validationError))
            {
                return new ServiceResponse(false, validationError);
            }


            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Guid guid = Guid.NewGuid();
                    string requestUrl = $"{ApiUrl}?Msg_ID={guid}&Mobile_NO={phoneNumber}&Body=Your+OTP+is+{otp}&Validty={Validity}&StartTime={StartTime}&Sender={Sender}&User={User}&Password={Password}&Service={Service}&SMSTag={SmsTag}";

                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new ServiceResponse(false, responseContent);
                    }

                    return new ServiceResponse(true, responseContent);
                }
                catch (Exception ex)
                {
                    return new ServiceResponse(false, ex.Message);
                }
            }
        }
    }
}
