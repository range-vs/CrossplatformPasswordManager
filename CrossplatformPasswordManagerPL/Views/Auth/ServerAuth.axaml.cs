using Avalonia.Controls;
using AvaloniaInside.Shell;
using System.Threading;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Views.Auth
{
    public partial class ServerAuth : Page
    {
        public ServerAuth()
        {
            InitializeComponent();
        }

        public override Task InitialiseAsync(CancellationToken cancellationToken)
        {
            DataContext = new ViewModels.Auth.ServerAuthViewModel(Navigator);
            return base.InitialiseAsync(cancellationToken);
        }
    }
}
