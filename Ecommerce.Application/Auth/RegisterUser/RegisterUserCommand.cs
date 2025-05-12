using MediatR;

namespace Ecommerce.Application.Auth.RegisterUser
{
    public record RegisterUserCommand(string Email, string Password) : IRequest<Guid>;
}
