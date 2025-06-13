using Avalonia.Controls;
using AvaloniaInside.Shell;
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
            DataContext = new ViewModels.Main.ListRecordsViewModel(Navigator);
            return base.InitialiseAsync(cancellationToken);
        }
    }
}
