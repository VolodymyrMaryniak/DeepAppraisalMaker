﻿using AspNetCoreVueStarter.Cqrs.Commands.Results.Base;

namespace AspNetCoreVueStarter.Cqrs.Commands.Results
{
    public class CreateQuizCommandResult : CommandResult
    {
        public int Id { get; set; }
    }
}
