using Avalonia.Controls;
using CrossplatformPasswordManagerPL.Helpers.UI;
using Ninject.Common;
using System.Collections.Generic;
using System;

namespace CrossplatformPasswordManagerPL.Views;

public partial class CommonView : UserControl
{
    public CommonView()
    {
        InitializeComponent();
        ServiceModule.InitForPlatform(
            new KeyValuePair<object, Type>(new ToastControlContainer(Toast, ToastText), typeof(IToastControlContainer))
        );
        ServiceModule.Init();

    }
}
