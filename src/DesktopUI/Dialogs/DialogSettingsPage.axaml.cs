using Avalonia;
using Avalonia.Controls;

namespace DesktopUI.Dialogs;

public partial class DialogSettingsPage : Window
{
    public DialogSettingsPage()
    {
        InitializeComponent();
        this.AttachDevTools();       
    }

}