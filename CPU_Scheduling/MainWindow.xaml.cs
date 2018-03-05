using System;
using System.Collections.Generic;
using System.Windows;
using CPU_Scheduling.Models;
using CPU_Scheduling.Controllers;

namespace CPU_Scheduling
{
    public partial class MainWindow : Window
    {
        int totalTime = 0;
        int row = 0;
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

            output.Text =  "Process" + "\t" +"Arrive"+ "\t" +"Brust" + "\t" +"Priority" + "\t" +"Quantumm";
            
            foreach (string line in lines)
            {
                word = line.Split(' ');
                ObjList.Add(new Obj(word[0], Int32.Parse(word[1]), Int32.Parse(word[2]), Int32.Parse(word[3]), Int32.Parse(word[4]))) ;
            }
            foreach(Obj Obj in ObjList)
            {
                output.Text += $"\n{Obj.Process}\t{Obj.ArriveTime}\t{Obj.BurstTime}\t{Obj.Priority}\t{Obj.Quantumm}";
                totalTime += Obj.BurstTime;
                row ++;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            output.Text = null;
            ObjList.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var instance2 = new PS_NP();
            output.Text += $"\n\n Priority Scheduling : {instance2.SortProcess(ObjList, totalTime, row)}";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var instance1 = new FCFS();
            output.Text += $"\n\n First Come First Serve : {instance1.SortProcess(ObjList, row)}";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var instance5 = new PS_P();
            output.Text += $"\n\n Priority Scheduling (Preemptive) : {instance5.SortProcess(ObjList, totalTime, row)}";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var instance3 = new SJF_NP();
            output.Text += $"\n\n First Job Search : {instance3.SortProcess(ObjList, totalTime, row)}";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var instance6 = new SJF_P();
            output.Text += $"\n\n First Job Search (Preemptive) : {instance6.SortProcess(ObjList, totalTime, row)}";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var instance4 = new RR();
            output.Text += $"\n\n Round Robin : {instance4.SortProcess(ObjList, totalTime, row)}";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

        }
    }
}
