using FluentValidation.Results;

namespace Xplora.UseCases.Bases
{
  public class BaseResponse<T>
  {
    public bool IsSucces { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public IEnumerable<ValidationFailure>? Errors { get; set; }
    public BaseResponse()
    {
      IsSucces = true;
    }
  }
}

