using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;

namespace Works.DeveloperEvaluation.Application.Autores.AlterarAutor;

public class AlterarAutorProfile : Profile
{
    public AlterarAutorProfile()
    {
        CreateMap<AlterarAutorCommand, Autor>();
        CreateMap<Autor, AlterarAutorResult>();
    }
}
