using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaInside.Shell;
using DialogHostAvalonia;
using System.Threading;
using System.Threading.Tasks;

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
