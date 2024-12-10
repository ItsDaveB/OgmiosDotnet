
using AutoMapper;
using Ogmios.Example.Database.Entities;

namespace Ogmios.Example.Worker.Mappers;

public class TransactionMapping : Profile
{
    public TransactionMapping()
    {
        CreateMap<Generated.Transaction, Transaction>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => (string)src.Id));
    }
}
