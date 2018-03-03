using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPU_Scheduling.Models;

namespace CPU_Scheduling.Controllers
{
    class PS_NP
    {
        public string SortProcess(List<Obj> objList,int totalTime,int row)
        {
            string[] p = new string[row];
            string Output = "\t";
            int[] priority = new int[row];
            int time = 0;
            int count;
            var PriorityList = objList.OrderBy(x=>x.Priority).ToList();
            //for(int i = 0; i < totalTime;i++ )
            //{
            //    int count = 0;

            //    foreach (var x in objList)
            //    {
            //        if(x.ArriveTime == i)
            //        {

            //        }
            //       count++;
            //    }
            //}
            while (time == totalTime)
            {
                count = 0;
                foreach (var x in objList)
                {
                    if (x.ArriveTime <= time)
                    {
                        foreach (var w in objList)
                        {
                            if (x.Priority < w.Priority && x.ArriveTime <= time && w.ArriveTime <= time) {
                                p[count] = x.Process;
                                priority[count] = x.Priority;
                                time += x.BrustTime;
                            }
                        }
                        
                    }
                    
                }
            }
            for (int i = 0; i < row; i++)
            {
                Output += $"{p[i]},  ";
            }
                
            return Output ;
        }
        //public int recursivePriorityList(<Obj> objList, int totalTime, int row)
        //{

        //    return 
        //}
       
    }
}
