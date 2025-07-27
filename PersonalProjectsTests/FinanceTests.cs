using PersonalProjectsCore.Finance;

namespace PersonalProjectsTests;

public class FinanceTests
{
    private Individual _individualA;
    private Individual _individualB;
    
    private Account _accountA;
    private Account _accountB;
    private Account _accountB2;
    
    [SetUp]
    public void Setup()
    {
        // Timmy only has a Cash Account
        _individualA = new Individual { Name = "Timmy" };
        _accountA = new Account("Cash", _individualA);
        
        // Rudy only has a checking and savings
        _individualB = new Individual { Name = "Rudy" };
        _accountB = new Account("Checking", _individualB);
        _accountB2 = new Account("Savings", _individualB);
    }
    
    #region Account Tests
    [Test]
    public void AddAccount_ToIndividual_ShouldSetAccountOwner()
    {
        var individual = new Individual { Name = "Alice" };
        var account = new Account("Brokerage", individual);

        individual.AddAccount(account);

        Assert.Multiple(() =>
        {
            Assert.That(individual.Accounts, Does.Contain(account));
            Assert.That(account.Owner, Is.EqualTo(individual));
        });
    }

    [Test]
    public void SetOwner_OnAccount_ShouldAddAccountToIndividualsList()
    {
        var individual = new Individual { Name = "Bob" };
        var account = new Account("IRA", individual)
        {
            Owner = individual
        };

        Assert.Multiple(() =>
        {
            Assert.That(account.Owner, Is.EqualTo(individual));
            Assert.That(individual.Accounts, Does.Contain(account));
        });
    }

    [Test]
    public void AddSameAccountTwice_ShouldNotDuplicate()
    {
        var individual = new Individual { Name = "Carol" };
        var account = new Account("Emergency Fund", individual);

        individual.AddAccount(account);
        individual.AddAccount(account);

        Assert.That(individual.Accounts.Count(a => a == account), Is.EqualTo(1));
    }

    [Test]
    public void ChangingAccountOwner_ShouldUpdateBothSides()
    {
        var alice = new Individual { Name = "Alice" };
        var bob = new Individual { Name = "Bob" };
        var account = new Account("Cash", alice);

        // Reassign ownership
        account.Owner = bob;

        Assert.Multiple(() =>
        {
            Assert.That(account.Owner, Is.EqualTo(bob));
            Assert.That(bob.Accounts, Does.Contain(account));
            Assert.That(alice.Accounts, Does.Not.Contain(account));
        });
    }
    #endregion

    #region Transaction Tests
    [Test]
    public void SingleTransaction_BalancedTransaction_ShouldBeValid()
    {
        var transaction = new Transaction
        {
            Timestamp = DateTime.UtcNow,
            Description = "Timmy pays Rudy $50"
        };

        transaction.Entries.Add(new TransactionEntry
        {
            Account = _accountA,
            Amount = -50m
        });

        transaction.Entries.Add(new TransactionEntry
        {
            Account = _accountB,
            Amount = 50m
        });

        Assert.Multiple(() =>
        {
            Assert.That(transaction.IsBalanced, Is.True);
            Assert.That(transaction.Entries.Sum(e => e.Amount), Is.EqualTo(0m));
        });
    }

    [Test]
    public void SingleTransaction_UnbalancedTransaction_ShouldBeInvalid()
    {
        var transaction = new Transaction
        {
            Timestamp = DateTime.UtcNow,
            Description = "Oops - bad entry"
        };

        transaction.Entries.Add(new TransactionEntry
        {
            Account = _accountA,
            Amount = -30m
        });

        transaction.Entries.Add(new TransactionEntry
        {
            Account = _accountB,
            Amount = 20m
        });

        Assert.That(transaction.IsBalanced, Is.False);
    }

    [Test]
    public void MultiLeggedTransaction_ShouldStillBeBalanced()
    {
        var transaction = new Transaction
        {
            Timestamp = DateTime.UtcNow,
            Description = "Timmy pays Rudy who splits $100 to checking and savings"
        };

        transaction.Entries.Add(new TransactionEntry
        {
            Account = _accountA,
            Amount = -100m
        });

        transaction.Entries.Add(new TransactionEntry
        {
            Account = _accountB,
            Amount = 60m
        });

        transaction.Entries.Add(new TransactionEntry
        {
            Account = _accountB2,
            Amount = 40m
        });

        Assert.That(transaction.IsBalanced);
    }
    #endregion
}