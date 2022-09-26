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

namespace MergeTool.Views.Pages
{
    /// <summary>
    /// Interaction logic for Connect.xaml
    /// </summary>
    public partial class Upload : BasePage<UploadViewModel>
    {
        public Upload()
        {
            InitializeComponent();

            this.DataContextModel.ChoseFilesEvent += async () =>
            {
                OpenFileDialog fileDialog = new OpenFileDialog();

                fileDialog.Multiselect = true;
                fileDialog.Filter = "PDF files|*.pdf";
                fileDialog.FilterIndex = 1;
              
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    await this.DataContextModel.ChoseFiles(fileDialog.FileNames);
                }
                
            };
        }

         
    }
}
