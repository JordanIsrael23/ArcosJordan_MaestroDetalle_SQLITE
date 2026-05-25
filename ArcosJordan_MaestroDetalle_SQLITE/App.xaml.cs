using Microsoft.Extensions.DependencyInjection;

namespace ArcosJordan_MaestroDetalle_SQLITE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}