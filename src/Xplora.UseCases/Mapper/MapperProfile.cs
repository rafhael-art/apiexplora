using AutoMapper;
using Xplora.Model.Entities;
using Xplora.UseCases.UseCases.Product.Command.Insert;
using Xplora.UseCases.UseCases.User.Commands.Insert;

namespace Xplora.UseCases.Mapper
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<Users, UserInsertCommand>().ReverseMap();
      CreateMap<Products, ProductInsertCommand>().ReverseMap();
    }
  }
}

