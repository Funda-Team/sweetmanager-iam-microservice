﻿namespace IamService.Domain.Model.Commands.Authentication.User;

public record UpdateUserCommand(int Id, string Change, string Value);