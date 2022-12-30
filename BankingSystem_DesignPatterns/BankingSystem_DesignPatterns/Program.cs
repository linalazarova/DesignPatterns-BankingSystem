using BankingSystem_DesignPatterns.Facade;
using BankingSystem_DesignPatterns.Factory;
using BankingSystem_DesignPatterns.Strategy;
using System;

namespace BankingSystem_DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our bank!");
            Console.WriteLine("Creating your bank account... ");
            Console.WriteLine("Age: ");
            int age = int.Parse(Console.ReadLine());

            string name;
            double balance;

            if (age < 18)
            {
                StudentAccountCreator studentAccountCreator = new StudentAccountCreator();
                StudentStrategy studentStrategy = new StudentStrategy();

                Console.WriteLine("Student Account Creation");
                Console.WriteLine("------------------------");
                Console.WriteLine("Name: ");
                name = Console.ReadLine();
                Console.WriteLine("Initial Balance: ");
                balance = double.Parse(Console.ReadLine());

                studentStrategy.CreateBankAccounts(studentAccountCreator, name, balance);

                Transaction(balance);
            }
            else
            {
                GeneralAccountCreator generalAccountCreator = new GeneralAccountCreator();
                GeneralStrategy bankStrategy = new GeneralStrategy();

                Console.WriteLine("General Account Creation");
                Console.WriteLine("------------------------");
                Console.WriteLine("Name: ");
                name = Console.ReadLine();
                Console.WriteLine("Initial Balance: ");
                balance = double.Parse(Console.ReadLine());

                bankStrategy.CreateBankAccounts(generalAccountCreator, name, balance);

                Transaction(balance);
            }


        }

        public static void Transaction(double balance)
        {
            BankFacade bank = new BankFacade();

            Console.WriteLine("Do you wish to make a transaction?");
            string input = Console.ReadLine();

            if (input == "yes")
            {
                Console.WriteLine("1.Deposit\n2.Withdrawal");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Money to deposit: ");
                        double deposit = double.Parse(Console.ReadLine());
                        bank.DepositMoney(balance, deposit);
                        break;
                    case 2:
                        Console.WriteLine("Money to withdraw: ");
                        double withdrawal = double.Parse(Console.ReadLine());
                        bank.WithdrawMoney(balance, withdrawal);
                        break;

                    default: break;
                }
            }

            Console.WriteLine("Goodbye");
        }
    }
}
