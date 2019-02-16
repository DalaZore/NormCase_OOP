using System;
using NormCase_OOP.Classes;

namespace NormCase_OOP
{
  internal class Program
  {
    
    public static void Main(string[] args)
    { 
      Console.WriteLine("Login (1) or Register (2)");
      switch(Int32.Parse(Console.ReadLine()))
      {
        case 1:
          DoLogin();
          break;
        case 2:
          DoRegister();
          break;
        default:
          Environment.Exit(0);
          break;
      }
      
      
    }

    #region Methods

    private static void DoLogin()
    {
      DbConnect dbconnect = new DbConnect();
      
      Console.Write("Username: ");
      string username = Console.ReadLine();
      Console.Write("Password: ");
      string passwd = Console.ReadLine();
    }

    private static void DoRegister()
    {
      DbConnect dbconnect = new DbConnect();
      
      Console.Write("Username: ");
      string username = Console.ReadLine();
      Console.Write("Password: ");
      string passwd = Console.ReadLine();
      Console.Write("Creditcard: ");
      string creditcard = Console.ReadLine();

      dbconnect.InsertKunde(username, passwd, creditcard);
    }
    #endregion
    
  }
}