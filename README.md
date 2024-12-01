# SMS Service for OTP Delivery

This project provides a simple SMS service that integrates with an SMS provider to send One-Time Passwords (OTPs) for functionalities such as password resets. The service supports Egyptian mobile numbers and validates input data before processing.

## Technologies Used
Language: C# (.NET 8.0)
Framework: .NET Core
HTTP Client: Used for making GET requests to the SMS provider API.
Regex: For validating inputs such as phone numbers and OTPs.
Newtonsoft.Json: For parsing and handling JSON responses (if needed).
XML Parsing: To handle XML responses from the SMS provider.

---
## Features
Send OTPs: Generate and send OTPs via SMS.
Validation: Ensures the provided phone number matches the Egyptian format and verifies OTP length.
Error Handling: Handles API errors and invalid responses gracefully.
Extensible Design: Easily configurable API credentials and reusable code structure.

---
## Setup and Configuration
Step 1: Clone the Repository

Step 2: Install Dependencies
Ensure required dependencies are installed in the project:
``` bash
Newtonsoft.Json
System.Net.Http
System.Text.RegularExpressions
```
---

## Usage
### 1. Sending an OTP
The SmsService provides the SendOtp method for sending OTPs.

### 2.Validation
a) Phone Number
The phone number must:
Start with 01 followed by 0, 1, 2, or 5.
Be 11 digits long.

b) OTP
The OTP must:
Be exactly 6 digits.
Contain only numbers.
Validation is handled by the ValidationService.

### 3.ServiceResponse
The ServiceResponse class standardizes responses from the SMS service.
Structure:
_IsSuccess (bool): Indicates the operation's success status.
true: Successful operation.
false: Failed operation.
Message (string): Provides details about the result.
Success: A message from the SMS API (e.g., Success).
Failure: Error message or validation issue.

Response Output (Message):
- **Success**: The OTP was sent successfully.  
- **Error Fire**: An internal error occurred while sending the OTP.  
- **Msg ID Empty**: You sent an empty Msg ID.  
- **Mobile !Digit**: The mobile number contains non-digit characters.  
- **Body Empty**: The message body is empty.  
- **Validity length**: The validity length is incorrect.  
- **StartTime length**: The start time length is incorrect.  
- **Validity !Digit**: The validity contains non-digit characters.  
- **StartTime !Digit**: The start time contains non-digit characters.  
- **Sender more than 11 character**: The sender name is too long.  
- **Sender length**: The sender's length exceeds the allowed limit.  
- **Sender Arabic**: The sender name contains Arabic characters, which are not allowed.  
- **Sender Special Char**: The sender name contains special characters, which are not allowed.  
- **Invalid User**: The username or password is incorrect.  
- **User !Active**: The user is valid but not active.  







