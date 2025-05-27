using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PhoneReseller
{
    public class Config   {


        private static Config Instance;

        public static Config GetInstance()
        {
            if (Instance == null)
                Instance = new Config();
            return Instance;
        }


        private static string path = "Config.xml";

        private Config()
        {
            var xDoc = new XmlDocument();
            try{
                xDoc.Load(path); 
            }catch(Exception e)
            {
                return;
            }
            if (xDoc.DocumentElement == null)
                return;

            DbPath = xDoc.DocumentElement.FirstChild.InnerText;

        }

        public string DbPath = null;

    }
}
