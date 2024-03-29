

using AutoMapper;
using SGAS.IdentityServer.Quickstart.Account;
using SGAS.IdSvr.Entidade;

namespace SGAS.IdentityServer.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Funcao, FuncaoViewModel>()
                .ForMember(x => x.FuncaoId, opt => opt.MapFrom(a => a.Id))
                .ForMember(x => x.Nome, opt => opt.MapFrom(a => a.Name));
        }
    }
}
