using AutoMapper;
using MediatR;
using Xplora.Model.Entities;
using Xplora.Services.Interfaces;
using Xplora.UseCases.Bases;
using BC = BCrypt.Net.BCrypt;

namespace Xplora.UseCases.UseCases.User.Commands.Insert
{
  public class UserInsertHandler : IRequestHandler<UserInsertCommand, BaseResponse<int>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserInsertHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<BaseResponse<int>> Handle(UserInsertCommand request, CancellationToken cancellationToken)
    {
      BaseResponse<int> response = new();
      request.Password = BC.HashPassword(request.Password);
      var userModel = _mapper.Map<Users>(request);
      response.Data = await _unitOfWork.UserRepository.InsertAsync("USP_USER_INSERT", userModel);
      response.Message = "Usuario Registrado Correctamente";
      return response;
    }
  }
}

