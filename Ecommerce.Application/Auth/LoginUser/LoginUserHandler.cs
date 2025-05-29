using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Auth.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public LoginUserHandler(IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email, cancellationToken)
                       ?? throw new ApplicationException("The user does not exist, please register");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new ApplicationException("Incorrect email or password");

            var (token, expiration) = _jwtService.GenerateToken(user);
            return new LoginUserResponse(token, expiration  );
        }
    }
}
