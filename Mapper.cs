using AutoMapper;
using [PROYECT_NAME].DTO.V1;
using [PROYECT_NAME].Entity.V1;

namespace [PROYECT_NAME].Mappers.V1;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EntityName, DtoName>().ReverseMap();

        // Puedes agregar más mapeos aquí si es necesario
    }
}
