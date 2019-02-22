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
            var filePath = Path.GetTempPath() + "warenkorb.json";
            if (File.Exists(filePath))
            {  
                File.Delete(filePath);
                return true;
            }

            return false;
        }

        public string getOrder()
        {
            string _orderMessage;
            _orderMessage = order() ? "Vielen Dank für ihre bestellung!" : "Sie haben keine Artikel im Warenkorb!";
            
            return _orderMessage;  
        }
        
        public string delete()
        {
            var filePath = Path.GetTempPath() + "warenkorb.json";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                string _orderMessage;
                _orderMessage = "Warenkorb erfolgreich gelöscht!";
            
                return _orderMessage;  
            }
            else
            {
                string _orderMessage;
                _orderMessage = "Keine Artikel im Warenkorb!";
            
                return _orderMessage;  
            }
            
        }
    }
    
    public class RootObject
    {
        public List<Warenkorb> Warenkorb { get; set; }
    }
}