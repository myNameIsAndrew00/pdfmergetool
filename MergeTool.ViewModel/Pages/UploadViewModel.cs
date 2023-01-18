using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MergeTool.Core.Extensions;
using MergeTool.ViewModel.Enums;

namespace MergeTool.ViewModel.Pages
{
    public class UploadViewModel : BaseViewModel
    {
        public ICommand ChoseFilesCommand { get; set; }

        public List<(string Label, string Extension)> AllowedFormats { get; } = new ();

        public event Action ChoseFilesEvent;

        public UploadViewModel()
        {
            ChoseFilesCommand = new CommandInitiator(() => ChoseFilesEvent?.Invoke());
            
            // By default, pdf files are only allowed
            AllowedFormats.Add(("PDF files", "*.pdf"));

            if (this.OfficeInstalled())
            {
                AllowedFormats.Add(("Excel files", "*.xlsx"));
                AllowedFormats.Add(("Word files", "*.docx"));
            }

            AllowedFormats.Insert(0, ("All", string.Join(';',AllowedFormats.Select(item => item.Extension))));
        }

        public async Task ChoseFiles(string[] fileNames)
        {
            File.WriteAllText(@"C:\Users\Andrei\Desktop\tedsx.txt", "dssdds");

            await Application.ChangePage(ApplicationPage.Chose, fileNames);
        }

         
    }
}
