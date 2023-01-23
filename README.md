# MessageBox for Avalonia #

This is another **MessageBox** for Avalonia. It's mainly for my own use, however, it provides a great MessageBox
where things are kept pretty simple and, yet, provide a means to internationalise language strings.

It's simple to use:

    private async void ClickHandler(object? sender, RoutedEventArgs e)
    {
        var rslt = await MessageBox.ShowDialog(this, "OK message", MessageBoxButtons.OK | MessageBoxButtons.Cancel);

        if (rslt == MessageBoxButtons.OK)
        {
            // OK Clicked
        }
    }

The package is called "KuiperZone.Avalonia.Dialogs" as I may add further dialogs and other extensions in the future.

Licensed under MIT. Copyright (C) 2023 Andy Thomas
