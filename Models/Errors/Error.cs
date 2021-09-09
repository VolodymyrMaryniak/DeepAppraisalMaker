namespace AspNetCoreVueStarter.Models.Errors
{
    public class Error
    {
        public string Message { get; set; }
        public ErrorDetails[] Details { get; set; }
    }
}
