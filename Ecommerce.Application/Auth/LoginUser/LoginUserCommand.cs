using MediatR;

namespace Ecommerce.Application.Auth.LoginUser
{
    public record LoginUserCommand(string Email, string Password) : IRequest<LoginUserResponse>;
}
