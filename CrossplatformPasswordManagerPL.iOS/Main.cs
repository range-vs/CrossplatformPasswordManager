using CrossplatformPasswordManagerPL.iOS.Files;
using CrossplatformPasswordManagerPL.iOS.Internet;
using CrossplatformPasswordManagerPL.iOS.Sequrity;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL.Files;
using PlatformSpecific.Contracts.PSL.Internet;
using PlatformSpecific.Contracts.PSL.Sequrity;
using System;
using System.Collections.Generic;
using UIKit;

namespace CrossplatformPasswordManagerPL.iOS;

public class Application
{
    // This is the main entry point of the application.
    static void Main(string[] args)
    {
        ServiceModule.InitForPlatform(
            new KeyValuePair<Type, Type>(typeof(FilesProvider), typeof(IFilesProviderPlatformSpecific)),
            new KeyValuePair<Type, Type>(typeof(OSAuth), typeof(IOSAuthPlatformSpecific)),
            new KeyValuePair<Type, Type>(typeof(InternetAdapterChecker), typeof(IInternetAdapterChecker))
         );
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}
