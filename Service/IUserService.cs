﻿namespace FinalApplication.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}