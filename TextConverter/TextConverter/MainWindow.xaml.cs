using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace TextConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int i;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog filepath = new Microsoft.Win32.OpenFileDialog();
            filepath.DefaultExt = ".txt";
            filepath.Filter = ".txt files(*.txt) | *.txt";
            filepath.CheckFileExists = false;
            filepath.CheckPathExists = true;
            Nullable<bool> result = filepath.ShowDialog();
            if (result == true)
            {
                if (File.Exists(filepath.FileName))
                {

                    using (StreamReader read = new StreamReader(filepath.FileName))
                    {
                        string text = read.ReadToEnd();
                        //string[] Lines = text.Split("\r\n");
                        ConvertedText.Text = text;
                    }
                }
            }
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            string convText = new string(""); 
            string[] Lines = ConvertedText.Text.Split("\r\n");
            foreach (string line in Lines)
            {
                string[] tabs = line.Split("\t");
                convText += $"{tabs[1]}\t{tabs[0]}\t{tabs[2]}\n";
            }
            ConvertedText.Text = convText;
        }
    }
}