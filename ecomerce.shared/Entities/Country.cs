using System.ComponentModel.DataAnnotations;
using ecomerce.shared.Interfaces;

namespace ecomerce.shared.Entities;

public class Country : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Country")]
    [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characteres.")]
    [Required(ErrorMessage = "Field {0} is required.")]
    public string Name { get; set; } = null!;

    public ICollection<State>? States { get; set; }

    public int StatesNumber => States is null ? 0 : States.Count;
}
