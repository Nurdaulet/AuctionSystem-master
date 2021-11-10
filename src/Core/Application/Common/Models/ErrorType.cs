namespace Application.Common.Models
{
    public enum ErrorType
    {
        General,
        TokenExpired,
        AccountNotConfirmed,
    }

    public class UserIdWithBalance
    {
        public string UserId { get; set; }
        public decimal Balance { get; set; }
    }
}