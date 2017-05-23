using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SussolAnalysisApp
{
    public class Analysis
    {
        [Key]
        public long Id { get; set; }
        [Index(IsUnique = true), MaxLength(35)]
        public string Name { get; set; }
        public int NumberOfSolvents { get; set; }
        public DateTime DateCreated { get; set; }
        public User CreatedBy { get; set; }
        public Organisation SharedWith { get; set; }
        public List<AnalysisModel> AnalysisModels { get; set; }
        
    }

}
