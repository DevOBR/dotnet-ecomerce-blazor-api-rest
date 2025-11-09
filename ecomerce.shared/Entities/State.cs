using System.ComponentModel.DataAnnotations;
using ecomerce.shared.Interfaces;

namespace ecomerce.shared.Entities;

public class State : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "State")]
    [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characteres.")]
    [Required(ErrorMessage = "Field {0} is required.")]
    public string Name { get; set; } = null!;

    public int CountryId { get; set; }

    public Country Country { get; set; } = null!;
    public ICollection<City>? Cities { get; set; }
    public int CitiesNumber => Cities is null ? 0 : Cities.Count;
}
