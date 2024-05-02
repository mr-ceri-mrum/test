using AutoMapper;
using DataMatrix.Domain.DTOs;
using DataMatrix.Domain.Entities;

namespace DataMatrix.Core.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDto>();
    }
}