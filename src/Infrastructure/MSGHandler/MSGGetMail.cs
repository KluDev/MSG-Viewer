using System.Diagnostics;

namespace MSGHandler;

public class MSGGetMail
{
    public Email MsgGetMailContent(string filename)
    {
        var msg = new MsgReader.Outlook.Storage.Message(filename);
        var EmailContent = new Email
        {
            RecipientsTo = msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.To, false, false),
            RecipientsCc = msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.Cc, false, false),
            Subject = msg.Subject,
            Headers = msg.Headers,
            TextBody = msg.BodyText,
            
            AttachmentFileNames = msg.Attachments
        };
        foreach (string? value in msg.Headers.RawHeaders)
        {
            if (value == "Received")
            {
                EmailContent.RawHeaders += value + ": " + msg.Headers.RawHeaders[value].Replace(",from", "\nfrom");
                EmailContent.RawHeaders += "\n\r";
            }
            else
            {
                EmailContent.RawHeaders += value + ": " + msg.Headers.RawHeaders[value] + "\n\r";
            }

        }
            
        return EmailContent;
    }
}
