using MediatR;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.User.Queries.GetByEmail
{
  public class UserGetByEmailQuery : IRequest<BaseResponse<bool>>
  {
    public string Email { get; set; } = string.Empty;
    public int UserId { get; set; }
  }
}

