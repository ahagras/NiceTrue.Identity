using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NiceTrue.Identity.Db;
using NiceTrue.Identity.Domain.Entities;

namespace NiceTrue.Identity.Users;

public abstract class Signup
{
    public abstract record Command(string Name, string Email, string Password) : IRequest<string>
    {
        public string Name { get; } = Name;
        public string Email { get; } = Email.ToLower();
        public string Password { get; } = Password;
    }

    public class SignupCommandValidator : AbstractValidator<Command>
    {
        public SignupCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
    
    public class SignupCommandHandler(IdentityDbContext dbContext) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var userIsExists = await dbContext.Users.AnyAsync(u => u.Email == request.Email, cancellationToken);

            if (!userIsExists)
                return "";

            var user = User.Create(request.Name, request.Email, request.Password);

            dbContext.Users.Add(user);

            await dbContext.SaveChangesAsync(cancellationToken);

            return user.Id.ToString();
        }
    }
}