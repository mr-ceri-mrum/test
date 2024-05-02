using System.Net;
using DataMatrix.Core.Filters;
using DataMatrix.Core.FiltersModels;
using DataMatrix.Core.IRepository;
using DataMatrix.Data.DataContext;
using DataMatrix.Domain.ActionResponse;
using DataMatrix.Domain.DTOs;
using DataMatrix.Domain.Entities;
using DataMatrix.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataMatrix.Core.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;
   
    
    public OrderRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ActionMethodResult> Delete(Guid id, CancellationToken token)
    {
        try
        {
            var order = await _context.Orders.FirstOrDefaultAsync( x =>x.Id == id, token);
            
            if (order == null) 
                return new ActionMethodResult(false, (int)HttpStatusCode.NotFound);
            
            order.IsDeleted = true;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync(token);
            
            return new ActionMethodResult(true, (int)HttpStatusCode.Accepted);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public IQueryable<Order> GetAll()
    {
        return _context.Orders.Where(x => !x.IsDeleted).AsQueryable();
    }
    
    public async Task<Order> CreatOrder(CreateOrderDto request, CancellationToken token)
    {
        try
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Descriptions = request.Descriptions,
                Price = request.Price,
                Discount = request.Discount,
                StatusId = (int)OrderStatus.Expected,
                Created = DateTime.UtcNow,
                Deleted = DateTime.UtcNow
            };
            
            await _context.Orders.AddAsync(order, token);
            await _context.SaveChangesAsync(token);
            return order;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ActionMethodResult> Find(Guid id, CancellationToken token)
    {
        
        var order = await _context.Orders
            .FirstOrDefaultAsync(x => x.Id == id, token);
        
        return order == null ? 
            new ActionMethodResult(false, (int)HttpStatusCode.NotFound) : 
            new ActionMethodResult((int)HttpStatusCode.Accepted, order);
    }
        

    public async Task<IQueryable> GetByFilters(FilterOrderModel filters)
    {
        try
        {
            var result = GetAll()
                .OrderFilters(filters)
                .Select(x => new OrderDto()
                {
                    Descriptions = x.Descriptions,
                    StatusId = x.StatusId,
                    Id = x.Id.ToString(),
                    Price = x.Price
                });
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}