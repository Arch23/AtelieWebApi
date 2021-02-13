using AutoMapper;
using Business.ApiModel;
using Model.Entity;

namespace IoC.Implementation.AutoMapper
{
    public class ApiModelProfile : Profile
    {
        public ApiModelProfile ()
        {
            CreateMap<MaterialApiModel, Material>();
            CreateMap<UnitApiModel, Unit>();
            CreateMap<UnitGroupApiModel, UnitGroup>();
        }
    }
}
