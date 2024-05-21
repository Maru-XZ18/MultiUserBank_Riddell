using System;

namespace MultiUserBank_Riddell
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();

            // Display login prompt
            Console.WriteLine("Welcome to the Multi-User Bank!");
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            if (bank.Login(username, password))
            {
                Console.WriteLine($"Logged in as {username}");

                // Display menu options
                while (true)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Check balance");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Log out");
                    Console.Write("Enter your choice (1-4): ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            bank.CheckBalance();
                            break;
                        case "2":
                            Console.Write("Enter deposit amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                            {
                                bank.Deposit(depositAmount);
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount. Please enter a valid number.");
                            }
                            break;
                        case "3":
                            Console.Write("Enter withdrawal amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
                            {
                                bank.Withdraw(withdrawalAmount);
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount. Please enter a valid number.");
                            }
                            break;
                        case "4":
                            bank.Logout();
                            return; // Exit the program
                        default:
                            Console.WriteLine("Invalid choice. Please select 1-4.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid credentials. Please try again.");
            }
        }
    }
}