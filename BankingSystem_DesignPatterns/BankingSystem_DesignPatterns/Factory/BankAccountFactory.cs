using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_DesignPatterns.Factory
{

    //Factory
    public abstract class BankAccountFactory
    {
        public string name;
        public double balance;

        public BankAccountFactory(string name, double balance)
        {
            this.name = name;
            this.balance = balance;
        }

        public abstract void PrintInformation(string name, double balance);
    }

    public class StudentAccount : BankAccountFactory
    {
        public StudentAccount(string name, double balance) : base(name, balance)
        {
        }


        public override void PrintInformation(string name, double balance)
        {
            Console.WriteLine($"Name: {name}, Balance: {balance}, Account Type: Student");
        }
    }

    public class GeneralAccount : BankAccountFactory
    {
        public GeneralAccount(string name, double balance) : base(name, balance)
        {

        }

        public override void PrintInformation(string name, double balance)
        {
            Console.WriteLine($"Name: {name}, Balance: {balance}, Account Type: General");
        }
    }


    //Creator
    public abstract class Bank
    {
        private List<BankAccountFactory> _bankAccounts = new List<BankAccountFactory>();

        public List<BankAccountFactory> BankAccounts
        {
            get { return _bankAccounts; }
        }
        public abstract BankAccountFactory CreateBankAccounts(string accName, double balance);
    }

    public class StudentAccountCreator : Bank
    {

        public override BankAccountFactory CreateBankAccounts(string accName, double balance)
        {
            StudentAccount studentAccount = new StudentAccount(accName, balance);
            BankAccounts.Add(studentAccount);
            studentAccount.PrintInformation(accName, balance);
            return studentAccount;

        }
    }

    public class GeneralAccountCreator : Bank
    {
        public override BankAccountFactory CreateBankAccounts(string accName, double balance)
        {
            GeneralAccount generalAccount = new GeneralAccount(accName, balance);
            BankAccounts.Add(generalAccount);
            generalAccount.PrintInformation(accName, balance);
            return generalAccount;
        }
    }
}