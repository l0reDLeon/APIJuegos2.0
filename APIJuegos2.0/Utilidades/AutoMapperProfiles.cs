using APIJuegos2._0.DTOs;
using APIJuegos2._0.Entidades;
using AutoMapper;


namespace APIJuegos2._0.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<JuegosDTO, Juegos>();
            CreateMap<Juegos, GetJuegosDTO>();
        }
    }
}
