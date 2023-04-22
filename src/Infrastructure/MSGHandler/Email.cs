using MsgReader.Mime.Header;
using MsgReader.Outlook;

namespace MSGHandler;

public class Email
{
    public string Recipient { get; set; }
    //public List<Storage.Recipient> RecipientsTo { get; set; }
    //public List<Storage.Recipient> RecipientsCc { get; set; }
    public string RecipientsTo { get; set; }
    public string RecipientsCc { get; set; }
    public string Subject { get; set; }
    public string HtmlBody { get; set; }
    public string TextBody { get; set; }
    public MessageHeader Headers { get; set; }
    public string RawHeaders { get; set; } = "";
    public List<object> AttachmentFileNames { get; set; }

}