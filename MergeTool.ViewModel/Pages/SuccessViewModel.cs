using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MergeTool.ViewModel.Pages
{
    public class SuccessViewModel : BaseViewModel
    {
        public string? FilePath { get; set; }

        public ICommand GoToStartCommand { get; set; }

        public ICommand OpenFileExplorerCommand { get; set; }

        public async override Task Initialise(object pageIntent)
        {
            FilePath = pageIntent as string;

            GoToStartCommand = new CommandInitiator(async () =>
            {
                await Application.ChangePage(ApplicationPages.Upload);
            });

            OpenFileExplorerCommand = new CommandInitiator(async () =>
            {
                if (FilePath is not null && FilePath.Length < 1024 && File.Exists(FilePath) )
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo();

                    string arguments = string.Format("/e, /select, \"{0}\"", FilePath);

                    processInfo.FileName = "explorer.exe";
                    processInfo.Arguments = arguments;

                    Process.Start(processInfo);
                }
            });
        }
    }
}
