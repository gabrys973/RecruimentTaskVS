﻿namespace MinimalApi.Web.Authorization.Models;

public record User
{
    public string Username { get; set; }
    public string Password { get; set; }
}