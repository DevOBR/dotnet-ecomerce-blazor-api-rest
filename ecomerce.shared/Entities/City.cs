using System.ComponentModel.DataAnnotations;
using ecomerce.shared.Interfaces;

namespace ecomerce.shared.Entities;

public class City : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "City")]
    [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characteres.")]
    [Required(ErrorMessage = "Field {0} is required.")]
    public string Name { get; set; } = null!;

    public int StateId { get; set; }

    public State State { get; set; } = null!;
}
