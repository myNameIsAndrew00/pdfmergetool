using MergeTool.Core.Abstractions;
using MergeTool.Core.Adapters;
using MergeTool.Core.Extensions;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core
{
    internal class PdfAdaptersFactory : IPdfAdaptersFactory
    {
        public static bool AllowInterop => PdfWordAdapter.WordCOM != null && PdfExcelAdapter.ExcelCOM != null;

        public PdfAdaptersFactory()
        {
        }

        public IPdfAdapter? CreateAdapter(string filePath)
        {
            string extension = Path.GetExtension(filePath).Trim('.');

            switch (extension)
            {

                case "docx":
                    if (AllowInterop)
                    {
                        return new PdfWordAdapter(filePath);                        
                    }
                    break;
                case "xlsx":
                    if (AllowInterop)
                    {
                        return new PdfExcelAdapter(filePath);
                    }
                    break;
                case "pdf":
                default:
                    return new PdfPlainAdapter(filePath);
            }

            return null;
        }
    }
}
