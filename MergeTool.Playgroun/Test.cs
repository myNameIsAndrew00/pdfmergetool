using MergeTool.Core;
using MergeTool.Core.Abstractions;

namespace MergeTool.Playground
{
    public class Test
    {
        public static void Main()
        {
            IPdfMergeService pdfMergeService = new PdfMergeService();

            pdfMergeService.Merge(@"C:\Users\Andrei\Desktop\merged322323.pdf",
                @"P:\Projects\C#\ERegisterRepo\ERegister\ERegister\wwwroot\media\documents\ERegister_Admin.pdf",
                @"P:\Projects\C#\ERegisterRepo\ERegister\ERegister\wwwroot\media\documents\ERegister_Admin_CDC.pdf",
                @"P:\Projects\C#\ERegisterRepo\ERegister\ERegister\wwwroot\media\documents\Eregister_CDC.pdf",
                @"P:\Projects\C#\ERegisterRepo\ERegister\ERegister\wwwroot\media\documents\ERegister_Certificates.pdf",
                @"P:\Projects\C#\ERegisterRepo\ERegister\ERegister\wwwroot\media\documents\ERegister_Nomenclator.pdf",
                @"P:\Projects\C#\ERegisterRepo\ERegister\ERegister\wwwroot\media\documents\ERegister_OMdS.pdf",
                @"P:\Projects\C#\ERegisterRepo\ERegister\ERegister\wwwroot\media\documents\Presentation.pdf"
                );

        }
    }
}