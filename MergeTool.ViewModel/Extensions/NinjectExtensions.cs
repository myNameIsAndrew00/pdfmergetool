using MergeTool.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Core.Extensions
{
    internal static class NinjectExtensions
    {
        private static StandardKernel? kernel;
        private static Bindings? bindings;

        private static Bindings Bindings => bindings ??= new Bindings();
        private static StandardKernel Kernel => kernel ??= new StandardKernel(Bindings);

        /// <summary>
        /// Get a service from application DI container.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>

        public static T? GetService<T>(this BaseViewModel _) => Kernel.TryGet<T>();

        /// <summary>
        /// Returns true if microsoft office is installed. If not, services injected using bindings may not work properly.
        /// </summary>
        /// <returns></returns>
        public static bool OfficeInstalled(this BaseViewModel _) => Bindings.InteropAllowed();
    }
}
