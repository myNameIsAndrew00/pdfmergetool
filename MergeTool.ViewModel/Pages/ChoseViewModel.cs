using MergeTool.Core;
using MergeTool.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MergeTool.ViewModel.Pages
{
    public class ChoseFileItemViewModel : BaseViewModel
    {
        public ChoseViewModel ContainerModel { get; init; }

        public string DisplayName { get; set; }

        public string Path { get; set; }

        public int Index { get; set; }

        public byte[] Color { get; set; }

        public ICommand ChangeOrderUpCommand { get; set; }

        public ICommand ChangeOrderDownCommand { get; set; }

        public ChoseFileItemViewModel()
        {
            Color = new byte[3];

            Random.Shared.NextBytes(Color);

            ChangeOrderUpCommand = new CommandInitiator(() => ContainerModel.SwitchItemPosition(this));
            ChangeOrderDownCommand = new CommandInitiator(() => ContainerModel.SwitchItemPosition(this, bringToUpperPosition: false));
        }
    }

    public class ChoseViewModel : BaseViewModel
    {
        public ObservableCollection<ChoseFileItemViewModel> FileItems { get; set; }
        
        public ICommand GoToUploadCommand { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsProcessing { get; set; } = false;

        public ChoseViewModel()
        {
            GoToUploadCommand = new CommandInitiator( async() =>
            {
                await Application.ChangePage(ApplicationPages.Upload);
            });
        }

        public async override Task Initialise(object pageIntent)
        {
            FileItems = new ();
            string[]? filePaths = pageIntent as string[];

            if (filePaths is null)
                return;

            for(int i = 0; i < filePaths.Length; i++)
            {
                if (!File.Exists(filePaths[i]))
                    continue;

                FileItems.Add(new()
                {
                    DisplayName = Path.GetFileName(filePaths[i]),
                    Index = i + 1,
                    Path = filePaths[i],
                    ContainerModel = this
                });
            }
        }

        public async Task MergeFiles(string destinationPath)
        {
            //todo : DI may be done here
            IPdfMergeService pdfMergeService = new PdfMergeService();

            if(!Directory.Exists(destinationPath))
            {
                ErrorMessage = "Output directory not found. Chose a valid directory and try again.";
                return;
            }

            // Chose a random file name to ensure it is unique.
            string fileName = Path.Combine(destinationPath, $"merged{Guid.NewGuid().ToString().Substring(0,5)}.pdf");

            // Enable processing spinner before merging.
            IsProcessing = true;

            bool mergeSuccess = await Task.Run(() => pdfMergeService.Merge(
                destinationPath: fileName,
                pdfPaths: FileItems.OrderBy(item => item.Index)
                                   .Select(item => item.Path)
                                   .ToArray()));

            // If action succeed, change the page.
            if(mergeSuccess)
            {
                await Application.ChangePage(ApplicationPages.Success, fileName);
            }
            else
            {
                IsProcessing = false;
                ErrorMessage = "Failed to merge pdf files. Check files access, try again or contact app administrator.";
            }

        }

        public void SwitchItemPosition(ChoseFileItemViewModel item, bool bringToUpperPosition = true)
        {
            if ( (item.Index == 1 && bringToUpperPosition) || (item.Index == FileItems.Count && !bringToUpperPosition))
                return;

            int oldPosition = item.Index - 1;
            int newPosition = bringToUpperPosition ? oldPosition - 1: oldPosition + 1;

            var swappedElement = FileItems[newPosition];

            swappedElement.Index = oldPosition + 1;
            item.Index = newPosition + 1;

            FileItems[oldPosition] = swappedElement;
            FileItems[newPosition] = item;
        }
    }
}
