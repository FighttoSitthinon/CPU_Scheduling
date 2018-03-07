using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPU_Scheduling.Models;

namespace CPU_Scheduling.Controllers
{
    class Analysis
    {
        public string AnalysisResult(List<Result> result)
        {
            string Output="\t";
            var List1 = result.OrderBy(x => x.WaittingTime).ToList();
            foreach (var x in List1)
            {
                Output += $"\n\tShort Waitting Time is Algorithm : {x.Algorithim} \n\t\t Waitting time : {x.WaittingTime}";
                break;
            }
            Output += $"\n";
            var List2 = result.OrderBy(x => x.TurnaroundTime).ToList();
            foreach (var x in List2)
            {
                Output += $"\n\tShort Turnaround Time is Algorithm : {x.Algorithim} \n\t\t  Turnaround time : {x.TurnaroundTime}";
                break;
            }
            return Output;
        }
    }
}
