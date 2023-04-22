using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.ReactiveUI;
using DesktopUI.DI;
using DesktopUI.Services;
using Splat;

namespace DesktopUI;

internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        RegisterDependencies();
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        applicationCloser.CloseApp();
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    private static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UseReactiveUI()
            .UsePlatformDetect()
            .LogToTrace();
    }

    private static void RegisterDependencies()
    {
        Bootstrapper.Register(Locator.CurrentMutable, Locator.Current);
    }
    
    private static readonly ApplicationCloser applicationCloser = Locator.Current.GetRequiredService<ApplicationCloser>();
}