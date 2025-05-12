using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        void Add(User user);
    }
}
