using System.Collections.Generic;
using HomeWork.Entities;

namespace UseCases.Dto;

public class ClientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Account> Accounts { get; set; }

}