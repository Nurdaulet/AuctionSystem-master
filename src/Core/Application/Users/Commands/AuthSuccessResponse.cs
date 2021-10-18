namespace Application.Users.Commands
{
    using System;

    public class AuthSuccessResponse
    {
        public string Token { get; set; }
        public decimal Balance { get; set; }
        public Guid RefreshToken { get; set; }
    }
}