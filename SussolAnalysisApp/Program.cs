using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SussolAnalysisApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DLLcaller dlc = new DLLcaller();
            FileWriter wr = new FileWriter();
            var resourcepath = @"C:\Users\Christophe\Documents\Visual Studio 2017\Projects\SussolAnalysisApp\SussolAnalysisApp\Resources\";
            string format;
            string pad;
            string delimeter;
            string filenaam;
            bool bestaat = false;
            string algorithmtype;
            string nestedOrVaried;
            while (!bestaat) {
                Console.WriteLine("Please enter the path of the dataset you wish to use. If you have previously worked with this dataset, simply the name of the database will suffice.");
                pad = Console.ReadLine().ToString();
                if (pad.Contains("\\"))
                {
                    filenaam = pad.Split('\\').Last();
                    wr.copyFile(pad);
                    Console.WriteLine("What type of algorithm would you like to apply? Please choose from [canopy], [som] or [xmeans]");
                    algorithmtype = Console.ReadLine().ToString().ToLower();
                    Console.WriteLine("Would you like to have results based on nested or varied parameters? [varied] or [nested]");
                    nestedOrVaried = Console.ReadLine().ToString().ToLower();
                    Console.WriteLine("In what format do you wish to generate the results? Please choose from [csv], [text] or [both]");
                    format = Console.ReadLine().ToString().ToLower();
                    dlc.GetResultFiles(filenaam, format, algorithmtype, nestedOrVaried);
                    bestaat = true;
                }
                else {
                    if (!File.Exists(resourcepath + "\\" + pad))
                    {
                        Console.WriteLine("This file doesn't seem to be in the Resource folder. Please give the full path of the dataset");
                    }
                    else
                    {
                        Console.WriteLine("What type of algorithm would you like to apply? Please choose from [canopy], [som] or [xmeans]");
                        algorithmtype = Console.ReadLine().ToString().ToLower();
                        Console.WriteLine("Would you like to have results based on nested or varied parameters? [varied] or [nested]");
                        nestedOrVaried = Console.ReadLine().ToString().ToLower();
                        Console.WriteLine("In what format do you wish to generate the results? Please choose from [csv], [text] or [both]");
                        format = Console.ReadLine().ToString().ToLower();
                        dlc.GetResultFiles(pad, format, algorithmtype, nestedOrVaried);
                        bestaat = true;
                    }
                }
               
                
            }
           
            
            
           


        }
    }
}
