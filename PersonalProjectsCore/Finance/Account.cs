namespace PersonalProjectsCore.Finance;

public class Account(string name, Individual owner) : Entity
{
    public string Name { get; set; } = name;
    private Individual _owner = owner;
    public Individual Owner
    {
        get => _owner;
        set
        {
            _owner = value;
            if (!value.Accounts.Contains(this))
            {
                value.AddAccount(this); // Keep the relationship in sync
            }
        }
    }
    public decimal Balance { get; set; }
}