# ThioWinUtils Library

A C# .NET Framework library providing managed wrappers for native Windows UI components. It enables the implementation of Modern Task Dialogs, System Tray icons, and native Win32 Context Menus without external dependencies.

#### Notes:
- This is a collection of C# class files. It's meant to be used by developers in their own apps, not end users.
- For usage examples, see included test applications (`TestConsoleApp` and `TestFormsApp`).
- `SystemTray.cs` and `ModernTaskDialog.cs` are completely standalone.
  - `ContextMenu.cs` is not standalone. It's an optional add-on to be used with `SystemTray.cs`.

## Main Classes

### `ModernTaskDialog` (ModernTaskDialog.cs)
A wrapper around the native Windows `TaskDialogIndirect` API. It replaces standard message boxes with advanced dialogs supporting command links, radio buttons, progress bars, expanders, custom icons, verification checkboxes, and real-time state updates.

### `SystemTray` (SystemTray.cs)
Manages a system tray (notification area) icon utilizing P/Invoke and `Shell_NotifyIcon`. It handles the creation of a hidden message-only window or subclasses an existing window to process Win32 mouse events (left/right clicks) and taskbar restarts.

### `TrayContextMenu` (ContextMenu.cs)
Provides context menu functionality intended for use with `SystemTray`. It utilizes Win32 API functions (`CreatePopupMenu`, `InsertMenu`, `TrackPopupMenu`) to build and display native popup menus with custom actions, separators, and default application behaviors.


## How to Compile

1. Open `ThioWinUtils.sln` using Visual Studio 2022.
2. The solution contains the main library and two testing applications.
3. The projects target .NET Framework 4.8. No additional NuGet packages are required.
4. Select your desired build configuration (Debug or Release) and build the solution (Ctrl+Shift+B).

#### Special Instructions for `ModernTaskDialog`

To use the `ModernTaskDialog` component, your executing application must be configured/manifested to use Windows Common Controls version 6.0, which is not default.
1. Add an `app.manifest` file to your executable project.
2. Uncomment the `<dependency>` section for `Microsoft.Windows.Common-Controls` (version 6.0.0.0).
3. Ensure `Application.EnableVisualStyles()` is called at application startup.
