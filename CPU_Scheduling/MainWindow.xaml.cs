using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CPU_Scheduling.Models;

namespace CPU_Scheduling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Obj obj = new Obj();
            string url = inputBox.Text;
            string[] lines = System.IO.File.ReadAllLines(url);
            string[] word;
            output.Content = "Input";
            foreach (string line in lines)
            {
                word = line.Split(' ');
                obj.Process = word[0];
                obj.ArriveTime = Int32.Parse(word[1]);
                obj.BrustTime = Int32.Parse(word[2]);
                obj.Priority = Int32.Parse(word[3]);
                obj.Quantumm = Int32.Parse(word[4]);
                output.Content += "\n" + obj.Process;
            }
        }
    }
}
