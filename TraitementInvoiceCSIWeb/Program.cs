using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TraitementInvoiceCSIWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathFileIn = "invoicetodownload.txt";


            string[] fichier = File.ReadAllText(PathFileIn).Split(';');

            for (int i = 0; i < fichier.Length - 1; i += 2)
            {

                ArrayList j = new ArrayList();
                j.Add(fichier[i]);
                j.Add(fichier[i + 1]);
                Console.WriteLine(fichier.Length);
                Console.WriteLine("le premier élement de la liste :" + j[0]);
                Console.WriteLine("le deuxième élement de la liste :" + j[1]);
                // Console.ReadKey();

                string remoteUri = "https://www.compressport.com/inter/module/sage123/invoice?cronkey="+args[0]+ "&reference = YYYY" + j[1];
                //string fileName = j[0]+".pdf", myStringWebResource = null; 
                string fileName = j[0] + ".pdf", myStringWebResource = null;
                // Create a new WebClient instance.
                WebClient myWebClient = new WebClient();
                // Concatenate the domain with the Web resource filename.
                myStringWebResource = remoteUri;
                Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(myStringWebResource, fileName);
                Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
                //Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
                // Console.ReadKey();
            }
        }
    }
}
