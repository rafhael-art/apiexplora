using MediatR;
using Xplora.Services.Interfaces;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.User.Queries.GetByEmail
{
  public class UserGetByEmailHandler : IRequestHandler<UserGetByEmailQuery, BaseResponse<bool>>
  {
    private readonly IUnitOfWork _unitOfWork;
    public UserGetByEmailHandler(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(UserGetByEmailQuery request, CancellationToken cancellationToken)
    {
      BaseResponse<bool> response = new BaseResponse<bool>();
      var user = await _unitOfWork.UserRepository.GetByEmail(request.Email);
      if (user is null)
      {
        response.Data = false;
        return response;
      }

      if (user.UserId != request.UserId)
      {
        response.Data = true;
        response.Message = "Ya existe usuario con el mismo correo";
        return response;
      }

      response.Data = false;
      return response;
    }
  }
}

