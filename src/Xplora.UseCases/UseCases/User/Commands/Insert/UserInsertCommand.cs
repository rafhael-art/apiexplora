using MediatR;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.User.Commands.Insert
{
  public class UserInsertCommand : IRequest<BaseResponse<int>>
  {

    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }
}

