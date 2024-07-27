using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Sample1
    {

        public void Test()
        {
            BankFacade bank = new BankFacade();

            // The money transfer operation is carried out via Facade
            bank.TransferMoney("123456", "987654", 1000);
        }

        // Bank transaction system subsystem
        class BankOperationSystem
        {
            public void VerifyAccount(string accountNumber)
            {
                Console.WriteLine($"Verifying account {accountNumber}");
            }

            public void WithdrawMoney(string accountNumber, double amount)
            {
                Console.WriteLine($"Withdrawing {amount} from account {accountNumber}");
            }

            public void DepositMoney(string accountNumber, double amount)
            {
                Console.WriteLine($"Depositing {amount} to account {accountNumber}");
            }
        }

        // Facade class
        class BankFacade
        {
            private BankOperationSystem _bankSystem;

            public BankFacade()
            {
                _bankSystem = new BankOperationSystem();
            }

            public void TransferMoney(string fromAccount, string toAccount, double amount)
            {
                _bankSystem.VerifyAccount(fromAccount);
                _bankSystem.VerifyAccount(toAccount);
                _bankSystem.WithdrawMoney(fromAccount, amount);
                _bankSystem.DepositMoney(toAccount, amount);
                Console.WriteLine($"Transfer of {amount} from {fromAccount} to {toAccount} completed successfully.");
            }
        }

    }
}
