using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VPNGateAPI;

namespace OpenVPN_Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OpenVPN Scraper by ion - GitHub: ioncodes");
            Console.WriteLine("Getting configs...");
            var configs = API.GetConfigs();
            foreach (var config in configs)
            {
                File.WriteAllText("configs/" + config.Location + "_" + config.Port + "_" + config.Protocol + ".ovpn", config.Config);
                Console.WriteLine("Added config. Location "+config.Location);
            }

            Console.WriteLine("Finished scrapeing...");
            Console.Write("Woudl you like to copy all configs to the OpenVPN config folder? (needs admin rights) y/n ");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                Console.WriteLine("Copying configs...");
                string rootFolderPath = Environment.CurrentDirectory + @"\configs\";
                string destinationPath = File.ReadAllText("settings.txt");
                string[] fileList = Directory.GetFiles(rootFolderPath);
                foreach (string file in fileList)
                {
                    string moveTo = destinationPath;
                    File.Copy(file, moveTo + Path.GetFileName(file), true);
                }
            }

            Console.WriteLine("Press any key to close this application...");
            Console.Read();
        }
    }
}
