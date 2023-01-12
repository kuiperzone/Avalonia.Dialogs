// -----------------------------------------------------------------------------
// PROJECT      : Avalonia Dialogs
// COPYRIGHT    : Andy Thomas (C) 2023
// LICENSE      : MIT
// HOMEPAGE     : https://github.com/kuiperzone
// -----------------------------------------------------------------------------

namespace KuiperZone.Avalonia;

/// <summary>
/// Buttons options for <see cref="MessageBox"/>. Note that these are flag options
/// which may be combined.
/// </summary>
[Flags]
public enum MessageBoxButtons
{
    None = 0x0000,
    OK = 0x0001,
    Yes = 0x0002,
    YesAll = 0x0004,
    No = 0x0008,
    NoAll = 0x0010,
    Abort = 0x0020,
    Cancel = 0x0040,
}
