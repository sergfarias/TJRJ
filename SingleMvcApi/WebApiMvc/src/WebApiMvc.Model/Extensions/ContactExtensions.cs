namespace WebApiMvc.Model.Extensions;

public static class ContactExtensions
{
    public static void AddContactDetail(
        this Contact contact, 
        ContactDetail contactDetail)
        => contact.ContactsDetails.Add(contactDetail);

    public static void RemoveContactDetail(
        this Contact contact, 
        ContactDetail contactDetail)
        => contact.ContactsDetails.Remove(contactDetail);

}
