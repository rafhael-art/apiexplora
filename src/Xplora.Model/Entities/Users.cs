namespace Xplora.Model.Entities
{
  public class Users
  {
    public int UserId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }
}

