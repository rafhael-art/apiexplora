using MediatR;
using Xplora.Model.Entities;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.User.Commands.Update
{
  public class UserUpdateCommand : IRequest<BaseResponse<Users>>
  {
    public int UserId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
  }
}

