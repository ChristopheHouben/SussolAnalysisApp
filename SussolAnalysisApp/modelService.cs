using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SussolAnalysisApp;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Web;
using System.Linq.Expressions;

namespace SussolAnalysisApp
{
    public class modelService
    {
        List<String> features = new List<String>();
        List<int> results = new List<int>();
        TrainingSet training = new TrainingSet();
        FileWriter writer = new FileWriter();
        string resourcepath = @"C:\Users\Christophe\Documents\Visual Studio 2017\Projects\SussolAnalysisApp\SussolAnalysisApp\Resources\";
        com.sussol.web.controller.ServiceModel sus = new com.sussol.web.controller.ServiceModel();
        string feature = "";
        string filename = "";
        string directory = @"C:\Users\Christophe\Documents\Visual Studio 2017\Projects\SussolAnalysisApp\SussolAnalysisApp\Results\textfiles\Canopy analyse files";
        string directoryCsv = @"C:\Users\Christophe\Documents\Visual Studio 2017\Projects\SussolAnalysisApp\SussolAnalysisApp\Results\CSV's\Canopy resultaten csv's";
        public void GetResultFiles(string dataset, string format, string algorithmtype, string nestedOrVaried)
        {
            AlgorithmName type = (AlgorithmName)Enum.Parse(typeof(AlgorithmName), algorithmtype.ToUpper(), true);
            if (nestedOrVaried.Equals("nested"))
            {
                GetNestedResults(type, dataset, format);
            }
            //else {
            //    GetVariedresults(type, dataset, format);
            //}
           
        }
        static string GetNameOf<T>(Expression<Func<T>> property)
        {
            return (property.Body as MemberExpression).Member.Name;
        }
        //public void GetVariedresults(AlgorithmName algorithm, string dataset, string filetype)
        //{           
        //    training.dataSet = resourcepath + dataset;
        //    string datasets = File.ReadAllText(training.dataSet);
        //    JObject jObject = new JObject();
        //    string algotype = ((AlgorithmName)algorithm).ToString();
        //    switch (algorithm) {
        //        case AlgorithmName.CANOPY:
        //            for (var o = (int)Analyses.MinenMaxWaarden.canopyNmin; o < (int)Analyses.MinenMaxWaarden.canopyNmax + 1; o++)
        //            {
        //                feature = "Number of clusters";
        //                if (o != 0)
        //                {
        //                    var model = sus.canopyModeller(datasets, o.ToString(), "", "", "").ToString();
        //                    jObject = JObject.Parse(model);
        //                    JArray items = (JArray)jObject["clusters"];
        //                    int length = items.Count;
        //                    filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                    switch (filetype)
        //                    {

        //                        case "csv":
        //                            writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                            break;
        //                        case "text":
        //                            writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                            break;
        //                        case "both":
        //                            writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                            writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                            break;
        //                    }
        //                }
        //            }
        //            for (var o = (int)Analyses.MinenMaxWaarden.canopyMaxCandidatesMin; o < (int)Analyses.MinenMaxWaarden.canopyMaxCandidatesMax + 1; o++)
        //            {
        //                feature = "Maximum number of candidates";

        //                jObject = JObject.Parse(sus.canopyModeller(datasets, "", "", "", o.ToString()).ToString());

        //                JArray items = (JArray)jObject["clusters"];
        //                int length = items.Count;
        //                filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                switch (filetype)
        //                {

        //                    case "csv":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        break;
        //                    case "text":
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                    case "both":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                }
        //            }
        //            for (var o = (int)Analyses.MinenMaxWaarden.canopyT2min; o < (int)Analyses.MinenMaxWaarden.canopyT2max + 1; o++)
        //            {
        //                feature = "T2 distance";
        //                if (o != 0)
        //                {
        //                    jObject = JObject.Parse(sus.canopyModeller(datasets, "", "", o.ToString(), "").ToString());
        //                    JArray items = (JArray)jObject["clusters"];
        //                    int length = items.Count;
        //                    filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";

        //                    switch (filetype)
        //                    {

        //                        case "csv":
        //                            writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                            break;
        //                        case "text":
        //                            writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                            break;
        //                        case "both":
        //                            writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                            writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                            break;
        //                    }
        //                }
        //            }
        //            for (var o = (int)Analyses.MinenMaxWaarden.canopyT1min; o < (int)Analyses.MinenMaxWaarden.canopyT1max + 1; o++)
        //            {
        //                feature = "T1 distance";

        //                if (o != 0)
        //                {
        //                    jObject = JObject.Parse(sus.canopyModeller(datasets, "", o.ToString(), "", "").ToString());

        //                    JArray items = (JArray)jObject["clusters"];
        //                    int length = items.Count;

        //                    filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";

        //                    switch (filetype)
        //                    {

        //                        case "csv":
        //                            writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                            break;
        //                        case "text":
        //                            writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                            break;
        //                        case "both":
        //                            writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                            writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                            break;
        //                    }

        //                }

        //            }
        //            break;
        //        case AlgorithmName.SOM:
        //            for (var o = Analyses.MinenMaxWaarden.somLmin; o < Analyses.MinenMaxWaarden.somLmax + 0.001; o += 0.0899)
        //            {
        //                feature = " learning rate step ";
        //                var oString = o.ToString();
        //                jObject = JObject.Parse(sus.somModeller(datasets, oString.Replace(',','.'), "", "").ToString());
        //                JArray items = (JArray)jObject["clusters"];
        //                int length = items.Count;
        //                writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype, length);
        //                filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                switch (filetype)
        //                {

        //                    case "csv":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        break;
        //                    case "text":
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                    case "both":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                }


        //            }
        //            for (var o = (int)Analyses.MinenMaxWaarden.somHmin; o < (int)Analyses.MinenMaxWaarden.somHmax + 1; o++)
        //            {
        //                feature = "height ";

        //                jObject = JObject.Parse(sus.somModeller(training.dataSet, "", o.ToString(), "").ToString());
        //                JArray items = (JArray)jObject["clusters"];
        //                int length = items.Count;

        //                filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                switch (filetype)
        //                {

        //                    case "csv":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        break;
        //                    case "text":
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                    case "both":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                }

        //            }
        //            for (var o = (int)Analyses.MinenMaxWaarden.somWmin; o < (int)Analyses.MinenMaxWaarden.somWmax + 1; o++)
        //            {
        //                feature = "width ";

        //                jObject = JObject.Parse(sus.somModeller(training.dataSet, "", "", o.ToString()).ToString());
        //                JArray items = (JArray)jObject["clusters"];
        //                int length = items.Count;

        //                filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                switch (filetype)
        //                {

        //                    case "csv":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        break;
        //                    case "text":
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                    case "both":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                }

        //            }
        //            break;
        //        case AlgorithmName.XMEANS:
        //            for (var o = (int)Analyses.MinenMaxWaarden.xMeansImin; o < (int)Analyses.MinenMaxWaarden.xMeansImax + 1; o++)
        //            {
        //                feature = "maximum overal iterations";

        //                jObject = JObject.Parse(sus.xmeansModeller(datasets, o.ToString(), "", "", "", "").ToString());
        //                JArray items = (JArray)jObject["clusters"];
        //                int length = items.Count;
        //                filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                switch (filetype)
        //                {

        //                    case "csv":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        break;
        //                    case "text":
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                    case "both":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                }
        //            }
        //            for (var o = (int)Analyses.MinenMaxWaarden.xMeansMmin; o < (int)Analyses.MinenMaxWaarden.xMeansMmax + 1; o += 5)
        //            {
        //                feature = "maximum iterations in the kMeans loop in the Improve-Parameter part";
        //                jObject = JObject.Parse(sus.xmeansModeller(datasets, "", o.ToString(), "", "", "").ToString());
        //                JArray items = (JArray)jObject["clusters"];
        //                int length = items.Count;
        //                filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                switch (filetype)
        //                {

        //                    case "csv":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        break;
        //                    case "text":
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                    case "both":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                }
        //            }
        //            for (var o = (int)Analyses.MinenMaxWaarden.xMeansJmin; o < (int)Analyses.MinenMaxWaarden.xMeansJmax + 1; o += 5)
        //            {
        //                feature = "maximum iterations in the kMeans loop in the Improve-Structure part";
        //                jObject = JObject.Parse(sus.xmeansModeller(datasets, "", "", o.ToString(), "", "").ToString());
        //                JArray items = (JArray)jObject["clusters"];
        //                int length = items.Count;
        //                filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                switch (filetype)
        //                {

        //                    case "csv":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        break;
        //                    case "text":
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                    case "both":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                }
        //            }
        //            for (var o = (int)Analyses.MinenMaxWaarden.xMeansLmin; o < (int)Analyses.MinenMaxWaarden.xMeansLmax + 1; o++)
        //            {
        //                feature = "minimum number of clusters";
        //                jObject = JObject.Parse(sus.xmeansModeller(datasets, "", "", "", o.ToString(), "").ToString());
        //                JArray items = (JArray)jObject["clusters"];
        //                int length = items.Count;
        //                filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                switch (filetype)
        //                {

        //                    case "csv":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        break;
        //                    case "text":
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                    case "both":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                }
        //            }
        //            for (var o = (int)Analyses.MinenMaxWaarden.xMeansHmin; o < (int)Analyses.MinenMaxWaarden.xMeansHmax + 1; o++)
        //            {
        //                feature = "maximum number of clusters";
        //                jObject = JObject.Parse(sus.xmeansModeller(datasets, "", "", "", "", o.ToString()).ToString());
        //                JArray items = (JArray)jObject["clusters"];
        //                int length = items.Count;
        //                filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
        //                switch (filetype)
        //                {

        //                    case "csv":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        break;
        //                    case "text":
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                    case "both":
        //                        writer.WriteCsv(directoryCsv, feature, o.ToString(), algotype + "results " + "dataset " + dataset + ".csv", length);
        //                        writer.Writetextfile(directory, filename, jObject, o.ToString(), feature);
        //                        break;
        //                }
        //            }
        //            break;
        //    }
        //  }
        public void GetNestedResults(AlgorithmName algorithm, string dataset, string filetype) {

            training.dataSet = resourcepath + dataset;
            string datasets = File.ReadAllText(training.dataSet);
            JObject jObject = new JObject();
            string algotype = ((AlgorithmName)algorithm).ToString();
            filename = algotype + "results " + "nested parameters " + "dataset " + dataset + ".csv";
            writer.createCsv(directoryCsv, algotype, filename, dataset);
            int teller = 0;
            int length = 0;
            switch (algorithm){
            
                case AlgorithmName.CANOPY:
                    
                    
                        for (var param4 = (int)Analyses.MinenMaxWaarden.canopyT1min; param4 < (int)Analyses.MinenMaxWaarden.canopyT1max + 1; param4+=5)
                        {
                            for (var param3 = (int)Analyses.MinenMaxWaarden.canopyT2min; param3 < (int)Analyses.MinenMaxWaarden.canopyT2max + 1; param3+=5)
                            {
                                for (var param2 = (int)Analyses.MinenMaxWaarden.canopyMaxCandidatesMin; param2 < (int)Analyses.MinenMaxWaarden.canopyMaxCandidatesMax + 1; param2+=5)
                        {
                           
                              
                                    feature = "Number of clusters: " + "-1" + " Number of candidates: " + param2 + " T2 distance: " + param3 + "T1 distance: " + param4;

                                    
                                        var model = sus.canopyModeller(datasets, "-1", param4.ToString(), param3.ToString(), param2.ToString()).ToString();
                                        jObject = JObject.Parse(model);
                                        JArray items = (JArray)jObject["clusters"];
                                        length = items.Count;
                                         teller++;
                                        features.Add(feature);
                                results.Add(length);
                                        
                                        
                                    
                                       

                                }
                            }

                        }
                    writer.WriteCsv(directoryCsv, features, filename, results, teller + 2);
                    string path = Path.Combine(directoryCsv, filename);
                    writer.addGraph(path, teller);
                    teller = 0;
                    break;
                case AlgorithmName.SOM:
                    for (var param1 = Analyses.MinenMaxWaarden.somLmin; param1 < Analyses.MinenMaxWaarden.somLmax + 0.001; param1+=0.1899)
                    {
                        for (var param2 = (int)Analyses.MinenMaxWaarden.somHmin; param2 < (int)Analyses.MinenMaxWaarden.somHmax -10; param2+=10)
                        {
                            for (var param3 = (int)Analyses.MinenMaxWaarden.somWmin; param3 < (int)Analyses.MinenMaxWaarden.somWmax -10; param3+=5)
                            {
                               
                                    feature = "Learning rate: " + param1 + " Height: " + param2 + " Width: " + param3 ;
                                var param1toString = param1.ToString();

                                    var model = sus.somModeller(datasets, param1toString.Replace(',','.'), param2.ToString(), param3.ToString()).ToString();
                                    jObject = JObject.Parse(model);
                                    JArray items = (JArray)jObject["clusters"];
                                     length = items.Count;
                                    // filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
                                //    writer.WriteCsv(directoryCsv, feature, "", algotype + "results " + "nested parameters " + "dataset " + dataset + ".csv", length);

                                
                            }

                        }
                    }
                    break;
                case AlgorithmName.XMEANS:
                    //  for (var param1 = (int)Analyses.MinenMaxWaarden.xMeansImin; param1 < (int)Analyses.MinenMaxWaarden.xMeansImax + 1; param1+=5)
                    //{para
                        for (var param2 = (int)Analyses.MinenMaxWaarden.xMeansMmin; param2 < (int)Analyses.MinenMaxWaarden.xMeansMmax + 1; param2+=50)
                        {
                            for (var param3 = (int)Analyses.MinenMaxWaarden.xMeansJmin; param3 < (int)Analyses.MinenMaxWaarden.xMeansJmax + 1; param3+=500)
                            {
                                for (var param4 = (int)Analyses.MinenMaxWaarden.xMeansLmin; param4 < (int)Analyses.MinenMaxWaarden.xMeansLmax + 1; param4++)
                                {
                                    for (var param5 = (int)Analyses.MinenMaxWaarden.xMeansHmin; param5 < (int)Analyses.MinenMaxWaarden.xMeansHmax + 1; param5++)
                                    {
                                    var param1 = "1";
                                        feature = "Iteration value: " + param1 + " Max number of iterations in K-means in improveme-parameter part: " + param2 + " Max number of iterations in K-means in improveme-structure part: " + param3 + "Minimum number of clusters: " + param4 + "Maximum number of clusters: " + param5 ;


                                        var model = sus.xmeansModeller(datasets, param1.ToString(), param2.ToString(), param3.ToString(), param4.ToString(), param5.ToString()).ToString();
                                        jObject = JObject.Parse(model);
                                        JArray items = (JArray)jObject["clusters"];
                                         length = items.Count;
                                        // filename = "analyseRapport__parameter_is_" + feature + "_value_is_" + o + ".txt";
                                      //  writer.WriteCsv(directoryCsv, feature, "", algotype + "results " + "nested parameters " + "dataset " + dataset + ".csv", length);
                                    }
                                }
                            }

                        }
                    //}
                    break;
                   
            }
        }

    }
}


