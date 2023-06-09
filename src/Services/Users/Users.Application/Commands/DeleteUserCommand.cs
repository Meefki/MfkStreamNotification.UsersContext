﻿namespace Users.Application.Commands;

public class DeleteUserCommand
    : IRequest<bool>
{
    public string UserId { get; set; }

    public DeleteUserCommand(string userId)
    {
        UserId = userId;
    }
}
