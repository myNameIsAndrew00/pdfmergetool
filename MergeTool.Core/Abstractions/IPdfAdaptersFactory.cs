using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core.Abstractions
{
    /// <summary>
    /// Allow creating pdf adapters based on file given as parameter.
    /// </summary>
    public interface IPdfAdaptersFactory
    {
        /// <summary>
        /// Creates an adapter based on the given filepath. Returns null if adapter can't be created.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        IPdfAdapter? CreateAdapter(string filePath);

    }
}
