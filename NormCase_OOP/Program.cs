using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
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
      
      Console.WriteLine("Welcome to the Shop!");
      
      User kunde = new User();
      while(isLoggedIn)
      {
        Console.WriteLine("(1) Artikel erstellen");
        Console.WriteLine("(2) Artikel anzeigen");
        Console.WriteLine("(3) Artikel suchen");
        Console.WriteLine("(4) Artikel in Warenkorb aufnehmen");
        Console.WriteLine("(5) Artikel in Warenkorb anzeigen");
        Console.WriteLine("(6) Warenkorb in bestellung geben");
        Console.WriteLine("(0) Programm beenden");
        
        switch(Int32.Parse(Console.ReadLine()))
        {
          case 1:
            doAddArtikel();
            break;
          case 2:
            doListArtikel();
            break;
          case 3:
            doListSearch();
            break;
          case 4:
            doAddWarenkorb();
            break;
          case 5:
            doListWarenkorb();
            break;
          case 6:
            doOrder();
            break;
          default:
            Environment.Exit(0);
            break;
        }
        
      }
    }

    #region Methods

    private static void DoLogin()
    {
      Database dbconnect = new Database();
      
      
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

    private static void doOrder()
    {
      Warenkorb warenkorb = new Warenkorb();
      Console.WriteLine(warenkorb.getOrder());
      Console.ReadKey();
    }

    private static void doAddWarenkorb()
    {
      Warenkorb warenkorb = new Warenkorb();
      Console.WriteLine("Welcher Artikel (Artikel Name) willst du in den Warenkorb legen?");
      doListArtikel();
      string _artikel = Console.ReadLine();

      if (warenkorb.addWarenkorb(_artikel))
      {
        Console.WriteLine("Artikel Erfolgreich hinzugefügt!");
      }
      else
      {
        Console.WriteLine("Artikel nicht gefunden!");
      }

      Console.ReadKey();


    }
    private static void doListWarenkorb()
    {
//      string _json = "";
//      RootObject item = new RootObject();
//      using (StreamReader r = new StreamReader(Path.GetTempPath() + "warenkorb.json"))
//      {
//        _json = r.ReadToEnd();
//        item = JsonConvert.DeserializeObject<RootObject>(_json);
//      }
//      Console.WriteLine("Artikel ID    Artikel Name");
//      foreach (var artikel in item.Warenkorb)
//      {
//        Console.WriteLine("{0}             {1}",artikel.id ,artikel.name);
//      }
      var filePath = Path.GetTempPath() + "warenkorb.txt";
      if (File.Exists(filePath))
      {
        string[] _artikel = File.ReadAllLines(filePath);
        foreach (string artikel in _artikel)
        {
          Console.WriteLine(artikel);
        }
      }
      else
      {
        Console.WriteLine("Sie haben keine Artikel im Warenkorb!");
      }

      Console.ReadKey();
    }

    private static void doListSearch()
    {
      Artikel katalog = new Artikel();
      Console.WriteLine("Geben Sie ihr Suchwort ein");
      string _searchTerm = Console.ReadLine();
      Console.WriteLine("Artikel ID    Artikel Name");
      foreach (List<string> artikel in katalog.searchArtikel(_searchTerm))
      {
        Console.WriteLine("{0}             {1}",artikel[0], artikel[1]);
      }
      Console.ReadKey();
    }
    
    private static void doListArtikel()
    {
      Artikel katalog = new Artikel();
      Console.WriteLine("Artikel ID    Artikel Name");
      foreach (List<string> artikel in katalog.listAll())
      {
        Console.WriteLine("{0}             {1}",artikel[0], artikel[1]);
      }

      Console.ReadKey();
    }
    
    private static void doAddArtikel()
    {
      Artikel katalog = new Artikel();
      Console.WriteLine("Wie heisst der Artikel?");
      if(katalog.InsertArtikel(Console.ReadLine()))
      {
        Console.WriteLine("Artikel erfolgreich erstellt!");
      }
    }
    private static void DoRegister()
    {
      Database dbconnect = new Database();
      
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