using Avalonia.Controls;
using AvaloniaInside.Shell;
using System.Threading;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Views.Auth
{
    public partial class LocalAuth : Page
    {
        public LocalAuth()
        {
            InitializeComponent();
        }

        public override Task InitialiseAsync(CancellationToken cancellationToken)
        {
            DataContext = new ViewModels.Auth.LocalAuthViewModel(Navigator);
            return base.InitialiseAsync(cancellationToken);
        }
    }
}
