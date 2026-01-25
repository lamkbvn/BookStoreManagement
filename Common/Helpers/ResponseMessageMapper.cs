namespace WebBanHang.Common.Helpers;

public static class ResponseMessageMapper
{
    public static string Map(string httpMethod)
    {
        return httpMethod switch
        {
            "POST" => "Created successfully",
            "PUT" or "PATCH" => "Updated successfully",
            "DELETE" => "Deleted successfully",
            "GET" => "Success",
            _ => "Success"
        };
    }
}
