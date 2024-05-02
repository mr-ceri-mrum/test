using DataMatrix.Core.FiltersModels;
using DataMatrix.Core.IRepository.IBase;
using DataMatrix.Domain.DTOs;
using DataMatrix.Domain.Entities;

namespace DataMatrix.Core.IRepository;

public interface IOrderRepository : IRepo<Order, OrderDto>
{
    Task<IQueryable> GetByFilters(FilterOrderModel filters);
    Task<Order> CreatOrder(CreateOrderDto request, CancellationToken token);
}