using AutoMapper;
using IdentityServer4.Contrib.Postgresql.Entities;
using System.Linq;

namespace IdentityServer4.Contrib.Postgresql.Mappers
{
    public class IdentityResourceMapperProfile : Profile
    {
        public IdentityResourceMapperProfile()
        {


            // entity to model
            CreateMap<IdentityResource, Models.IdentityResource>(MemberList.Destination)
                    .ForMember(x => x.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(x => x.Type)));

            // model to entity
            CreateMap<Models.IdentityResource, IdentityResource>(MemberList.Source)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => new IdentityClaim { Type = x })));
        }
    }
}
