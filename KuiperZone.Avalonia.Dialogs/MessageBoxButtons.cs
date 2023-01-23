// -----------------------------------------------------------------------------
// PROJECT      : Avalonia Dialogs
// COPYRIGHT    : Andy Thomas (C) 2023
// LICENSE      : MIT
// HOMEPAGE     : https://github.com/kuiperzone
// -----------------------------------------------------------------------------

namespace KuiperZone.Avalonia.Dialogs;

/// <summary>
/// Buttons options for <see cref="MessageBox"/>. Note that these are flag options
/// which may be combined.
/// </summary>
[Flags]
public enum MessageBoxButtons
{
    /// <summary>
    /// No buttons.
    /// </summary>
    None = 0x0000,

    /// <summary>
    /// Standard OK.
    /// </summary>
    OK = 0x0001,

    /// <summary>
    /// Yes button.
    /// </summary>
    Yes = 0x0002,

    /// <summary>
    /// Yes All button.
    /// </summary>
    YesAll = 0x0004,

    /// <summary>
    /// No button.
    /// </summary>
    No = 0x0008,

    /// <summary>
    /// No All button.
    /// </summary>
    NoAll = 0x0010,

    /// <summary>
    /// Abort button.
    /// </summary>
    Abort = 0x0020,

    /// <summary>
    /// Cancel button.
    /// </summary>
    Cancel = 0x0040,
}
