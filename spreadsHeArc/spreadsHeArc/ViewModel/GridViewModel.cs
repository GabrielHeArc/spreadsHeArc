using spreadsHeArc.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;


namespace spreadsHeArc.ViewModel
{
    public class GridViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Module> _listModules;
        public ObservableCollection<Module> ListModules
        {
            get { return _listModules; }
            set
            {
                _listModules = value;
                RaisePropertyChanged("ListeModule");
            }
        }


        public ModuleViewModel ModuleViewModel
        { 
            get => _moduleViewModel;            
        }

        private ModuleViewModel _moduleViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public GridViewModel()
        {
            _moduleViewModel = ModuleViewModel.GetInstance();

            ListModules = new ObservableCollection<Module>();

            ListModules.Add(new Module("IA"));
            ListModules.Add(new Module("p3"));

        }

        public void buildGrid()
        {
            /*MainWindow mainWindow = (MainWindow)System.Windows.Forms.Application;
            DataGridView datagrid = new DataGridView();

            DataGrid dataGrid = new DataGrid();
            dataGrid.Columns.Add()*-*/

            //datagrid.SelectionUnit = DataGridSelectionUnit.Cell;
            //datagrid.SelectionMode = DataGridSelectionMode.Single;

            /*datagrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "Branches",
                Width = new DataGridLength(200),
                FontSize = 12,
            });

            datagrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "Notes",
                Width = new DataGridLength(200),
                FontSize = 12,
            });*/

            //datagrid.Rows.Add(new DataRow("tata"));

        /*    datagrid.ColumnCount = 3;
            datagrid.Columns[0].Name = "1";
            datagrid.Columns[1].Name = "2";
            datagrid.Columns[2].Name = "3";

            string row = "Tata";


            datagrid.Rows.Add(row);
            System.Windows.MessageBox.Show("TEST");
            mainWindow.CanvaGrid.Children.Add(datagrid);
        */

        }


        public void show()
        {/*
            foreach(Module mod in _moduleViewModel.ListModules)
            {
                System.Windows.MessageBox.Show(mod.NameModule);

                foreach( entry in mod.ListBranch)
                {
                    System.Windows.MessageBox.Show("Branche : " + entry.Key.Name + entry.Value);
                }
            }*/
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
