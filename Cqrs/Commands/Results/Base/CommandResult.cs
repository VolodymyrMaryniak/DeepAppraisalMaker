namespace AspNetCoreVueStarter.Cqrs.Commands.Results.Base
{
    public class CommandResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
