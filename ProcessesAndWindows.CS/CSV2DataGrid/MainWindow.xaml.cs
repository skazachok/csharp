using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;

namespace CSV2DataGrid
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
            DataTable customers = LoadDataTableFromFile("Customers.txt");
            customerGrid.DataContext = customers.DefaultView;
		}

        private static DataTable LoadDataTableFromFile(string fileName)
        {
            DataTable table = new DataTable(Path.GetFileNameWithoutExtension(fileName));
            foreach (string line in File.ReadLines(fileName))
            {
                if (table.Columns.Count == 0)
                {
                    table.BeginInit();
                    foreach (string colName in line.Split('\t'))
                    {
                        DataColumn dc = new DataColumn(colName, typeof(string));
                        table.Columns.Add(dc);
                    }
                    table.EndInit();
                    table.BeginLoadData();
                }
                else
                {
                    DataRow row = table.NewRow();
                    int nCol = 0;
                    foreach (string value in line.Split('\t')) row[nCol++] = value;
                    table.Rows.Add(row);
                }
            }
            table.EndLoadData();
            return table;
        }

	}
}
