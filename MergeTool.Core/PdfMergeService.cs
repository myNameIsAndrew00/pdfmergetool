using MergeTool.Core.Abstractions;
using MergeTool.Core.Commons;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core
{
    public class PdfMergeService : IPdfMergeService
    {
        public bool Merge(string destinationPath, params string[] pdfPaths)
        {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Check file paths
            if (pdfPaths is null)
                return false;

            if (pdfPaths.Length == 0)
                return false;

          

            // Iterate pdf paths and build the merged document.
            try
            {
                using PdfDocument destinationDocument = new PdfDocument(destinationPath);
               
                bool destinationHasPages = false;

                foreach (var sourcePdfPath in pdfPaths)
                {
                    if (!File.Exists(sourcePdfPath))
                        continue;

                    using (PdfDocument sourcePdf = PdfReader.Open(sourcePdfPath, PdfDocumentOpenMode.Import))
                    {
                        sourcePdf.CopyPages(destinationDocument);
                        destinationHasPages = true;
                    }
                }

                destinationDocument.Close();

                return destinationHasPages;
            }
            catch
            {
                if (File.Exists(destinationPath))
                    File.Delete(destinationPath);

                return false;
            }

        }

    }
}
