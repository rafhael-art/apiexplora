using MediatR;
using Xplora.Model.Entities;
using Xplora.Services.Interfaces;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.User.Commands.Update
{
  public class UserUpdateHandler : IRequestHandler<UserUpdateCommand, BaseResponse<Users>>
  {
    private readonly IUnitOfWork _unitOfWork;
    public UserUpdateHandler(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<Users>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
      BaseResponse<Users> response = new BaseResponse<Users>();
      try
      {
        if (await _unitOfWork.UserRepository.ExecAsync("USP_USER_UPDATE", request))
        {
          response.Data = await _unitOfWork.UserRepository.GetByIdAsync("USP_USER_GET_BY_ID", new { request.UserId });
          response.Message = "Datos actualizados correctamente";
        }
        else
        {
          response.IsSucces = false;
          response.Data = null;
          response.Message = "Error al actualizar Intentelo otra vez";
        }
      }
      catch (Exception ex)
      {
        response.IsSucces = false;
        response.Message = ex.Message;
      }
      return response;
    }
  }
}

