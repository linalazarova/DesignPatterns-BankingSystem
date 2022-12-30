using BankingSystem_DesignPatterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_DesignPatterns.Strategy
{
    public abstract class BankStrategy
    {
        public BankAccountFactory bankAccount;
        public abstract BankAccountFactory CreateBankAccounts(Bank creator, string name, double balance);
    }

    public class StudentStrategy : BankStrategy
    {
        public override BankAccountFactory CreateBankAccounts(Bank creator, string name, double balance)
        {
            bankAccount = creator.CreateBankAccounts(name, balance);
            return bankAccount;
        }
    }

    public class GeneralStrategy : BankStrategy
    {
        public override BankAccountFactory CreateBankAccounts(Bank creator, string name, double balance)
        {
            bankAccount = creator.CreateBankAccounts(name, balance);
            return bankAccount;
        }
    }
}
