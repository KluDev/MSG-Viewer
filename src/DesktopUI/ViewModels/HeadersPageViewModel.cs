using MSGHandler;
using ReactiveUI;

namespace DesktopUI.ViewModels;

public class HeadersPageViewModel : PageViewModelBase
{
    private string _RawHeaders;
    public string RawHeaders
    {
        get => _RawHeaders;
        set => this.RaiseAndSetIfChanged(ref _RawHeaders, value);
    }
    
    public void EmailContentToView(Email emailContent)
    {
        if (emailContent == null) return;
        RawHeaders = emailContent.RawHeaders;
    }

}