using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Documents;
using AutoMapper;
using HomeWork.Entities;
using UseCases.Dto;

namespace UseCases.Utils;

public class DbMapper : Profile
{
    public DbMapper()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<ClientDto, Client>();

    }
}