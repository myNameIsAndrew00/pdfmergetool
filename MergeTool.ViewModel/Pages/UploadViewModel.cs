using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MergeTool.ViewModel.Pages
{
    public class UploadViewModel : BaseViewModel
    {
        public ICommand ChoseFilesCommand { get; set; }

        public event Action ChoseFilesEvent;

        public UploadViewModel()
        {
            ChoseFilesCommand = new CommandInitiator(() => ChoseFilesEvent?.Invoke());
        }

        public async Task ChoseFiles(string[] fileNames)
        {
            File.WriteAllText(@"C:\Users\Andrei\Desktop\tedsx.txt", "dssdds");

            await Application.ChangePage(ApplicationPages.Chose, fileNames);
        }

         
    }
}
