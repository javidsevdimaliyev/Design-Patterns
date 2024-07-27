namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            Example ex1 = Example.GetInstance;
            Example ex2 = Example.GetInstance;
            Example ex3 = Example.GetInstance;
            Example ex4 = Example.GetInstance;
            Example ex5 = Example.GetInstance;
            Example ex6 = Example.GetInstance;
            Example ex7 = Example.GetInstance;
            Example ex8 = Example.GetInstance;
        }
        class Example
        {
            private Example()
            {
                Console.WriteLine($"{nameof(Example)} instance was created");
            }
            static Example _example;

            static Example()
                   => _example = new Example();
            static public Example GetInstance
            {
                get
                {
                    #region 1. Method
                    //if (_example == null)
                    //    _example = new Example();
                    //return _example;
                    #endregion
                    #region 2. Method
                    return _example;
                    #endregion

                }
            }
        }
    }
}
