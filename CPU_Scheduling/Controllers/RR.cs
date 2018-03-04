using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduling.Controllers
{
    class RR
    {
        
        public string SortProcess(List<Obj> objList)
        {
            
            string Output = "\t";
            int timeuse = 0;
            int timetotal = 0;
            int retime = 0;
           
            
            foreach (var i in objList)
            {
                                 
                
                Obj newTask = new Obj();
                
                if (i.ArriveTime <= timetotal)
                {
                    if (i.BrustTime == i.Quantumm)
                    {
                        timeuse = i.BrustTime;
                        newTask.Process = i.Process;

                    }
                    else if (i.BrustTime > i.Quantumm)
                    {
                        timeuse = i.Quantumm;
                        retime = i.BrustTime - i.Quantumm; //timebrust ที่เหลือ
                        newTask.Process = i.Process;


                    }
                    else if (i.BrustTime < i.Quantumm)
                    {
                        timeuse = i.BrustTime;
                        newTask.Process = i.Process;


                    }

                    timetotal += timeuse;
                  
                }
                Output += "\t" + newTask.Process + "-" + timetotal;
                






            }
            return Output;
        }
    }
}
