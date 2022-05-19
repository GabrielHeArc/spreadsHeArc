using Microsoft.Win32;
using spreadsHeArc.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace spreadsHeArc.View
{
    /// <summary>
    /// Logique d'interaction pour SaveData.xaml
    /// </summary>
    public partial class SaveData : Window
    {
        public SaveData()
        {
            InitializeComponent();
        }

        private void BtnSaveFile_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                Console.WriteLine("SAVE");
                //File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
        }
    }
}
