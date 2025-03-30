using AutoMapper;
using Clivia.Core.Dtos;
using Clivia.Core.Models;

namespace Clivia.Application.Mappings // O tu namespace de mapeo
{
    public class HabitacionProfile : Profile
    {
        public HabitacionProfile()
        {
            // Mapeo de CrearHabitacionDto -> Habitacion
            CreateMap<CrearHabitacionDto, Habitacion>();
            // .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora el Id al crear

            // Mapeo de Habitacion -> HabitacionDto (para devolver en GET)
            CreateMap<Habitacion, HabitacionDto>()
                .ForMember(dest => dest.NombreEstadoHabitacion, opt => opt.MapFrom(src => src.EstadoHabitacion.Descripcion)) // Mapea nombres/descripciones
                .ForMember(dest => dest.DescripcionPiso, opt => opt.MapFrom(src => src.Piso.Descripcion))
                .ForMember(dest => dest.DescripcionCategoria, opt => opt.MapFrom(src => src.Categorias.Descripcion)) // Asumiendo que renombraste la prop de navegación
                .ForMember(dest => dest.NombrePropiedad, opt => opt.MapFrom(src => src.Propiedad.NombrePropiedad));
        }
    }
}