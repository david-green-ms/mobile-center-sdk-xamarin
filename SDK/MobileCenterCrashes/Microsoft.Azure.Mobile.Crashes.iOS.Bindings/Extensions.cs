using System;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Mobile.Crashes.iOS.Bindings
{
    /*
     * This class is required so that Mono can handle the signals SIGSEGV and SIGBUS, which should not always
     * cause a crash, but do if the native SDK's crash reporting service handles them.
     */
    public class CrashesInitializationDelegate : MSWrapperCrashesInitializationDelegate
    {
        [DllImport("libc")]
        private static extern int sigaction(Signal sig, IntPtr act, IntPtr oact);

        private enum Signal
        {
            SIGBUS = 10,
            SIGSEGV = 11
        }

        public override bool SetUpCrashHandlers()
        {
            try
            {
            }
            finally
            {
                /* Remove previously installed Mono/Xamarin signal handlers */
                Mono.Runtime.RemoveSignalHandlers();
                try
                {
                    /* Enable native SDK crash reporting library */
                    MSWrapperExceptionManager.StartCrashReportingFromWrapperSdk();
                }
                finally
                {
                    /* Let Mono reinstall it's signal handlers with proper chaining support. */
                    Mono.Runtime.InstallSignalHandlers();
                    return true;
                }
            }

            return false;
        }
    }
}
