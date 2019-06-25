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
            string[] fichier = File.ReadAllText(PathFileIn).Split(';');
            for (int i = 0; i < fichier.Length - 1; i += 2)
            {

                ArrayList j = new ArrayList();
                j.Add(fichier[i]);
                j.Add(fichier[i + 1]);
                //Console.WriteLine(fichier.Length);
                //Console.WriteLine("le premier élement de la liste :" + j[0]);
                //Console.WriteLine("le deuxième élement de la liste :" + j[1]);
                //// Console.ReadKey();

                string remoteUri = "https://www.compressport.com/inter/module/sage123/invoice?cronkey="+Cronkey+ "&reference=" + j[1];
                string fileName_a = j[0] + "a.pdf";
                string fileName_b = j[0] + "b.pdf";
                string fileName_c = j[0] + "c.pdf";
                string fileName_d = j[0] + "d.pdf", myStringWebResource = null;
                // Create a new WebClient instance.
                WebClient myWebClient = new WebClient();
                // Concatenate the domain with the Web resource filename.
                myStringWebResource = remoteUri;
                //Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(myStringWebResource, pathInvoice+fileName_a);
                myWebClient.DownloadFile(myStringWebResource, pathInvoice + fileName_b);
                myWebClient.DownloadFile(myStringWebResource, pathInvoice + fileName_c);
                myWebClient.DownloadFile(myStringWebResource, pathInvoice + fileName_d);
                //Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
                //Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
                // Console.ReadKey();
            }
        }
    }
}
