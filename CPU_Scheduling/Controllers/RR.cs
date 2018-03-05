using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPU_Scheduling.Models;

namespace CPU_Scheduling.Controllers
{
    class RR
    {
        public string SortProcess(List<Obj> objList, int totalTime, int row)
        {
            List<string> p = new List<string>();
            int[] Btime = new int[row];
            string Output = "\t\t";
            string Output2 = "\n";
            double temp = 0;
            double temp2 = 0;
            int time = 0;
            double wt = 0;
            double tat = 0;
            var JobList = objList.OrderBy(x => x.BurstTime).ToList();
            Output2 += $"\tTime : {time}";
            int tempP = 0;
            int c = 0;
            foreach (var x in objList)
            {
                Btime[c] = x.BurstTime;
                tempP += (x.BurstTime/x.Quantumm)+(x.BurstTime % x.Quantumm);
                c++;
            }
            c = 0;
            //while (time < totalTime)
            //{
            //    IEnumerable<Obj> queryArrive =
            //        from t in objList
            //        where t.ArriveTime <= time
            //        select t;
            //    foreach (var x in queryArrive)
            //    {
            //        if (x.BurstTime != 0)
            //        {
            //            p.Add(x.Process);
            //            count++;
            //            temp += time - x.ArriveTime;
            //            time += (x.BurstTime - x.Quantumm);
            //            Output2 += $" - {time}";
            //            temp2 += time - x.ArriveTime;
            //            x.BurstTime = x.BurstTime - x.Quantumm;
            //        }
            //    }
            //}
            foreach (var x in objList)
            {
                x.BurstTime = Btime[c];
                c++;
            }
            //foreach (var i in p)
            //{
            //    Output += $"{i}, ";
            //}
            wt = temp / row;
            tat = temp2 / row;
            Output2 += $"\n \tWaitting Time : {wt}\n \tTuranaround Time : {tat}";
            return Output + Output2;
        }
    }
}
