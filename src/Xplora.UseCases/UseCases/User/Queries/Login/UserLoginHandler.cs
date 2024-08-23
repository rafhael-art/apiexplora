using AutoMapper;
using MediatR;
using Xplora.Model.Entities;
using Xplora.Services.Interfaces;
using Xplora.UseCases.Bases;
using BC = BCrypt.Net.BCrypt;

namespace Xplora.UseCases.UseCases.User.Queries.Login
{
  public class UserLoginHandler : IRequestHandler<UserLoginQuery, BaseResponse<Users>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserLoginHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<BaseResponse<Users>> Handle(UserLoginQuery request, CancellationToken cancellationToken)
    {
      BaseResponse<Users> response = new();
      var user = await _unitOfWork.UserRepository.GetByEmail(request.Email);
      if (user is null)
      {
        response.IsSucces = false;
        response.Data = null;
        response.Message = "Usuario no Existe";
        return response;
      }
      if (!BC.Verify(request.Password, user.Password))
      {
        response.IsSucces = false;
        response.Data = null;
        response.Message = "Contraseña incorrecta";
        return response;
      }
      response.Data = user;
      response.Message = "Credenciales Correctas";
      return response;

    }
  }
}

