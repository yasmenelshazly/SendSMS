using System.Collections.Generic;

public static class ResponseMapper
{
    public static readonly Dictionary<string, string> ResponseDescriptions = new Dictionary<string, string>
    {
        { "Success", "The OTP was sent successfully." },
        { "Error Fire", "An internal error occurred while sending the OTP." },
        { "Msg ID Empty", "You sent an empty Msg ID." },
        { "Mobile !Digit", "The mobile number contains non-digit characters." },
        { "Body Empty", "The message body is empty." },
        { "Validity length", "The validity length is incorrect." },
        { "StartTime length", "The start time length is incorrect." },
        { "Validity !Digit", "The validity contains non-digit characters." },
        { "StartTime !Digit", "The start time contains non-digit characters." },
        { "Sender more than 11 character", "The sender name is too long." },
        { "Sender length", "The sender's length exceeds the allowed limit." },
        { "Sender Arabic", "The sender name contains Arabic characters, which are not allowed." },
        { "Sender Special Char", "The sender name contains special characters, which are not allowed." },
        { "Invalid User", "The username or password is incorrect." },
        { "User !Active", "The user is valid but not active." }
    };

    public static string GetDescription(string responseText)
    {
        if (ResponseDescriptions.ContainsKey(responseText))
        {
            return ResponseDescriptions[responseText];
        }

        return $"Unknown response: {responseText}";
    }
}
