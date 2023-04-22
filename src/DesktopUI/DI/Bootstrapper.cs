using DesktopUI.Services;
using DesktopUI.ViewModels;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;
using MSGHandler;
using Splat;

namespace DesktopUI.DI;

public class Bootstrapper
{
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.Register(() => new DialogSettingsPageViewModel());
        services.Register(() => new HomePageViewModel());
        services.Register(() => new HeadersPageViewModel());
        services.Register(() => new MSGGetMail());
        services.Register(() => new ApplicationCloser());

        services.RegisterLazySingleton(() => (IDialogService)new DialogService(
            new DialogManager(
                new ViewLocator(),
                new DialogFactory()),
            viewModelFactory: x => Locator.Current.GetService(x)));
    }
}