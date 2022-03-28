using System.Windows.Media;
using AutoMapper;
using HomeWork.Entities;
using HomeWork.Wrappers;
using UseCases.Dto;

namespace HomeWork.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ClientDto, ClientWrapper>()
            .ForCtorParam(
                "model", opt =>
                    opt.MapFrom(x => new Client
                    {
                        Name = x.Name,
                        Surname = x.Surname,
                        Accounts = x.Accounts,
                        Id = x.Id
                    }));

        CreateMap<ClientWrapper, ClientDto>();

        CreateMap<Account, AccountWrapper>()
            .ForCtorParam(
                "model", opt =>
                    opt.MapFrom(x => x));

        CreateMap<AccountWrapper, Account>();


    }
}