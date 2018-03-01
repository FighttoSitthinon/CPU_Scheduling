using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduling.Models
{
     
    class Obj 
    {
        public Obj(string process, int arriveTime, int brustTime, int priority, int quantumm)
        {
            Process = process;
            ArriveTime = arriveTime;
            BrustTime = brustTime;
            Priority = priority;
            Quantumm = quantumm;
        }

        public String Process { get; set;}
        public int ArriveTime { get; set; }
        public int BrustTime { get; set; }
        public int Priority { get; set; }
        public int Quantumm { get; set; }
    }
}
