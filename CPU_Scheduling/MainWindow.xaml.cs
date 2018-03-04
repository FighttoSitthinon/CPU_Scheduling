using System;
using System.Collections.Generic;
using System.Windows;
using CPU_Scheduling.Models;
using CPU_Scheduling.Controllers;

namespace CPU_Scheduling
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Obj> ObjList = new List<Obj>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = inputBox.Text;
            string[] lines = System.IO.File.ReadAllLines(url);
            string[] word;
            int totalTime = 0;
            int row = 0;
            output.Content =  "Process" + "\t" +"Arrive"+ "\t" +"Brust" + "\t" +"Priority" + "\t" +"Quantumm";
            
            foreach (string line in lines)
            {
                word = line.Split(' ');
                ObjList.Add(new Obj(word[0], Int32.Parse(word[1]), Int32.Parse(word[2]), Int32.Parse(word[3]), Int32.Parse(word[4]))) ;
            }
            foreach(Obj Obj in ObjList)
            {
                output.Content += $"\n{Obj.Process}\t{Obj.ArriveTime}\t{Obj.BrustTime}\t{Obj.Priority}\t{Obj.Quantumm}";
                totalTime += Obj.BrustTime;
                row ++;
            }
            var instance1 = new FCFS();
            output.Content += $"\n\n First Come First Serve : {instance1.SortProcess(ObjList,row)}";
            var instance2 = new PS_NP();
            output.Content += $"\n\n Priority Scheduling : {instance2.SortProcess(ObjList,totalTime,row)}";
            var instance3 = new SJF_NP();
            output.Content += $"\n\n First Job Search : {instance3.SortProcess(ObjList, totalTime, row)}";



        }
    }
}
