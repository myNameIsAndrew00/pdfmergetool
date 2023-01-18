using MergeTool.Core.Extensions;
using MergeTool.ViewModel.Enums;
using System.Windows.Input;

namespace MergeTool.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {        

        public ICommand CloseCommand { get; set; }
    
        public MainWindowViewModel(Action closeCallback)
        {
            CloseCommand = new CommandInitiator(closeCallback);

            if (!this.OfficeInstalled())
            {
                Application.ChangeStatus("Microsoft Office is not installed. Excel or word files will not be allowed for merging.", InfoStatus.Warning);
            }
        }


    }
}
