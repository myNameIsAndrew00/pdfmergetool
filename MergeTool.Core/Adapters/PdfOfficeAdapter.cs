using MergeTool.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core.Adapters
{
    /// <summary>
    /// A base class for handlers which adapt a file into pdf using office COM libraries.
    /// </summary>
    /// <remarks>This adapter doesn't make any file existance check.</remarks>
    internal abstract class PdfOfficeAdapter : IPdfAdapter
    {
        private readonly string _tempFileName;
        private object _creationLock = new object();
        private bool _tempFileCreated = false;

        public string FilePath { get; }
        
        public PdfOfficeAdapter(string filePath)
        {           
            FilePath = filePath;
            _tempFileName = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
        }

        public Stream? OpenRead()
        {
            // Create a temp file which will hold the pdf document if not exist.
            lock (_creationLock)
            {
                if (!_tempFileCreated)
                {
                    try
                    {
                        GenerateTempFile(_tempFileName);

                        _tempFileCreated = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            // Return a stream pointing to temp file.
            return File.OpenRead(_tempFileName);
        }

        /// <summary>
        /// Generate the temporary file which contains the pdf document.
        /// </summary>
        /// <param name="fileName"></param>
        protected abstract void GenerateTempFile(string fileName); 

        public void Dispose()
        {
            try
            {
                // Try to clean up temp file if any.
                if(_tempFileCreated == false)
                {
                    return;
                }

                if (File.Exists(_tempFileName))
                {
                    File.Delete(_tempFileName);
                }
            }
            catch
            {

            } 
        }
    }
}
