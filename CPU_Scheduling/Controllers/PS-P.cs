using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPU_Scheduling.Models;

namespace CPU_Scheduling.Controllers
{
    class PS_P
    {
        public string SortProcess(List<Obj> objList, int totalTime, int row)
        {
            List<string> p = new List<string>();
            int[] Btime = new int[row];
            int[] Atime = new int[row];
            string Output = "\t";
            string Output2 = "\n";
            double temp = 0;
            double temp2 = 0;
            bool key = false;
            int time = 0;
            double wt = 0;
            double tat = 0;
            Output2 += $"\tTime : {time}";
            int c = 0;
            foreach (var x in objList)
            {
                Btime[c] = x.BurstTime;
                Atime[c] = x.ArriveTime;
                c++;
            }
            c = 0;
            while (time < totalTime)
            {
                IEnumerable<Obj> queryArrive =
                    from t in objList
                    where t.ArriveTime <= time
                    select t;
                var qPriority = queryArrive.OrderBy(x => x.Priority).ToList();

                foreach (var x in qPriority)
                {
                    if (x.BurstTime != 0)
                    {
                        key = false;
                        p.Add(x.Process);
                        temp += time - x.ArriveTime;
                        time += x.BurstTime;
                       
                        IEnumerable<Obj> queryP =
                            from b in objList
                            where b.ArriveTime <= time 
                            select b;
                        foreach(var w in queryP)
                        {
                            if (w.Priority < x.Priority && w.BurstTime!=0)
                            {
                                x.BurstTime = (time - w.ArriveTime);
                                temp -= x.BurstTime;
                                temp += time - w.ArriveTime;
                                time -= (x.BurstTime);
                                temp2 += time - x.ArriveTime;
                                Output2 += $" - {time}";
                                p.Add(w.Process);
                                time += w.BurstTime;
                                w.BurstTime = 0;
                                Output2 += $" - {time}";
                                temp2 += time - w.ArriveTime;
                                x.ArriveTime = w.ArriveTime;
                                key = true;
                                break;
                            }

                        }
                        
                        if (key == false)
                        {
                            x.BurstTime = 0;
                            Output2 += $" - {time}";
                            temp2 += time - x.ArriveTime;
                        }
                        break;
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
            return Output+ Output2;
        }
    }
}
