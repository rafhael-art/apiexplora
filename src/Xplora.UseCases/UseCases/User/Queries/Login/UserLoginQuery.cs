using MediatR;
using Xplora.Model.Entities;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.User.Queries.Login
{
  public class UserLoginQuery : IRequest<BaseResponse<Users>>
  {
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }
}

