namespace SendSMS;

public class ServiceResponse
{
 
    public bool _IsSuccess;
    public string Message;
    public ServiceResponse(bool IsSuccess, string msg)
    {
        Message = msg;
        _IsSuccess = IsSuccess;
    }
}
