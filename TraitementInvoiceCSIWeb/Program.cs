using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Configuration;


namespace TraitementInvoiceCSIWeb
{
    class Program
    {
        static void Main(string[] args)
        {
          
           
            var appSettings = ConfigurationManager.AppSettings;
            string Cronkey = appSettings["key"];
            string PathFileIn = appSettings["file"];
            string pathInvoice = appSettings["pathInvoice"];
            string pathLogTxt = appSettings["pathLog"];
            

            try
            {
                string[] fichier = File.ReadAllText(PathFileIn).Split(';');

                for (int i = 0; i < fichier.Length - 1; i += 2)

                {

                    ArrayList j = new ArrayList();
                    j.Add(fichier[i]);
                    j.Add(fichier[i + 1]);

                    string remoteUri = "https://www.compressport.com/inter/module/sage123/invoice?cronkey=" + Cronkey + "&reference=" + j[1];
                    string fileName_a = j[0] + "a.pdf";
                    string fileName_b = j[0] + "b.pdf";
                    string fileName_c = j[0] + "c.pdf";
                    string fileName_d = j[0] + "d.pdf", myStringWebResource = null;

                    // Create a new WebClient instance.
                    WebClient myWebClient = new WebClient();
                    // Concatenate the domain with the Web resource filename.
                    myStringWebResource = remoteUri;

                    // Download the Web resource and save it into the current filesystem folder.
                    myWebClient.DownloadFile(myStringWebResource, pathInvoice + fileName_a);
                    myWebClient.DownloadFile(myStringWebResource, pathInvoice + fileName_b);
                    myWebClient.DownloadFile(myStringWebResource, pathInvoice + fileName_c);
                    myWebClient.DownloadFile(myStringWebResource, pathInvoice + fileName_d);

                }
            }
            catch (Exception ex)
            {

                String pathLog = pathLogTxt;
                string[] contents = { "Problème le : " + DateTime.UtcNow + " : " + ex.Message };
                File.AppendAllLines(pathLog, contents);

            }
        }
    }
}
