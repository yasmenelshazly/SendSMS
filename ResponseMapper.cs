using System.Collections.Generic;

public static class ResponseMapper
{
    public static readonly Dictionary<string, string> ResponseDescriptions = new Dictionary<string, string>
    {
        { "Success", "The message spooled and logged successfully." },
        { "Error Fire", "An internal error occurred." },
        { "Msg ID Empty", "You sent an empty MSG ID." },
        { "Mobile !Digit", "The mobile number contains non-digit characters." },
        { "Body Empty", "The body is empty." },
        { "Validity length", "The validity length is not 12 characters." },
        { "StartTime length", "The start time length is not 12 characters." },
        { "Validity !Digit", "The validity contains non-digit characters." },
        { "StartTime !Digit", "The start time contains non-digit characters." },
        { "Sender more than 11 character", "The sender alphanumeric value is more than 11 characters." },
        { "Sender length", "The sender's length exceeds 20 characters." },
        { "Sender Arabic", "The sender does not support Arabic." },
        { "Sender Special Char", "The sender does not support special characters." },
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

