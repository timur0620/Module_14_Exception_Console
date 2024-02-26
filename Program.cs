using MyLibrary;
using System;

namespace Module_14_Exception_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryView();
            ExtantionView();
        }
        private void TryParseFunc()
        {   
            string num = "25";
            int someNum = default(int);
            bool flag = int.TryParse(num, out someNum);
        }
        private bool TryCatchFunc()
        {
            try
            {
                TryParseFunc();
                return true;
            }
            catch
            {
                Console.WriteLine("Some any action if error");
                return false;
            }
        } 
        private void ExceptionsView()
        {
            try
            {
                TryParseFunc();
            }
            catch (FormatException)
            {
                Console.WriteLine("Some any action if error");
            }
            catch (IndexOutOfRangeException) 
            {
                Console.WriteLine("Some any action if error");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message, ex.GetType());
            }
        }
        private void  CoustumExceptons()
        {
            string st = "SomeString";
            if (st == "")
            {
                throw new Exception();
            }
            else if (st ==  null)
            {
                throw new MyCoustumExceptions("Some MyMessage", 1);
            }
        }
        private void UsingMyExceptions()
        {
            try
            {
                TryParseFunc();
            }
            catch(MyCoustumExceptions ex) when (ex.NumError == 0)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MyCoustumExceptions ex) when (ex.NumError == 1)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void ConsoleViewOperationClass()
        {
            OperationMyClass num = new OperationMyClass() { SomeNumber = 10};
            OperationMyClass num2 = new OperationMyClass() {SomeNumber = 20};

            OperationMyClass res = num + num2;
            string res2 = num - num2;
        }
        public static void LibraryView()
        {
            Console.WriteLine(SomeLib.SumFunc(100, 500));
        }
        public static void ExtantionView()
        {
            
            int num = 2212121;
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6};

            Math.Pow(2, 4).MyPrint();
            num.MyPrint();
            list.MyPrint();
            2.MyPow(4).MyPrint();
            10.MyAddTo(list);
            list.MyPrint();
        }
    }
    class MyCoustumExceptions: Exception
    {
        public int NumError {  get; set; }
        public MyCoustumExceptions(string message, int numError) :base(message) 
        {
            this.NumError = numError;
        }
    }
    class OperationMyClass
    {
        public  int SomeNumber {  get; set; }

        public static OperationMyClass operator + (OperationMyClass x, OperationMyClass y)
        {
            return new OperationMyClass() { SomeNumber = x.SomeNumber + y.SomeNumber };
        }
        public static string operator -(OperationMyClass x, OperationMyClass y)
        {
            return "Minus";
        }

    }
    public static class MethodExtantion
    {
        public static void MyPrint<T>(this T num)
        {
            Console.WriteLine(num);
        }
        public static void MyPrint<T>(this List<T> litsData)
        {
            foreach (var item in litsData)
            {
                Console.WriteLine(item);
            }
        }
        static public double MyPow(this int num, int num2)
        {
            return Math.Pow(num, num2);
        }
        static public void MyAddTo <T>(this T num, List<T> collection)
        {
            collection.Add(num);
        }
    }
}
