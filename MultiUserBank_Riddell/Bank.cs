using System;

public class Bank
{
    private const decimal InitialBalance = 10000;
    private UserAccount[] userAccounts;
    private UserAccount loggedInUser;

    public Bank()
    {
        // Initialize user accounts (replace with actual data)
        userAccounts = new UserAccount[]
        {
            new UserAccount("jlennon", "johnny", 1250),
            new UserAccount("pmccartney", "pauly", 2500),
            new UserAccount("gharrison", "georgy", 3000),
            new UserAccount("rstarr", "ringoy", 1001)
        };
    }

    public bool Login(string username, string password)
    {
        // Validate credentials and set loggedInUser
        var user = Array.Find(userAccounts, u => u.Username == username && u.Password == password);
        if (user != null)
        {
            loggedInUser = user;
            return true;
        }
        return false;
    }

    public void Deposit(decimal amount)
    {
        if (loggedInUser != null)
        {
            loggedInUser.Balance += amount;
            Console.WriteLine($"Deposited: ${amount}");
        }
        else
        {
            Console.WriteLine("Please log in first.");
        }
    }

    public decimal Withdraw(decimal amount)
    {
        if (loggedInUser != null)
        {
            var availableBalance = Math.Min(loggedInUser.Balance, 500); // Cap withdrawal at $500
            if (amount <= availableBalance)
            {
                loggedInUser.Balance -= amount;
                Console.WriteLine($"Withdrawn: ${amount}");
                return amount;
            }
            else
            {
                Console.WriteLine($"Insufficient balance. Available: ${availableBalance}");
                return 0;
            }
        }
        else
        {
            Console.WriteLine("Please log in first.");
            return 0;
        }
    }

    public void CheckBalance()
    {
        if (loggedInUser != null)
        {
            Console.WriteLine($"Current balance: ${loggedInUser.Balance}");
        }
        else
        {
            Console.WriteLine("Please log in first.");
        }
    }

    public void Logout()
    {
        loggedInUser = null;
        Console.WriteLine("Logged out.");
    }
}

public class UserAccount
{
    public string Username { get; }
    public string Password { get; }
    public decimal Balance { get; set; }

    public UserAccount(string username, string password, decimal initialBalance)
    {
        Username = username;
        Password = password;
        Balance = initialBalance;
    }
}

