using System.Linq;
using MSGHandler;
using MsgReader.Outlook;
using ReactiveUI;

namespace DesktopUI.ViewModels;

public class HomePageViewModel : PageViewModelBase
{
    private string _textBody;
    private string _RecipientsCc;
    private string _RecipientsTo;
    private string _Subject;
    private string _Attachments;

    public string Subject
    {
        get => _Subject;
        set => this.RaiseAndSetIfChanged(ref _Subject, value);
    }

    public string RecipientsTo
    {
        get => _RecipientsTo;
        set => this.RaiseAndSetIfChanged(ref _RecipientsTo, value);
    }

    public string RecipientsCc
    {
        get => _RecipientsCc;
        set => this.RaiseAndSetIfChanged(ref _RecipientsCc, value);
    }

    public string Attachments
    {
        get => _Attachments;
        set => this.RaiseAndSetIfChanged(ref _Attachments, value);
    }

    public string TextBody
    {
        get => _textBody;
        set => this.RaiseAndSetIfChanged(ref _textBody, value);
    }

    public void EmailContentToView(Email emailContent)
    {
        if (emailContent == null) return;
        Subject = "Subject: " + emailContent.Subject;
        RecipientsTo = "Recipients: " + emailContent.RecipientsTo;
        RecipientsCc = "CC: " + emailContent.RecipientsCc;
        TextBody = emailContent.TextBody;
        
        Attachments = "";
        if (emailContent.AttachmentFileNames?.Count == 0) return;
        Attachments = "\n----------------- Attachments Start -----------------\n";
        foreach (Storage.Attachment attachment in emailContent.AttachmentFileNames)
        {
            Attachments += attachment.FileName + "\n";
        }
        Attachments += "----------------- Attachments End -----------------\n";
    }
}