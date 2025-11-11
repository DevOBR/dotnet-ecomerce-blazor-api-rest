namespace ecomerce.shared;

public class PaginationDTO
{
    public int Id { get; set; }
    public int Page { get; set; } = 1;
    public int RecordsNumbers { get; set; } = 10;
}
