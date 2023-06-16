namespace WebApiMvc.Api.ViewModels;

using System.ComponentModel.DataAnnotations;

public class CategoryViewModel
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Description { get; set; }
}
