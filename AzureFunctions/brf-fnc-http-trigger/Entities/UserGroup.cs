namespace brf_fnc_http_trigger.Entities;

public class UserGroup
{
    public int Id { get; set; }
    public string GroupName { get; set; }

    public UserGroup(int id, string groupName)
    {
        Id = id;
        GroupName = groupName;
    }
}
