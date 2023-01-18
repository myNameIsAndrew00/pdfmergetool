using MergeTool.Core.Abstractions;
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
    internal class PdfMergeService : IPdfMergeService
    {
        private IPdfAdaptersFactory _adaptersFactory;

        public PdfMergeService(IPdfAdaptersFactory factory)
        {
            _adaptersFactory = factory;
        }

        public bool Merge(string destinationPath, params string[] pdfPaths)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

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
                    // Check if file path is valid.
                    if (!File.Exists(sourcePdfPath))
                        continue;

                    // Try to retrieve an adapter for the given file using the adapters factory.
                    using IPdfAdapter? adapter = _adaptersFactory.CreateAdapter(sourcePdfPath);

                    // If adapter is not null, try to get the pdf, then merge it.
                    if (adapter != null)
                    {
                        using Stream? stream = adapter.OpenRead();

                        if (stream != null)
                        {
                            using PdfDocument sourcePdf = PdfReader.Open(stream, PdfDocumentOpenMode.Import);

                            sourcePdf.CopyPages(destinationDocument);
                            destinationHasPages = true;
                        }
                    }
                }

                destinationDocument.Close();

                return destinationHasPages;
            }
            catch(Exception e)
            { 
                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }
                return false;
            }

        }

    }
}
