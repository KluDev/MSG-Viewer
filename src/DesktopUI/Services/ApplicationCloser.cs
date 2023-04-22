using System.Diagnostics;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace DesktopUI.Services;

public class ApplicationCloser
{
    public void CloseApp()
    {
        // Persist application data if needed
        
        // Shutdown application
        var lifetime = (IClassicDesktopStyleApplicationLifetime) Application.Current.ApplicationLifetime;
        lifetime.Shutdown();
    }
}