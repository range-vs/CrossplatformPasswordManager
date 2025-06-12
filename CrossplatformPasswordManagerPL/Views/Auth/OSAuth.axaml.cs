using Avalonia.Controls;
using AvaloniaInside.Shell;
using System.Threading;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Views.Auth
{
    public partial class OSAuth : Page
    {
        public OSAuth()
        {
            InitializeComponent();
        }

        public override Task InitialiseAsync(CancellationToken cancellationToken)
        {
            DataContext = new ViewModels.Auth.OSAuthViewModel(Navigator);
            return base.InitialiseAsync(cancellationToken);
        }
    }
}
