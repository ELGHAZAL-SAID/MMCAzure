using AutoMapper;
using MMC.Application.DTOs.PartnerDTOs;
using MMC.Application.DTOs.SponsorDTOs;
using MMC.Application.DTOs.SupportDTOs;
using MMC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Mapping;

internal class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Sponsor, SponsorDTO>().ReverseMap();
        CreateMap<Sponsor, UpdateSponsorDTO>().ReverseMap();
        CreateMap<Sponsor, AddSponsorDTO>().ReverseMap();


        CreateMap<Partner, PartnerDTO>().ReverseMap();
        CreateMap<Partner, UpdatePartnerDTO>().ReverseMap();
        CreateMap<Partner, AddPartnerDTO>().ReverseMap();


        CreateMap<PresentationSupport, SupportDTO>().ReverseMap();
        CreateMap<PresentationSupport, UpdateSupportDTO>().ReverseMap();
        CreateMap<PresentationSupport, AddSupportDTO>().ReverseMap();

    }
}
