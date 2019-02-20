using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace NormCase_OOP.Classes
{
    public class Warenkorb
    {
        public int id { get; set; }
        public string name { get; set; }

        
        
        private bool order()
        {
            var filePath = Path.GetTempPath() + "warenkorb.txt";
            if (File.Exists(filePath))
            {  
                File.Delete(filePath);
                return true;
            }

            return false;
        }
        public bool addWarenkorb(string _artikel)
        {

            Artikel katalog = new Artikel();

            katalog.listAll();


            List<string>[] artikel = katalog.searchArtikel(_artikel);
            if (!artikel.Any())
            {

                return false;
            }
            else
            {
                var filePath = Path.GetTempPath() + "warenkorb.txt";
                foreach (List<string> addArtikel in katalog.searchArtikel(_artikel))
                {
                    using (StreamWriter file =
                        new StreamWriter(filePath, true))
                    {
                        file.WriteLine(addArtikel[1]);
                    }
                }

                return true;
            }
        }

        public string getOrder()
        {
            string _orderMessage;
            _orderMessage = order() ? "Vielen Dank für ihre bestellung!" : "Sie haben keine Artikel im Warenkorb!";
            
            return _orderMessage;  
        }
    }
    
    public class RootObject
    {
        public List<Warenkorb> Warenkorb { get; set; }
    }
}