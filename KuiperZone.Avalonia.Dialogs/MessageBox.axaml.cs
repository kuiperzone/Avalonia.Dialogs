// -----------------------------------------------------------------------------
// PROJECT      : Avalonia Dialogs
// COPYRIGHT    : Andy Thomas (C) 2023
// LICENSE      : MIT
// HOMEPAGE     : https://github.com/kuiperzone
// -----------------------------------------------------------------------------

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;

namespace KuiperZone.Avalonia.Dialogs;

/// <summary>
/// A MessageBox class. It can be shown by calling on the static ShowDialog() methods, or by constucting
/// an instance and calling the non-static <see cref="Window.ShowDialog(Window)"/> which returns the value
/// type <see cref="MessageBoxButtons"/> indicating which. The default window title is set from the application name.
/// </summary>
public partial class MessageBox : Window
{
    private readonly StackPanel _panel;
    private readonly TextBlock _text;

    static MessageBox()
    {
        DefaultTitle = Application.Current?.Name ?? string.Empty;

        var temp = new TemplatedControl();
        DefaultFontSize = temp.FontSize;

        ButtonNames = new Dictionary<MessageBoxButtons, string>();
        ButtonNames.Add(MessageBoxButtons.OK, "Ok");
        ButtonNames.Add(MessageBoxButtons.Yes, "Yes");
        ButtonNames.Add(MessageBoxButtons.YesAll, "Yes All");
        ButtonNames.Add(MessageBoxButtons.No, "No");
        ButtonNames.Add(MessageBoxButtons.NoAll, "No All");
        ButtonNames.Add(MessageBoxButtons.Cancel, "Cancel");
        ButtonNames.Add(MessageBoxButtons.Abort, "Abort");
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public MessageBox()
    {
        AvaloniaXamlLoader.Load(this);

        Title = DefaultTitle;
        _text = FindOrThrow<TextBlock>("Text");
        _panel = FindOrThrow<StackPanel>("Buttons");
    }

    /// <summary>
    /// Gets or sets the default application title. It is initalised from <see cref="Application.Name"/>,
    /// but may be overridden.
    /// </summary>
    public static string DefaultTitle { get; set; }

    /// <summary>
    /// Gets the default font size of the theme. It does not respond to theme changes.
    /// The value may be used to help scale the size of the window.
    /// </summary>
    public static double DefaultFontSize { get; }

    /// <summary>
    /// Gets a dictionary of button language strings. By default, the dictionary is populated
    /// with English names. They may be updated for internationalisation.
    /// </summary>
    public static IDictionary<MessageBoxButtons, string> ButtonNames { get; }

    /// <summary>
    /// Gets or sets the message text.
    /// </summary>
    public string? Message
    {
        get { return _text.Text; }
        set { _text.Text = value; }
    }

    /// <summary>
    /// Gets or sets the buttons shown.
    /// </summary>
    public MessageBoxButtons Buttons { get; set; } = MessageBoxButtons.OK;

    /// <summary>
    /// Shows an instance of <see cref="MessageBox"/>. A default is used for the window title.
    /// The result comprises a single <see cref="MessageBoxButtons"/> flag value pertaining to the button clicked.
    /// If the user clicks "X" in the title bar, the result is <see cref="MessageBoxButtons.None"/>.
    /// </summary>
    public static Task<MessageBoxButtons> ShowDialog(Window owner, string msg, MessageBoxButtons btns = MessageBoxButtons.OK)
    {
        return ShowDialog(owner, msg, string.Empty, btns);
    }

    /// <summary>
    /// Shows an instance of <see cref="MessageBox"/>. The result comprises a single <see cref="MessageBoxButtons"/>
    /// flag value pertaining to the button clicked. If the user clicks "X" in the title bar, the result is
    /// <see cref="MessageBoxButtons.None"/>.
    /// </summary>
    public static Task<MessageBoxButtons> ShowDialog(Window owner, string msg, string title, MessageBoxButtons btns = MessageBoxButtons.OK)
    {
        var box = new MessageBox();
        box.Message = msg;
        box.Buttons = btns;

        if (!string.IsNullOrWhiteSpace(title))
        {
            box.Title = title;
        }

        return box.ShowDialog<MessageBoxButtons>(owner);
    }

    /// <summary>
    /// Shows an instance of <see cref="MessageBox"/> with exception information. If stack is true,
    /// the full error stack is shown, whereas only the message is shown if false. If null, the
    /// stack is shown only where DEBUG is defined. The result comprises a single <see cref="MessageBoxButtons"/>
    /// flag value pertaining to the button clicked.
    /// </summary>
    public static Task<MessageBoxButtons> ShowDialog(Window owner, Exception error, bool? stack = null)
    {
#if DEBUG
        stack ??= true;
#endif
        var msg = error.Message;

        if (stack == true)
        {
            msg += "\n\n";
            msg += error.ToString();
        }

        return ShowDialog(owner, msg, error.GetType().Name);
    }

    /// <summary>
    /// Overrides.
    /// </summary>
    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);

        foreach (var item in Enum.GetValues<MessageBoxButtons>())
        {
            if (Buttons.HasFlag(item))
            {
                AddButton(item);
            }
        }

        if (Buttons != MessageBoxButtons.None)
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
    }

    private T FindOrThrow<T>(string name) where T : class, IControl
    {
        return this.FindControl<T>(name) ??
            throw new ArgumentException($"Child control {name} not found in parent {Name ?? "control"}");
    }

    private void AddButton(MessageBoxButtons btn)
    {
        if (btn != MessageBoxButtons.None)
        {
            string? caption;

            if (!ButtonNames.TryGetValue(btn, out caption))
            {
                caption = btn.ToString();
            }

            var scale = FontSize / DefaultFontSize;

            var c = new Button();
            c.Content = caption;
            c.MinWidth = 56 * scale;
            c.MinHeight = 28 * scale;
            c.IsDefault = btn == MessageBoxButtons.OK;
            c.IsCancel = btn == MessageBoxButtons.Cancel || btn == MessageBoxButtons.Abort;

            c.Click += (_, __) => { this.Close(btn); };
            _panel.Children.Add(c);
        }
    }
}
