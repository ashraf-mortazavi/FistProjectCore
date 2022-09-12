namespace PhonBook.Middleware
{
  public class Mymiddelware
  {
    private readonly RequestDelegate _next;
    private static string path ="friends-json";
    public Mymiddelware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext httpContext)
    {
        if(httpContext.Request.Path == path)
        {
           _next(httpContext);
        }
        
    }
  }
}