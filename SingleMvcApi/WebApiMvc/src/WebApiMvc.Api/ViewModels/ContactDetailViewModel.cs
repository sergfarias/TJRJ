using System.Text.Json.Serialization;
using WebApiMvc.Model;

namespace WebApiMvc.Api.ViewModels;

public class ContactDetailViewModel
{
    public Guid Id { get; set; }
    public Guid ContactId { get;  set; }

    [JsonIgnore]
    public Contact Contact { get;  set; }
    public string Email { get;  set; }
    public string CelPhone { get;  set; }
    public string PhoneNumber { get;  set; }
    public string Linkedin { get;  set; }

}
