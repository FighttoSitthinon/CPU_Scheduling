using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPU_Scheduling.Models;

namespace CPU_Scheduling.Controllers
{
    class SJF_NP
    {
        public string SortProcess(List<Obj> objList, int totalTime, int row)
        {
            string[] p = new string[row];
            int[] Btime = new int[row];
            string Output = "\t\t";
            string Output2 = "\n";
            double temp = 0;
            double temp2 = 0;
            bool key = false;
            int time = 0;
            int count = 0;
            double wt = 0;
            double tat = 0;
            var JobList = objList.OrderBy(x => x.BrustTime).ToList();
            Output2 += $"\tTime : {time}";
            int c = 0;
            foreach (var x in objList)
            {
                Btime[c] = x.BrustTime;
                c++;
            }
            c = 0;
            while (time < totalTime)
            {
                IEnumerable<Obj> queryArrive =
                    from t in objList
                    where t.ArriveTime <= time
                    select t;//จับส่งไป sort เลือกเอาน้อยสุด พอ p ใหม่เข้ามาเอาที่ยังไม่เลือกไป sort
                var qJob = queryArrive.OrderBy(x => x.BrustTime).ToList();

                foreach (var x in qJob)
                {
                    if (x.BrustTime != 0)
                    {
                        p[count] = x.Process;
                        count++;
                        temp += time - x.ArriveTime;
                        time += x.BrustTime;
                        Output2 += $" - {time}";
                        temp2 += time - x.ArriveTime;
                        x.BrustTime = 0;
                        break;
                    }
                }
                key = false;
            }
            foreach (var x in objList)
            {
                x.BrustTime = Btime[c];
                c++;
            }
            for (int i = 0; i < row; i++)
            {
                Output += $"{p[i]}, ";
            }
            wt = temp / row;
            tat = temp2 / row;
            Output2 += $"\n \tWaitting Time : {wt}\n \tTuranaround Time : {tat}";
            return Output + Output2;
        }
    }
}
