using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DesktopUI.DI;
using DesktopUI.Services;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using MSGHandler;
using ReactiveUI;
using Splat;

namespace DesktopUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static readonly HomePageViewModel HomePageVm = Locator.Current.GetRequiredService<HomePageViewModel>();
    private static readonly DialogSettingsPageViewModel DialogSettingsPageVm = Locator.Current.GetRequiredService<DialogSettingsPageViewModel>();
    private static readonly HeadersPageViewModel HeadersPageVm = Locator.Current.GetRequiredService<HeadersPageViewModel>();
    private readonly IDialogService _dialogService = Locator.Current.GetRequiredService<IDialogService>();
    private static readonly ApplicationCloser ApplicationCloser = Locator.Current.GetRequiredService<ApplicationCloser>();
    
    private PageViewModelBase _mailContentPage;
    private PageViewModelBase _mailHeadersPage;
    
    
    public MainWindowViewModel()
    {
        ExitCommand = ReactiveCommand.Create(ApplicationCloser.CloseApp);
        OpenSettingsDialogCommand = ReactiveCommand.Create(OpenSettingsDialog);
        OpenMsgFileCommand = ReactiveCommand.Create(OpenMSGDialog);
    }
    
    public ICommand OpenSettingsDialogCommand { get; }
    public ICommand OpenMsgFileCommand { get; }
    public ICommand ExitCommand { get; }
    
    public PageViewModelBase MailContentPage
    {
        get => _mailContentPage;
        private set => this.RaiseAndSetIfChanged(ref _mailContentPage, value);
    }
    
    public PageViewModelBase MailHeadersPage
    {
        get => _mailHeadersPage;
        private set => this.RaiseAndSetIfChanged(ref _mailHeadersPage, value);
    }
    
    private async Task OpenSettingsDialog()
    {
        var result = await _dialogService.ShowDialogAsync<DialogSettingsPageViewModel>(this, DialogSettingsPageVm);
    }
    
    private async Task OpenMSGDialog()
    {
        var fileResult = await _dialogService.ShowOpenFileDialogAsync(this, GetSettings());
    
        if (fileResult?.Path != null)
        {
            var email = Locator.Current.GetRequiredService<MSGGetMail>().MsgGetMailContent(fileResult.LocalPath);
            HomePageVm.EmailContentToView(email);
            HeadersPageVm.EmailContentToView(email);
            MailContentPage = HomePageVm;
            MailHeadersPage = HeadersPageVm;
        }
    }
    
    private static OpenFileDialogSettings GetSettings()
    {
        return new OpenFileDialogSettings
        {
            Title = "Open mail file",
            InitialDirectory = "c:\temp",
            Filters = new List<FileFilter>
            {
                new(
                    "Email files",
                    new[]
                    {
                        ".msg"
                    }),
    
                new(
                    "Text documents",
                    new[]
                    {
                        "txt", "md"
                    }),
    
                new("All files", "*")
            }
        };
    }
}