# MessageBox for Avalonia #

This is another **MessageBox** for Avalonia. However, I've kept things pretty simple and provide a means to
internationalise its language strings.

It's pretty simple to use:

    private async void ClickHandler(object? sender, RoutedEventArgs e)
    {
        var rslt = await MessageBox.ShowDialog(this, "OK message", MessageBoxButtons.OK | MessageBoxButtons.Cancel);

        if (rslt == MessageBoxButtons.OK)
        {
            // OK Clicked
        }
    }

The package is called "KuiperZone.Avalonia.Dialogs" as I may add further dialogs and other extensions in the future.

Currently, I'm testing this against Avalonia 0.11 preview versions. There's no reason why this won't work on 0.10,
except the MessageBox window may not be centred on the parent window in Linux. I'll release a nuget package when
version 0.11 arrives.

Licensed under MIT. Copyright (C) 2023 Andy Thomas
