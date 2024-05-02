using DataMatrix.Core.Filters;
using DataMatrix.Core.FiltersModels;
using DataMatrix.Core.IRepository;
using DataMatrix.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DataMatrix.API.Controllers;
[Route("v1/Order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _order;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IOrderRepository order, ILogger<OrderController> logger)
    {
        _order = order;
        _logger = logger;
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery]Guid id, CancellationToken token)
    {
        try
        {
            var result = await _order.Find(id, token);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}");
            throw;
        }
    }
    
    [HttpDelete("Delete/{Id}")]
    public async Task<IActionResult> Delete([FromQuery]Guid id, CancellationToken token)
    {
        try
        {
            var result = await _order.Delete(id, token);
            
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}");
            throw;
        }
    }
    
    [HttpPost("CreatOrder")]
    public async Task<IActionResult> CreatOrder([FromForm]CreateOrderDto createOrderDto, CancellationToken token)
    {
        try
        {
            var result = await _order.CreatOrder(createOrderDto, token);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}");
            throw;
        }
    }
    
    [HttpGet("GetByFilters")]
    public async Task<IActionResult> GetByFilters([FromQuery]FilterOrderModel orderFilter, CancellationToken token)
    {
        try
        {
            var result = await _order.GetByFilters(orderFilter);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}");
            throw;
        }
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = _order.GetAll();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}");
            throw;
        }
    }
    
}