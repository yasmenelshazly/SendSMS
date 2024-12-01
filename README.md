# SMS Service for OTP Delivery

This project provides a simple SMS service that integrates with an SMS provider to send One-Time Passwords (OTPs) for functionalities such as password resets. The service supports Egyptian mobile numbers and validates input data before processing.

## Technologies Used
Language: C# (.NET 8.0)
Framework: .NET Core
HTTP Client: Used for making GET requests to the SMS provider API.
Regex: For validating inputs such as phone numbers and OTPs.
Newtonsoft.Json: For parsing and handling JSON responses (if needed).
XML Parsing: To handle XML responses from the SMS provider.

## Features
Send OTPs: Generate and send OTPs via SMS.
Validation: Ensures the provided phone number matches the Egyptian format and verifies OTP length.
Error Handling: Handles API errors and invalid responses gracefully.
Extensible Design: Easily configurable API credentials and reusable code structure.

## Setup and Configuration
Step 1: Clone the Repository

Step 2: Install Dependencies
Ensure required dependencies are installed in the project:
```Newtonsoft.Json
System.Net.Http
System.Text.RegularExpressions```





