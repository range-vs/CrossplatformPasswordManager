using CrossplatformPasswordManagerPL.iOS.Files;
using CrossplatformPasswordManagerPL.iOS.Sequrity;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL;
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
            new KeyValuePair<Type, Type>(typeof(OSAuth), typeof(IOSAuthPlatformSpecific))
         );
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}
