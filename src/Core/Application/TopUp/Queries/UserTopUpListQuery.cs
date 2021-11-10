

namespace Application.TopUp.Queries
{
    public class UserTopUpListQuery
    {
        public UserTopUpListQuery(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; }
        
    }
}