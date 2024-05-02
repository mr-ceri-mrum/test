using DataMatrix.Core.FiltersModels;
using DataMatrix.Domain.Entities;

namespace DataMatrix.Core.Filters;

public static class OrderFilter
{
    public static IQueryable<Order> OrderFilters(this IQueryable<Order> orders, FilterOrderModel filters)
    {
        if (filters.Price.HasValue)
            orders = orders.Where(x => x.Price == filters.Price);
        if (filters.StatusId.HasValue)
            orders = orders.Where(x => x.StatusId == filters.StatusId);
        return orders;
    }
}