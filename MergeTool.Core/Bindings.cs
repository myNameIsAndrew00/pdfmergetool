using MergeTool.Core.Abstractions;
using Ninject.Modules;


namespace MergeTool.Core
{
    public class Bindings : NinjectModule
    {
     
     
        public override void Load()
        {
            Bind<IPdfAdaptersFactory>().To<PdfAdaptersFactory>().InSingletonScope();
            Bind<IPdfMergeService>().To<PdfMergeService>().InSingletonScope();
        }

        /// <summary>
        /// Returns true if interop is supported 
        /// </summary>
        /// <returns></returns>
        public bool InteropAllowed() => PdfAdaptersFactory.AllowInterop; 
       
    }
}
