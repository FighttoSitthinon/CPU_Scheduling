using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPU_Scheduling.Models;

namespace CPU_Scheduling.Controllers
{
    class FCFS
    {
        public string SortProcess(List<Obj> objList)
        {
            string Output="\t";
            foreach (var i in objList)
            {
                Output += $"{i.Process}\t"; 
            }
            return Output;
        }
    }
}
