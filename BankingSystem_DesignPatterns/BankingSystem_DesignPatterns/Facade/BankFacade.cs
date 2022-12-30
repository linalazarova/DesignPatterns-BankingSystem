using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_DesignPatterns.Facade
{

    //SubSystems
    public class Deposit
    {
        public double increasedBalance;

        public void IncreaseMoneyInAccount(double moneyInAccount, double moneyDeposited)
        {
            moneyInAccount += moneyDeposited;
            increasedBalance = moneyInAccount;
        }

        public void MakeDeposit(double moneyInAccount, double moneyToDeposit)
        {
            IncreaseMoneyInAccount(moneyInAccount, moneyToDeposit);
            Console.WriteLine($"Deposit complete. Current balance: {increasedBalance}");
        }
    }

    public class Withdrawal
    {

        public double decreasedBalance;

        public void DecreaseMoneyInAccount(double moneyInAccount, double moneyWithdrawn)
        {
            moneyInAccount -= moneyWithdrawn;
            decreasedBalance = moneyInAccount;
        }

        public bool IsMoneyEnough(double moneyInAccount, double moneyToWithdrawal)
        {
            if (moneyToWithdrawal > moneyInAccount)
            {
                Console.WriteLine("You don't have enough money");
                Console.WriteLine($"Current balance: {moneyInAccount}");

                return false;
            }
            else
            {
                DecreaseMoneyInAccount(moneyInAccount, moneyToWithdrawal);
                Console.WriteLine($"Withdrawal complete. Current balance: {decreasedBalance}");

                return true;
            }
        }
    }


    //Facade
    public class BankFacade
    {
        Deposit deposit;
        Withdrawal withdrawal;

        public BankFacade()
        {
            deposit = new Deposit();
            withdrawal = new Withdrawal();
        }

        public void DepositMoney(double moneyInAccount, double moneyToDeposit)
        {
            deposit.MakeDeposit(moneyInAccount, moneyToDeposit);
            Console.WriteLine("Transaction complete");

        }

        public void WithdrawMoney(double moneyInAccount, double moneyToWithdraw)
        {
            if (withdrawal.IsMoneyEnough(moneyInAccount, moneyToWithdraw))
            {
                Console.WriteLine("Transaction complete");
            }
            else
            {
                Console.WriteLine("Transaction failed");
            }
        }
    }
}
