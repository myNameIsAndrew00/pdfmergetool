﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.ViewModel
{
    /// <summary>
    /// Main instance of the application
    /// </summary>
    public class Application : BaseViewModel
    {
        public static Application Instance { get; } = new Application();
  
        private object changePageLock = new object();

        private Application()
        {
            /// <summary>
            /// Cofigure client to ignore ssl certificate. Todo: remove this in future releases.
            /// </summary>
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        public bool CurrentPageShouldAnimateOut { get; private set; } = false;

        public bool ServerRequestSent { get; private set; } = false;

        public bool ServerDisconnected { get; private set; } = true;



        public ApplicationPages CurrentPage { get; set; } = ApplicationPages.Upload;

        /// <summary>
        /// Represents the context (view model) of current page.
        /// </summary>
        public BaseViewModel CurrentPageContext { get; set; }

        public async Task ChangePage(ApplicationPages NewPage) => await ChangePage(NewPage, null);

        public async Task ChangePage(ApplicationPages NewPage, object pageIntent)
        {
            lock (changePageLock)
            {
                // If animation is triggered, return.
                if (CurrentPageShouldAnimateOut) return;

                // If page is already set or page chaning ocurred, stop the action.
                if (NewPage == CurrentPage || CurrentPageContext is null) return;

                // Dispose the current context.
                CurrentPageContext.Dispose();
                CurrentPageContext = null;

                CurrentPageShouldAnimateOut = true;
            }

            await Task.Delay(300);

            CurrentPageShouldAnimateOut = false;
            CurrentPage = NewPage;

            // Wait until the context is loaded by UI.
            while (CurrentPageContext == null) ;


            await CurrentPageContext.Initialise(pageIntent);
        }
    }
}
