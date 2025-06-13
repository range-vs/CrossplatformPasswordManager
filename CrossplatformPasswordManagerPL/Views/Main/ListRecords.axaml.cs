using Autofac.Core;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaInside.Shell;
using DialogHostAvalonia;
using Helpers.Common.Internet;
using Ninject.Common;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using CrossplatformPasswordManagerPL.Helpers.UI;
using AvaloniaInside.Shell.Data;

namespace CrossplatformPasswordManagerPL.Views.Main
{
    public partial class ListRecords : Page
    {
        public ListRecords()
        {
            InitializeComponent();
        }

        public override Task InitialiseAsync(CancellationToken cancellationToken)
        {
            DataContext = new ViewModels.Main.ListRecordsViewModel(Navigator, Resources);
            return base.InitialiseAsync(cancellationToken);
        }
    }
}
