using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NiceTrue.Identity.Db;
using NiceTrue.Identity.Domain.Entities;

namespace NiceTrue.Identity.Users;

public abstract class ValidateSignupEmail
{
    public abstract record Query(string Email) : IRequest<bool>
    {
        public string Email { get; } = Email.ToLower();
    }

    public class SignupCommandValidator : AbstractValidator<Query>
    {
        public SignupCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }

    public class SignupCommandHandler(IdentityDbContext dbContext) : IRequestHandler<Query, bool>
    {
        public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            => await dbContext.Users.AnyAsync(u => u.Email == request.Email, cancellationToken);
    }
}