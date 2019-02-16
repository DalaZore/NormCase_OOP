using System;
using NormCase_OOP.Classes;

namespace NormCase_OOP
{
  
  internal class Program
  {
    private static bool isLoggedIn = false;
    public static void Main(string[] args)
    {
      
      

      
      do{
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
      }while (!isLoggedIn);
      
      if(isLoggedIn)
      {
        Console.WriteLine("Welcome to the Shop!");
        Console.Read();
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

      try
      {
        if (dbconnect.LoginUser(username, passwd))
        {
          isLoggedIn = true;
        }
      }
      catch
      {
        Console.WriteLine();
      }
      
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