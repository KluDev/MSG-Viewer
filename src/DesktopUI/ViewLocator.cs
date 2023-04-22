using System.Reflection;
using HanumanInstitute.MvvmDialogs.Avalonia;

namespace DesktopUI;

public class ViewLocator : ViewLocatorBase
{
    protected override string GetViewName(object viewModel)
    {
        if(viewModel.GetType().Name.StartsWith("Dialog"))
            return Assembly.GetExecutingAssembly().GetName().Name + ".Dialogs." +
                   viewModel.GetType().Name.Replace("ViewModel", "");
        
        return Assembly.GetExecutingAssembly().GetName().Name + ".Pages." +
               viewModel.GetType().Name.Replace("ViewModel", "");
    }
}