using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduling.Models
{
    class Result
    {
        public Result(string algorithim, double waittingTime, double turnaroundTime)
        {
            Algorithim = algorithim;
            WaittingTime = waittingTime;
            TurnaroundTime = turnaroundTime;
        }

        public string Algorithim { get; set;}
        public double WaittingTime { get; set; }
        public double TurnaroundTime { get; set; }
    }
}
