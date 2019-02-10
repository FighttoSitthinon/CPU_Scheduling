using System;
using System.Collections.Generic;
using System.Windows;
using CPU_Scheduling.Models;
using CPU_Scheduling.Controllers;

namespace CPU_Scheduling
{
    public partial class MainWindow : Window
    {
        int totalTime;
        int row;
        string url = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Obj> ObjList = new List<Obj>();
        List<Result> result = new List<Result>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            output.Text = null;
            ObjList.Clear();
            totalTime = 0;
            row = 0;
            
            //import file by dialog.
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = " (*.txt)|*.txt";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                inputBox.Text = filename;
            }

            //validate url
            url = inputBox.Text == "Please import your file."? null: inputBox.Text;

            if(url == null)
            {
                //Alert msg
                MessageBox.Show("Please import file.");
            }
            else
            {
                // If url is real
                string[] lines = System.IO.File.ReadAllLines(url);
                string[] word;

                output.Text = "Process" + "\t" + "Arrive" + "\t" + "Brust" + "\t" + "Priority" + "\t" + "Quantumm";

                foreach (string line in lines)
                {
                    word = line.Split(' ');
                    ObjList.Add(new Obj(word[0], Int32.Parse(word[1]), Int32.Parse(word[2]), Int32.Parse(word[3]), Int32.Parse(word[4])));
                }
                foreach (Obj Obj in ObjList)
                {
                    output.Text += $"\n{Obj.Process}\t{Obj.ArriveTime}\t{Obj.BurstTime}\t{Obj.Priority}\t{Obj.Quantumm}";
                    totalTime += Obj.BurstTime;
                    row++;
                }
            }
          
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Clear text button
            if (url == null)
            {
                //Alert msg
                MessageBox.Show("Please import file.");
            }
            else
            {
                totalTime = 0;
                row = 0;
                output.Text = null;
                url = null;
                inputBox.Text = "Please import your file.";
                ObjList.Clear();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (url == null)
            {
                //Alert msg
                MessageBox.Show("Please import file.");
            }
            else
            {
                var instance2 = new PS_NP();
                output.Text += $"\n\n Priority Scheduling : {instance2.SortProcess(ObjList, totalTime, row, result)}";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (url == null)
            {
                //Alert msg
                MessageBox.Show("Please import file.");
            }
            else
            {
                var instance1 = new FCFS();
                output.Text += $"\n\n First Come First Serve : {instance1.SortProcess(ObjList, row, result)}";
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (url == null)
            {
                //Alert msg
                MessageBox.Show("Please import file.");
            }
            else
            {
                var instance5 = new PS_P();
                output.Text += $"\n\n Priority Scheduling (Preemptive) : {instance5.SortProcess(ObjList, totalTime, row, result)}";
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (url == null)
            {
                //Alert msg
                MessageBox.Show("Please import file.");
            }
            else
            {
                var instance3 = new SJF_NP();
                output.Text += $"\n\n First Job Search : {instance3.SortProcess(ObjList, totalTime, row, result)}";
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (url == null)
            {
                //Alert msg
                MessageBox.Show("Please import file.");
            }
            else
            {
                var instance6 = new SJF_P();
                output.Text += $"\n\n First Job Search (Preemptive) : {instance6.SortProcess(ObjList, totalTime, row, result)}";
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (url == null)
            {
                //Alert msg
                MessageBox.Show("Please import file.");
            }
            else
            {
                var instance4 = new RR();
                output.Text += $"\n\n Round Robin : {instance4.SortProcess(ObjList, totalTime, row, result)}";
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (url == null)
            {
                //Alert msg
                MessageBox.Show("Please import file.");
            }
            else
            {
                var instance1 = new FCFS();
                instance1.SortProcess(ObjList, row, result);
                var instance2 = new PS_NP();
                instance2.SortProcess(ObjList, totalTime, row, result);
                var instance3 = new SJF_NP();
                instance3.SortProcess(ObjList, totalTime, row, result);
                var instance4 = new RR();
                instance4.SortProcess(ObjList, totalTime, row, result);
                var instance5 = new PS_P();
                instance5.SortProcess(ObjList, totalTime, row, result);
                var instance6 = new SJF_P();
                instance6.SortProcess(ObjList, totalTime, row, result);
                var instance7 = new Analysis();
                output.Text += $"\n\n============== Anatysis All Algorithm ==============\n";
                output.Text += $"{instance7.AnalysisResult(result)}";
                output.Text += $"\n\n===========================================\n";
            }
        }
        
    }
}
