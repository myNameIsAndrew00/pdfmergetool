using MergeTool.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core.Adapters
{
    /// <summary>
    /// An adapter which adapt an word file into a pdf.
    /// </summary>
    /// <remarks>This adapter doesn't make any file existance check.</remarks>
    internal class PdfWordAdapter : PdfOfficeAdapter
    {
        const string WORD_COM_PROG_ID = "Word.Application";
        const ushort EXPORT_PDF_FORMAT = 17;

        internal static Type? WordCOM;


        static PdfWordAdapter()
        {
            WordCOM = Type.GetTypeFromProgID(WORD_COM_PROG_ID, throwOnError: false);
        }

        public PdfWordAdapter(string filePath) : base(filePath)
        {
        }

        protected override void GenerateTempFile(string tempFileName)
        {
            dynamic appWord = Activator.CreateInstance(WordCOM);
            appWord.Options.ConfirmConversions = false;
            appWord.Options.DoNotPromptForConvert = true;

            var wordDocument = appWord.Documents.Open(FilePath, false, true);

            if (wordDocument != null)
            {
                wordDocument.ExportAsFixedFormat(tempFileName, EXPORT_PDF_FORMAT);
                wordDocument.Close();
            }

            appWord.Quit();
        }

    }
}
