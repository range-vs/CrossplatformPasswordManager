using CrossplatformPasswordManagerPL.iOS.Files;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL;
using System;
using System.Collections.Generic;
using UIKit;

namespace CrossplatformPasswordManagerPL.iOS;

public class Application
{
    // This is the main entry point of the application.
    static void Main(string[] args)
    {
        var types = new Dictionary<Type, Type>
        {
            { typeof(FilesProvider), typeof(IFilesProviderPlatformSpecific) }
        };
        ServiceModule.InitForPlatform(types);
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}
