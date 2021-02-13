using AutoMapper;
using Business.ApiModel;
using Model.Entity;

namespace IoC.Implementation.AutoMapper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Material, MaterialApiModel>();
            CreateMap<Unit, UnitApiModel>();
            CreateMap<UnitGroup, UnitGroupApiModel>();
        }
    }
}
