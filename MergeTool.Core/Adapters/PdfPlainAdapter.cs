using MergeTool.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core.Adapters
{
    /// <summary>
    /// An adapter which doesn't make any processing to the file given as parameter. Returns a stream representing the file read.
    /// </summary>
    /// <remarks>This adapter doesn't make any file existance check.</remarks>
    internal class PdfPlainAdapter : IPdfAdapter
    {
        public string FilePath { get; }
        
        public PdfPlainAdapter(string filePath)
        {
            FilePath = filePath;
        }

        public Stream? OpenRead()
        {
            return File.OpenRead(FilePath);
        }

        public void Dispose()
        { 
        }
    }
}
