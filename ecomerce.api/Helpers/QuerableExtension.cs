using ecomerce.shared;

namespace ecomerce.api.Helpers;

public static class QuerableExtension
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        => queryable
            .Skip((pagination.Page - 1) * pagination.RecordsNumbers)
            .Take(pagination.RecordsNumbers);
}
