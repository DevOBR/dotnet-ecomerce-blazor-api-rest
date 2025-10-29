using System.ComponentModel.DataAnnotations;

namespace ecomerce.shared.Entities;

public class Country
{
    public int Id { get; set; }

    [Display(Name = "Country")]
    [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characteres.")]
    [Required(ErrorMessage = "Field {0} is required.")]
    public string Name { get; set; } = null!;
}
