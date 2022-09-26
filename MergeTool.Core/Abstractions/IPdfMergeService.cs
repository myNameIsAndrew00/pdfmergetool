using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core.Abstractions
{
    public interface IPdfMergeService
    {
        bool Merge(string destinationPath, params string[] pdfPaths);
    }
}
