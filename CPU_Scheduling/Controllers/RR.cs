﻿using System;
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
            List<Obj> cQ = new List<Obj>();
            List<Obj> newObj = new List<Obj>();
            int[] Atime = new int[row];
            int[] Btime = new int[row];
            string Output = "\t";
            string Output2 = "\n";
            double temp = 0;
            double temp2 = 0;
            int time = 0;
            double wt = 0;
            double tat = 0;
            Output2 += $"\tTime : \t{time}";
            int c = 0;
            foreach (var x in objList) //backup data
            {
                Btime[c] = x.BurstTime;
                Atime[c] = x.ArriveTime;
                c++;
            }
            c = 0;
            IEnumerable<Obj> queryArrive = //Get first process
                    from t in objList
                    where t.ArriveTime <= time
                    select t;
            IEnumerable<Obj> newArrive = //Check new process in that moment
                    from t in objList
                    where t.ArriveTime > time && t.ArriveTime <= time+t.Quantumm  
                    select t;
            cQ = queryArrive.OrderBy(x=>x.ArriveTime).ToList();
            while (time < totalTime)
            {
                foreach (var x in cQ.ToList())
                {
                    if (x.BurstTime > 0)
                    {
                        p.Add(x.Process);
                        newObj = newArrive.ToList();
                        foreach(var n in newObj)
                        {
                            cQ.Add(n);
                        }
                        temp += time - x.ArriveTime;
                        if (x.BurstTime >= x.Quantumm)
                        {
                            time += (x.Quantumm);
                            x.BurstTime -=  x.Quantumm;
                            x.ArriveTime += x.Quantumm;
                        }
                        else
                        {
                            time += x.BurstTime;
                            x.BurstTime = 0;
                            x.ArriveTime += x.BurstTime;
                        }
                        temp2 += time - x.ArriveTime;
                        Output2 += $" - {time}";
                        cQ.Add(x);
                        cQ.Remove(x);
                    }
                }
            }
            foreach (var x in objList)
            {
                x.BurstTime = Btime[c];
                x.ArriveTime = Atime[c];
                c++;
            }
            foreach (var i in p)
            {
                Output += $"{i}, ";
            }
            wt = temp / row;
            tat = temp2 / row;
            Output2 += $"\n \tWaitting Time : {wt}\n \tTuranaround Time : {tat}";
            return Output + Output2;
        }
    }
}
