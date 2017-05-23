using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SussolAnalysisApp
{
    public class FileWriter
    {
        public void Writetextfile(String directory, String filename, JObject jObject, String teller, String featureInfo)
        {
            string path = Path.Combine(directory, filename);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter str = new StreamWriter(fs))
                {
                    str.Write("===============================================\n" + featureInfo + "\n ===============================================\n");
                    str.Write(" --------------------------------------\nParameter value " + teller + "\n --------------------------------------\n");
                    str.Write(jObject);

                }

            }
        }
        String filename;
        public void createCsv(String directory, String algo, String setname)
        {
            filename = algo + " RESULTS " + "dataset= " + setname + ".csv";
            string path = Path.Combine(directory, filename);
            using (var wr = new StreamWriter(path, true, Encoding.UTF8))
            {
                wr.WriteLine(algo + " RESULTS;dataset naam: " + setname + "; Gegenereerd op: " + DateTime.Now);
                wr.WriteLine("Parameter description;Parameter value;number of clusters");
            }
        }
        public void WriteCsv(String directory, String usedParameter, String numberOfClusters, String excelfilename, int count)
        {

            string path = Path.Combine(directory, excelfilename);
            StreamWriter wr = new StreamWriter(path, true, Encoding.UTF8);
            var row = new List<string>();
            using (wr)
            {
                if (numberOfClusters != "")
                {

                    if (usedParameter != "")
                    {
                        row.Add(usedParameter + ";" + numberOfClusters + ";" + count);
                    }
                    else
                    {
                        row.Add("DEFAULT");
                    }
                }
                else {
                    if (usedParameter != "")
                    {
                        row.Add(usedParameter +  ";" + count);
                    }
                    else
                    {
                        row.Add("DEFAULT");
                    }


                }
                var sb = new StringBuilder();

                foreach (string value in row)
                {
                    // Add a comma before each string
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb = sb.Clear();
                    sb.Append(value);
                    wr.WriteLine(sb.ToString());
                }

            }


        }

        public void copyFile(string path)
        {
            string opgegevenFile = path;
            string filenaam = opgegevenFile.Split('\\').Last();
            Console.WriteLine(filenaam);
            Console.ReadLine();
            string gekopieerdPad = @"C:\Users\Christophe\Documents\Visual Studio 2017\Projects\SussolAnalysisApp\SussolAnalysisApp\Resources\" + filenaam ;
            File.Copy(opgegevenFile, gekopieerdPad, true);
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
