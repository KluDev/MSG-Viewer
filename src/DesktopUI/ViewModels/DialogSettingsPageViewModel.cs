using System;
using System.Net.Mime;
using System.Windows.Input;
using Avalonia;
using Avalonia.Styling;
using HanumanInstitute.MvvmDialogs;
using ReactiveUI;

namespace DesktopUI.ViewModels;

public class DialogSettingsPageViewModel : PageViewModelBase, IModalDialogViewModel, ICloseable
{
    public static string Greeting => " Settings Page ";
    public event EventHandler? RequestClose;
    private bool? _dialogResult;
    private ThemeVariant _currentAppTheme;

    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }
    
    
    public DialogSettingsPageViewModel()
    {
        CurrentAppTheme = Application.Current.ActualThemeVariant;
        
        OkCommand = ReactiveCommand.Create(Ok);
        CancelCommand = ReactiveCommand.Create(Cancel);
    }

    public ThemeVariant[] AppThemes
    {
        get;
    } = new[] { ThemeVariant.Light, ThemeVariant.Dark };

    public ThemeVariant CurrentAppTheme
    {
        get => _currentAppTheme;
        set => _currentAppTheme = value;
        /*
        {
            if (this.RaiseAndSetIfChanged(ref _currentAppTheme, value) &&
                Application.Current.ActualThemeVariant != value)
            {
                Application.Current.RequestedThemeVariant = value;
            }
        }*/
    }

    
    public bool? DialogResult
    {
        get => _dialogResult;
        private set => this.RaiseAndSetIfChanged(ref _dialogResult, value, nameof(DialogResult));
    }
    
    private void Ok()
    {
        DialogResult = true;
        RequestClose?.Invoke(this, EventArgs.Empty);
        if (Application.Current.ActualThemeVariant != _currentAppTheme)
        {
            Application.Current.RequestedThemeVariant = _currentAppTheme;
        }
    }

    public void Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}