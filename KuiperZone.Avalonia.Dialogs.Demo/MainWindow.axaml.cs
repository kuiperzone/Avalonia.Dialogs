// -----------------------------------------------------------------------------
// PROJECT      : Avalonia Dialogs
// COPYRIGHT    : Andy Thomas (C) 2023
// LICENSE      : MIT
// HOMEPAGE     : https://github.com/kuiperzone
// -----------------------------------------------------------------------------

using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace KuiperZone.Avalonia.Dialogs.Demo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void OKCancel_Click(object? sender, RoutedEventArgs e)
    {
        var rslt = await MessageBox.ShowDialog(this, "OK message", MessageBoxButtons.OK | MessageBoxButtons.Cancel);
        ResultBlock.Text = rslt.ToString();
    }

    private async void YesNo_Click(object? sender, RoutedEventArgs e)
    {
        var rslt = await MessageBox.ShowDialog(this, "OK message", "Title Text", MessageBoxButtons.Yes | MessageBoxButtons.No | MessageBoxButtons.YesAll | MessageBoxButtons.NoAll | MessageBoxButtons.Abort);
        ResultBlock.Text = rslt.ToString();
    }

    private async void Exception_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            throw new InvalidOperationException("Test exception");
        }
        catch (Exception x)
        {
            var rslt = await MessageBox.ShowDialog(this, x);
            ResultBlock.Text = rslt.ToString();
        }

    }

}