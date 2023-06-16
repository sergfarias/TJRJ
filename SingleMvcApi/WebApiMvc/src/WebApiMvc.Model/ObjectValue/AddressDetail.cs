namespace WebApiMvc.Model.ObjectValue;
public class AddressDetail
{
    #region Properties
    public string Address { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }

    #endregion

    #region Constructor
    public AddressDetail(
        string address,
        string number,
        string neighborhood,
        string city,
        string state,
        string zipCode)
    {
        Address = address;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    #endregion
}

