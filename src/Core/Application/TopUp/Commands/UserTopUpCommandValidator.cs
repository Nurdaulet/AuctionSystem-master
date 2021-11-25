



namespace Application.TopUp.Commands
{
    using FluentValidation;
    public class UserTopUpCommandValidator: AbstractValidator<UserTopUpCommand>
    {
       public UserTopUpCommandValidator()
        {
            this.RuleFor(p => p.Amount).NotEmpty().GreaterThan(0);
            this.RuleFor(p => p.UserId).NotEmpty();
        } 
    }
}