using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    internal class FactoryMethodWithSingletonScenario2
    {
        public void Operate()
        {
            BankCreator bankCreator = new();
            KapitalBank? Kapital = bankCreator.Create(BankType.Kapital) as KapitalBank;
            XalqBank? XalqBank = bankCreator.Create(BankType.XalqBank) as XalqBank;
            PashaBank? PashaBank = bankCreator.Create(BankType.PashaBank) as PashaBank;

            KapitalBank? Kapital2 = bankCreator.Create(BankType.Kapital) as KapitalBank;
            XalqBank? XalqBank2 = bankCreator.Create(BankType.XalqBank) as XalqBank;
            PashaBank? PashaBank2 = bankCreator.Create(BankType.PashaBank) as PashaBank;

            KapitalBank? Kapital3 = bankCreator.Create(BankType.Kapital) as KapitalBank;
            XalqBank? XalqBank3 = bankCreator.Create(BankType.XalqBank) as XalqBank;
            PashaBank? PashaBank3 = bankCreator.Create(BankType.PashaBank) as PashaBank;
        }


        #region Abstract Product
        interface IBank
        {

        }
        #endregion

        #region Concrete Products
        class KapitalBank : IBank
        {
            string _userCode, _password;
            KapitalBank(string userCode, string password)
            {
                Console.WriteLine($"{nameof(KapitalBank)} instance was created");
                _userCode = userCode;
                _password = password;
            }
            static KapitalBank()
                => _KapitalBank = new("asd", "123");
            static KapitalBank _KapitalBank;
            static public KapitalBank GetInstance => _KapitalBank;

            public void ConnectKapital()
                => Console.WriteLine($"{nameof(KapitalBank)} - Connected.");
            public void SendMoney(int amount)
                => Console.WriteLine($"{amount} money sent.");
        }

        class XalqBank : IBank
        {
            string _userCode, _password;
            XalqBank(string userCode)
            {
                Console.WriteLine($"{nameof(XalqBank)} instance was created");
                _userCode = userCode;
            }
            static XalqBank()
               => _XalqBank = new("asd");
            static XalqBank _XalqBank;
            static public XalqBank GetInstance => _XalqBank;

            public string Password { set => _password = value; }

            public void Send(int amount, string accountNumber)
                => Console.WriteLine($"{amount} money sent.");
        }

        class CredentialPashaBank
        {
            public string UserCode { get; set; }
            public string Mail { get; set; }
        }
        class PashaBank : IBank
        {
            string _userCode, _email, _password;
            public bool isAuthentcation { get; set; }
            PashaBank(CredentialPashaBank credential, string password)
            {
                Console.WriteLine($"{nameof(PashaBank)} instance was created");
                _userCode = credential.UserCode;
                _email = credential.Mail;
                _password = password;
            }

            static PashaBank()
              => _PashaBank = new(new() { Mail = "javid.sevdimaliyev@outlook.com", UserCode = "jvd" }, "123");
            static PashaBank _PashaBank;
            static public PashaBank GetInstance => _PashaBank;

            public void ValidateCredential()
            {
                if (true) //validating
                    isAuthentcation = true;
            }

            public void SendMoneyToAccountNumber(int amount, string recipientName, string accountNumber)
                => Console.WriteLine($"{amount} money sent.");
        }
        #endregion

        #region Abstract Factory
        interface IBankFactory
        {
            IBank CreateInstance();
        }
        #endregion

        #region Concrete Factories
        class KapitalFactory : IBankFactory
        {
            KapitalFactory() { }
            static KapitalFactory()
                => _kapitalFactory = new();
            static KapitalFactory _kapitalFactory;
            static public KapitalFactory GetInstance => _kapitalFactory;
            public IBank CreateInstance()
            {
                KapitalBank Kapital = KapitalBank.GetInstance;
                Kapital.ConnectKapital();
                return Kapital;
            }
        }
        class XalqBankFactory : IBankFactory
        {
            XalqBankFactory() { }
            static XalqBankFactory()
                => GetInstance = new();

            static public XalqBankFactory GetInstance { get; }

            public IBank CreateInstance()
            {
                XalqBank XalqBank = XalqBank.GetInstance;
                XalqBank.Password = "123";
                return XalqBank;
            }
        }
        class PashaBankFactory : IBankFactory
        {
            PashaBankFactory() { }
            static PashaBankFactory()
                => _PashaBankFactory = new();

            static PashaBankFactory _PashaBankFactory;
            static public PashaBankFactory GetInstance => _PashaBankFactory;
            public IBank CreateInstance()
            {
                PashaBank PashaBank = PashaBank.GetInstance;
                PashaBank.ValidateCredential();
                return PashaBank;
            }
        }
        #endregion

        #region Creator
        enum BankType
        {
            Kapital, XalqBank, PashaBank
        }
        class BankCreator
        {
            public IBank Create(BankType bankType)
            {
                IBankFactory _bankFactory = bankType switch
                {
                    BankType.PashaBank => PashaBankFactory.GetInstance,
                    BankType.XalqBank => XalqBankFactory.GetInstance,
                    BankType.Kapital => KapitalFactory.GetInstance
                };

                return _bankFactory.CreateInstance();
            }
        }
        #endregion
    }
}
