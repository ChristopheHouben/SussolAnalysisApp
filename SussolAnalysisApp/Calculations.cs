using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace SussolAnalysisApp
{
    class Calculations
    {
        TrainingSet training;
        
        public List<Model> useAlgorithmBig(AlgorithmName algorithm)
        {

            List<Model> modal = new List<Model>();
            var min = 1;
            var max = 1000;
            var pathWithEnv = @"%USERPROFILE%\";
            var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);
            com.sussol.domain.utilities.Globals.STORAGE_PATH = filePath;
            com.sussol.web.controller.ServiceModel sus = new com.sussol.web.controller.ServiceModel();
            JObject jObject = new JObject();
            //0.5.0.9

            if (algorithm == AlgorithmName.CANOPY) {
                for (var k = min; k < max; k++)
                {
                    jObject = JObject.Parse(sus.canopyModeller(training.dataSet, "", "").ToString()); break;
                }
            }
            if (algorithm == AlgorithmName.SOM)
            {
                for (var k = min; k < max; k++)
                {
                    jObject = JObject.Parse(sus.somModeller(training.dataSet, "").ToString()); break;
                }
            }
            if (algorithm == AlgorithmName.XMEANS)
            {
                for (var k = min; k < max; k++)
                {
                    jObject = JObject.Parse(sus.xmeansModeller(training.dataSet, "", "","").ToString()); break;
                }
            }
           
            JToken jModel = jObject["model"];

            List<Model> mod = JsonHelper.ParseJson(jObject.ToString()).Models.ToList();

            return modal;

        }
    }
}
