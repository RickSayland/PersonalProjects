namespace PersonalProjectsCore.Finance;

public class Individual : Entity
{
    public required string Name { get; set; }
    public List<Account> Accounts { get; private set; } = [];
    
    public void AddAccount(Account account)
    {
        if (account.Owner != this)
        {
            account.Owner = this;
        }
        if (!Accounts.Contains(account))
        {
            Accounts.Add(account);
        }
    }
}