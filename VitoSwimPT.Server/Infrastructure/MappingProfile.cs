using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.Users;
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
                    .ForMember(dest => dest.Recupero, act => act.MapFrom(src => src.Recupero));

            CreateMap<Allenamento, EserciziAllenamentiVM>().ForMember(dest => dest.allenamentoId, act => act.MapFrom(src => src.AllenamentoId))
                 .ForMember(dest => dest.nomeAllenamento, act => act.MapFrom(src => src.NomeAllenamento))
                 .ForMember(dest => dest.note, act => act.MapFrom(src => src.Note));


        }
    }
}


//CreateMap<Piano, PianiAllenamentoVM>().ForMember(dest => dest.piano.PianoId, act => act.MapFrom(src => src.PianoId))
//    .ForMember(dest => dest.piano.NomePiano, act => act.MapFrom(src => src.NomePiano))
//    .ForMember(dest => dest.piano.Descrizione, act => act.MapFrom(src => src.Descrizione))
//    .ForMember(dest => dest.piano.Note, act => act.MapFrom(src => src.Note))
//    .ForMember(dest => dest.piano.InsertDateTime, act => act.MapFrom(src => src.InsertDateTime))
//    .ForMember(dest => dest.piano.Createdby, act => act.MapFrom(src => src.Createdby))
//    .ForMember(dest => dest.piano.UpdateDateTime, act => act.MapFrom(src => src.UpdateDateTime))
//    .ForMember(dest => dest.piano.Utente, act => act.MapFrom(src => src.Utente));

//.ForMember(dest => dest.Stile, act => act.MapFrom(src => "Libero"));