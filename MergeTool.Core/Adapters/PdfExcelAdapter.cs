using MergeTool.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core.Adapters
{
    /// <summary>
    /// An adapter which adapt an excel file into a pdf.
    /// </summary>
    /// <remarks>This adapter doesn't make any file existance check.</remarks>
    internal class PdfExcelAdapter : PdfOfficeAdapter
    {
        const string EXCEL_COM_PROG_ID = "Excel.Application";
        const ushort EXPORT_PDF_FORMAT = 0;

        internal static Type? ExcelCOM;
     
        static PdfExcelAdapter()
        {
            ExcelCOM = Type.GetTypeFromProgID(EXCEL_COM_PROG_ID, throwOnError: false);
        }

        
        public PdfExcelAdapter(string filePath) : base(filePath) { 
        }

        protected override void GenerateTempFile(string tempFileName)
        {

            dynamic appExcel = Activator.CreateInstance(ExcelCOM); 
            dynamic excelDocument = appExcel.Workbooks.Open(FilePath, false, true);
             
            if (excelDocument != null)
            {
                excelDocument.ExportAsFixedFormat(EXPORT_PDF_FORMAT, tempFileName);
                excelDocument.Close();
            }

            appExcel.Quit();
        }

    }
}
