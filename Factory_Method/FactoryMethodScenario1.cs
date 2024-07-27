using System.Reflection;

namespace Factory_Method
{
    internal class FactoryMethodScenario1
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
        interface IBank { }

        #endregion

        #region Concrete Products
        class KapitalBank : IBank
        {
            string _userCode, _password;
            public KapitalBank(string userCode, string password)
            {
                Console.WriteLine($"{nameof(KapitalBank)} instance was created");
                _userCode = userCode;
                _password = password;
            }

            public void ConnectKapital()
                => Console.WriteLine($"{nameof(KapitalBank)} - Connected.");
            public void SendMoney(int amount)
                => Console.WriteLine($"{amount} money sent.");
        }

        class XalqBank : IBank
        {
            string _userCode, _password;
            public XalqBank(string userCode)
            {
                Console.WriteLine($"{nameof(XalqBank)} instance was created");
                _userCode = userCode;
            }

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
            public PashaBank(CredentialPashaBank credential, string password)
            {
                Console.WriteLine($"{nameof(PashaBank)} instance was created");
                _userCode = credential.UserCode;
                _email = credential.Mail;
                _password = password;
            }
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
        abstract class AbstractBankFactory
        {
            public abstract IBank CreateInstance();
        }
        #endregion

        #region Concrete Factories
        class KapitalFactory : AbstractBankFactory
        {
            public override IBank CreateInstance()
            {
                KapitalBank Kapital = new("asd", "123");
                Kapital.ConnectKapital();
                return Kapital;
            }
        }
        class XalqBankFactory : AbstractBankFactory
        {
            public override IBank CreateInstance()
            {
                XalqBank XalqBank = new("asd");
                XalqBank.Password = "123";
                return XalqBank;
            }
        }
        class PashaBankFactory : AbstractBankFactory
        {
            public override IBank CreateInstance()
            {
                PashaBank PashaBank = new(new() { Mail = "javid.sevdimaliyev@outlook.com", UserCode = "jvd" }, "123");
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
                AbstractBankFactory _bankFactory = bankType switch
                {
                    BankType.PashaBank => new PashaBankFactory(),
                    BankType.XalqBank => new XalqBankFactory(),
                    BankType.Kapital => new KapitalFactory()
                };

                return _bankFactory.CreateInstance();
            }

            public IBank CreateBank(BankType bankType) //Create with Reflection
            {
                string factory = $"{bankType.ToString()}Factory";
                Type? type = Assembly.GetExecutingAssembly().GetType(factory);
                AbstractBankFactory? bankFactory = Activator.CreateInstance(type) as AbstractBankFactory;
                return bankFactory.CreateInstance();
            }
        }
        #endregion
    }
}
