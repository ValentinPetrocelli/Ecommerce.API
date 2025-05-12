using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces
{
    public interface IJwtService
    {
        (string Token, DateTime Expiration) GenerateToken(User user);
    }
}
