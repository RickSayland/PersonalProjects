namespace PersonalProjectsCore.Finance;

public class Transaction : Entity
{
    public DateTime Timestamp { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<TransactionEntry> Entries { get; } = [];

    public bool IsBalanced => Entries.Sum(e => e.Amount) == 0;
}
public class TransactionEntry : Entity
{
    public required Account Account { get; set; }
    public decimal Amount { get; set; }
}