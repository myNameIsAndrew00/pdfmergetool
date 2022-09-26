using MergeTool.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MergeTool.Views.Pages.Chose
{
    /// <summary>
    /// Interaction logic for Connect.xaml
    /// </summary>
    public partial class Chose : BasePage<ChoseViewModel>
    {
        public Chose()
        {
            InitializeComponent();
        }

        private async void ChoseMergeFileDirectory(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog directoryDialog = new FolderBrowserDialog();
 
            directoryDialog.Description = "Chose destination directory";
            directoryDialog.UseDescriptionForTitle = true;

            if (directoryDialog.ShowDialog() == DialogResult.OK)
            {            
                await this.DataContextModel.MergeFiles(directoryDialog.SelectedPath);
            }

        }
    }
}
