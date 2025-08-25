using AutoMapper;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Infrastructure
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {

            CreateMap<Esercizio, EserciziVM>().ForMember(dest => dest.EsercizioId, act => act.MapFrom(src => src.EsercizioId))
                    .ForMember(dest => dest.Ripetizioni, act => act.MapFrom(src => src.Ripetizioni))
                    .ForMember(dest => dest.Distanza, act => act.MapFrom(src => src.Distanza))
                    .ForMember(dest => dest.Recupero, act => act.MapFrom(src => src.Recupero))
                    .ForMember(dest => dest.Stile, act => act.MapFrom(src => "Libero"));    //TO DO
            ;
        }
    }
}
