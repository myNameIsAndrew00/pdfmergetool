using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core.Abstractions
{
    /// <summary>
    /// Provides methods which allow reading files as pdf.
    /// </summary>
    public interface IPdfAdapter : IDisposable
    {
        public string FilePath { get; }

        public Stream? OpenRead();
    }
}
