using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksink.Blackboard
{
    /// <summary>
    /// Serves to suppress JS dialogs ("alert()", etc) so that crawling is not interrupted by unexpected popups.
    /// </summary>
    public class JsDialogHandler : IJsDialogHandler
    {
        public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, string acceptLang, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage) {
            suppressMessage = true;
            return false;
        }

        public bool OnJSBeforeUnload(IWebBrowser browserControl, IBrowser browser, string message, bool isReload, IJsDialogCallback callback) {
            //No need to execute the callback if we return false.
            return false;
        }

        public void OnResetDialogState(IWebBrowser browserControl, IBrowser browser) { }
        public void OnDialogClosed(IWebBrowser browserControl, IBrowser browser) { }
    }
}
