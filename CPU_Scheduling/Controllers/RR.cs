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
        
        public string SortProcess(List<Obj> objList)
        {
            
            string Output = "\t";
            string Output2 = "\t";
            int timeuse = 0;
            int timetotal = 0;
            int retime = 0;
           
            
            foreach (var i in objList)
            {
                                 
                
                Obj newTask = new Obj();
                Obj queue = new Obj();

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
                        retime = i.BrustTime - i.Quantumm;
                        newTask.Process = i.Process;



                    }
                    else if (i.BrustTime < i.Quantumm)
                    {
                        timeuse = i.BrustTime;
                        newTask.Process = i.Process;


                    }

                    

                }

                else
                {
                    if (retime != 0)
                    {
                        {
                           
                            ///วนยังไงเพื่อเช็คใน Queue ว่า process ที่มีเวลาที่เหลือไม่เท่ากับ0
                                newTask.Process = i.Process;
                                retime = retime - i.Quantumm;
                                timeuse = i.Quantumm;
                            
                        }
                    }
                }
                timetotal += timeuse;
                queue.Process += newTask.Process;
                Output += "\t" + queue.Process + "-" + timetotal;

            }
            return Output;
        }
    }
}
