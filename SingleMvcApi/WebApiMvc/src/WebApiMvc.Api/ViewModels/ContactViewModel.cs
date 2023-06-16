namespace WebApiMvc.Api.ViewModels;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApiMvc.Model.Enums;

public class ContactViewModel
{
    [Required]
    public Guid Id { get; set; }
    
    public EStatus Status { get; set; }

    [Required]
    public string Name { get; set; }

    public Guid CategoryId { get; set; }

    [JsonIgnore]
    public CategoryViewModel Category { get; set; }

    public AddressDetailViewModel Address { get; set; }
    public List<ContactDetailViewModel> ContactsDetails { get; set; }


}
