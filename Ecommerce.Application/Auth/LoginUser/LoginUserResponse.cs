namespace Ecommerce.Application.Auth.LoginUser
{
    public record LoginUserResponse(string Token, DateTime Expiration);
}
