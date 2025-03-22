using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Dtos;

namespace MasterData.Application.Mappers;

public class RecruitmentCampaignMappingProfile : Profile
{
    public RecruitmentCampaignMappingProfile()
    {
        CreateMap<RecruitmentCampaign, RecruitmentCampaignDto>()
            .ReverseMap();
    }
}