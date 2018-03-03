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
        public string SortProcess(List<Obj> objList, int row)
        {
            var List = objList.OrderBy(x => x.ArriveTime).ToList();
            string Output="\t ";
            int start = 0;
            int end = 0;
            double temp = 0;
            double temp2 = 0;
            double Wt = 0;
            double tat = 0;
            foreach (var i in List)
            {
                Output += $"{i.Process}, "; 
            }
            Output += $"\n \tTime : {start}";
            foreach (var i in List)
            {
                Output += $" - {end+=i.BrustTime}";
                temp2 += end - i.ArriveTime;
                temp += start - i.ArriveTime;
                start = end;
            }
            Wt = temp / row;
            tat = temp2 / row;
            Output += $"\n \tWaitting Time : {Wt}\n \tTuranaround Time : {tat}";
            return Output;
        }
    }
}
