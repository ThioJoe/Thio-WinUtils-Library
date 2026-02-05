using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThioWinUtils;
using static ThioWinUtils.ModernTaskDialog;

namespace TestConsoleApp;

internal class TestModernTaskDialog
{
    internal static void Run()
    {
        Console.WriteLine("ModernTaskDialog Test Suite");
        Console.WriteLine("============================\n");

        while (true)
        {
            Console.WriteLine("Choose a test to run:");
            Console.WriteLine("1. Simple Dialog with OK Button");
            Console.WriteLine("2. Yes/No/Cancel Dialog");
            Console.WriteLine("3. Dialog with All Common Buttons");
            Console.WriteLine("4. Dialog with Different Icons");
            Console.WriteLine("5. Dialog with Custom Buttons");
            Console.WriteLine("6. Dialog with Radio Buttons");
            Console.WriteLine("7. Dialog with Verification Checkbox");
            Console.WriteLine("8. Dialog with Footer and Footer Icon");
            Console.WriteLine("9. Dialog with Expander (Collapsed)");
            Console.WriteLine("10. Dialog with Expander (Expanded by Default)");
            Console.WriteLine("11. Dialog with Progress Bar");
            Console.WriteLine("12. Dialog with Marquee Progress Bar");
            Console.WriteLine("13. Dialog with Timer Event");
            Console.WriteLine("14. Dialog with Hyperlinks");
            Console.WriteLine("15. Dialog with Command Links");
            Console.WriteLine("16. Dialog with Dynamic Text Updates");
            Console.WriteLine("17. Dialog with Button Enable/Disable");
            Console.WriteLine("18. Dialog with UAC Shield Icon");
            Console.WriteLine("19. Dialog with Event Handlers");
            Console.WriteLine("20. Complex Dialog (Multiple Features)");
            Console.WriteLine("21. Dialog with CancelClose Prevention");
            Console.WriteLine("22. Shield Icons with Colored Bars");
            Console.WriteLine("23. Test changing shield icon with bar.");

            Console.WriteLine("0. Exit");
            Console.Write("\nEnter choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Test_SimpleDialog();
                    break;
                case "2":
                    Test_YesNoCancel();
                    break;
                case "3":
                    Test_AllCommonButtons();
                    break;
                case "4":
                    Test_DifferentIcons();
                    break;
                case "5":
                    Test_CustomButtons();
                    break;
                case "6":
                    Test_RadioButtons();
                    break;
                case "7":
                    Test_VerificationCheckbox();
                    break;
                case "8":
                    Test_Footer();
                    break;
                case "9":
                    Test_ExpanderCollapsed();
                    break;
                case "10":
                    Test_ExpanderExpanded();
                    break;
                case "11":
                    Test_ProgressBar();
                    break;
                case "12":
                    Test_MarqueeProgressBar();
                    break;
                case "13":
                    Test_TimerEvent();
                    break;
                case "14":
                    Test_Hyperlinks();
                    break;
                case "15":
                    Test_CommandLinks();
                    break;
                case "16":
                    Test_DynamicTextUpdates();
                    break;
                case "17":
                    Test_ButtonEnableDisable();
                    break;
                case "18":
                    Test_UACShield();
                    break;
                case "19":
                    Test_EventHandlers();
                    break;
                case "20":
                    Test_ComplexDialog();
                    break;
                case "21":
                    Test_CancelCloseDialog();
                    break;
                case "22":
                    Test_ShieldWithColoredBars();
                    break;
                case "23":
                    Test_ChangingShieldWithColoredBars();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.\n");
                    break;
            }

            Console.WriteLine("\n" + new string('=', 60) + "\n");
        }
    }

    // Test 1: Simple Dialog with OK Button
    static void Test_SimpleDialog()
    {
        Console.WriteLine("Test 1: Simple Dialog with OK Button");

        ModernTaskDialog dialog = new()
        {
            Title = "Simple Dialog",
            MainInstruction = "This is a simple dialog",
            Content = "Click OK to close.",
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON
        };

        int result = dialog.Show();
        Console.WriteLine($"Button clicked: {result}");
    }

    // Test 2: Yes/No/Cancel Dialog
    static void Test_YesNoCancel()
    {
        Console.WriteLine("Test 2: Yes/No/Cancel Dialog");

        ModernTaskDialog dialog = new()
        {
            Title = "Confirm Action",
            MainInstruction = "Do you want to continue?",
            Content = "This action cannot be undone.",
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_YES_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_NO_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON
        };

        int result = dialog.Show();
        string buttonName = result switch
        {
            6 => "Yes",
            7 => "No",
            2 => "Cancel",
            _ => $"Unknown ({result})"
        };
        Console.WriteLine($"Button clicked: {buttonName} (ID: {result})");
    }

    // Test 3: All Common Buttons
    static void Test_AllCommonButtons()
    {
        Console.WriteLine("Test 3: Dialog with All Common Buttons");

        ModernTaskDialog dialog = new()
        {
            Title = "All Buttons Test",
            MainInstruction = "Testing all common buttons",
            Content = "This dialog has all available common buttons.",
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_YES_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_NO_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_RETRY_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CLOSE_BUTTON
        };

        int result = dialog.Show();
        Console.WriteLine($"Button clicked: ID {result}");
    }

    // Test 4: Different Icons
    static void Test_DifferentIcons()
    {
        Console.WriteLine("Test 4: Testing Different Icons");

        string[] iconNames = { "Information", "Warning", "Error", "Shield" };
        ModernTaskDialog.TaskDialogIcon[] icons = {
            ModernTaskDialog.TaskDialogIcon.Information,
            ModernTaskDialog.TaskDialogIcon.Warning,
            ModernTaskDialog.TaskDialogIcon.Error,
            ModernTaskDialog.TaskDialogIcon.Shield
        };

        for (int i = 0; i < icons.Length; i++)
        {
            ModernTaskDialog dialog = new()
            {
                Title = $"{iconNames[i]} Icon Test",
                MainInstruction = $"This is a {iconNames[i]} icon",
                Content = $"Displaying {iconNames[i]} icon in the dialog.",
                MainIcon = icons[i],
                CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON
            };

            dialog.Show();
        }

        Console.WriteLine("All icon tests completed.");
    }

    // Test 5: Custom Buttons
    static void Test_CustomButtons()
    {
        Console.WriteLine("Test 5: Dialog with Custom Buttons");

        ModernTaskDialog dialog = new()
        {
            Title = "Custom Buttons",
            MainInstruction = "Choose your favorite option",
            Content = "This dialog uses custom buttons instead of common buttons.",
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information,
            CustomButtons = new List<ModernTaskDialog.TaskDialogCustomButton>
            {
                new ModernTaskDialog.TaskDialogCustomButton(100, "Option A"),
                new ModernTaskDialog.TaskDialogCustomButton(101, "Option B"),
                new ModernTaskDialog.TaskDialogCustomButton(102, "Option C")
            },
            DefaultButtonId = 100
        };

        int result = dialog.Show();
        Console.WriteLine($"Custom button clicked: ID {result}");
    }

    // Test 6: Radio Buttons
    static void Test_RadioButtons()
    {
        Console.WriteLine("Test 6: Dialog with Radio Buttons");

        ModernTaskDialog dialog = new()
        {
            Title = "Radio Button Test",
            MainInstruction = "Select an option",
            Content = "Choose one of the radio button options below:",
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information,
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON,
            RadioButtons = new List<ModernTaskDialog.TaskDialogCustomButton>
            {
                new ModernTaskDialog.TaskDialogCustomButton(200, "First Option"),
                new ModernTaskDialog.TaskDialogCustomButton(201, "Second Option"),
                new ModernTaskDialog.TaskDialogCustomButton(202, "Third Option")
            },
            DefaultRadioButtonId = 200
        };

        int result = dialog.Show();
        Console.WriteLine($"Button clicked: {result}");
        Console.WriteLine($"Radio button selected: {dialog.SelectedRadioButtonId}");
    }

    // Test 7: Verification Checkbox
    static void Test_VerificationCheckbox()
    {
        Console.WriteLine("Test 7: Dialog with Verification Checkbox");

        ModernTaskDialog dialog = new()
        {
            Title = "Verification Test",
            MainInstruction = "Accept the terms",
            Content = "Please read and accept the terms and conditions.",
            VerificationText = "I agree to the terms and conditions",
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Shield
        };

        int result = dialog.Show();
        Console.WriteLine($"Button clicked: {result}");
        Console.WriteLine($"Checkbox was checked: {dialog.VerificationChecked}");
    }

    // Test 8: Footer and Footer Icon
    static void Test_Footer()
    {
        Console.WriteLine("Test 8: Dialog with Footer and Footer Icon");

        ModernTaskDialog dialog = new()
        {
            Title = "Footer Test",
            MainInstruction = "Dialog with footer",
            Content = "This dialog has a footer at the bottom with an icon.",
            Footer = "This is the footer text with additional information.",
            FooterIcon = ModernTaskDialog.TaskDialogIcon.Information,
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON
        };

        dialog.Show();
    }

    // Test 9: Expander (Collapsed)
    static void Test_ExpanderCollapsed()
    {
        Console.WriteLine("Test 9: Dialog with Expander (Initially Collapsed)");

        ModernTaskDialog dialog = new()
        {
            Title = "Expander Test",
            MainInstruction = "Dialog with expandable content",
            Content = "Click the expander button to see more details.",
            ExpandedInformation = "This is the expanded information that provides additional details about the dialog.",
            CollapsedControlText = "Show details",
            ExpandedControlText = "Hide details",
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        dialog.Show();
    }

    // Test 10: Expander (Expanded by Default)
    static void Test_ExpanderExpanded()
    {
        Console.WriteLine("Test 10: Dialog with Expander (Initially Expanded)");

        ModernTaskDialog dialog = new()
        {
            Title = "Expander Test",
            MainInstruction = "Dialog with pre-expanded content",
            Content = "The details are shown by default.",
            ExpandedInformation = "This is the expanded information that is visible immediately when the dialog opens.",
            CollapsedControlText = "Show details",
            ExpandedControlText = "Hide details",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_EXPANDED_BY_DEFAULT |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        dialog.Show();
    }

    // Test 11: Progress Bar
    static void Test_ProgressBar()
    {
        Console.WriteLine("Test 11: Dialog with Progress Bar");

        ModernTaskDialog dialog = new()
        {
            Title = "Progress Bar Test",
            MainInstruction = "Processing...",
            Content = "Please wait while the operation completes.",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_SHOW_PROGRESS_BAR |
                   ModernTaskDialog.TaskDialogFlags.TDF_CALLBACK_TIMER |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        int progress = 0;
        dialog.Created += (s, e) =>
        {
            dialog.SetProgressBarRange(0, 100);
            dialog.SetProgressBarPosition(0);
        };

        dialog.Timer += (s, e) =>
        {
            progress++;
            dialog.SetProgressBarPosition(progress);

            if (progress >= 100)
            {
                dialog.SetElementText(ModernTaskDialog.TaskDialogElements.MainInstruction, "Complete!");
                dialog.SetElementText(ModernTaskDialog.TaskDialogElements.Content, "The operation has finished successfully.");
                dialog.ClickButton(2); // Close dialog (Cancel button ID)
            }
        };

        dialog.Show();
        Console.WriteLine("Progress bar test completed.");
    }

    // Test 12: Marquee Progress Bar
    static void Test_MarqueeProgressBar()
    {
        Console.WriteLine("Test 12: Dialog with Marquee Progress Bar");

        ModernTaskDialog dialog = new()
        {
            Title = "Marquee Progress",
            MainInstruction = "Processing...",
            Content = "Please wait. This operation may take a while.",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_SHOW_MARQUEE_PROGRESS_BAR |
                   ModernTaskDialog.TaskDialogFlags.TDF_CALLBACK_TIMER |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        int ticks = 0;
        dialog.Created += (s, e) =>
        {
            dialog.SetProgressBarMarquee(true, 30);
        };

        dialog.Timer += (s, e) =>
        {
            ticks++;
            if (ticks >= 50) // Auto-close after 5 seconds
            {
                dialog.ClickButton(2);
            }
        };

        dialog.Show();
        Console.WriteLine("Marquee progress bar test completed.");
    }

    // Test 13: Timer Event
    static void Test_TimerEvent()
    {
        Console.WriteLine("Test 13: Dialog with Timer Event");

        ModernTaskDialog dialog = new()
        {
            Title = "Timer Test",
            MainInstruction = "Timer Event Demonstration",
            Content = "Time elapsed: 0 seconds",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_CALLBACK_TIMER |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        dialog.Timer += (s, e) =>
        {
            int seconds = (int)(e.TickCount / 1000);
            dialog.SetElementText(ModernTaskDialog.TaskDialogElements.Content, $"Time elapsed: {seconds} seconds");
        };

        dialog.Show();
    }

    // Test 14: Hyperlinks
    static void Test_Hyperlinks()
    {
        Console.WriteLine("Test 14: Dialog with Hyperlinks");

        ModernTaskDialog dialog = new()
        {
            Title = "Hyperlink Test",
            MainInstruction = "Dialog with Hyperlinks",
            Content = "Click the links below:\n<a href=\"https://www.microsoft.com\">Microsoft Website</a>\n<a href=\"https://github.com\">GitHub</a>",
            Footer = "Links open in your default browser: <a href=\"https://www.google.com\">Google</a>",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_ENABLE_HYPERLINKS |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        dialog.HyperlinkClicked += (s, e) =>
        {
            Console.WriteLine($"Hyperlink clicked: {e.Url}");
            System.Diagnostics.Process.Start(e.Url);
        };

        dialog.Show();
    }

    // Test 15: Command Links
    static void Test_CommandLinks()
    {
        Console.WriteLine("Test 15: Dialog with Command Links");

        ModernTaskDialog dialog = new()
        {
            Title = "Command Links",
            MainInstruction = "Choose an action",
            Content = "Command links provide a clear description of each option.",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_USE_COMMAND_LINKS |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            CustomButtons = new List<ModernTaskDialog.TaskDialogCustomButton>
            {
                new ModernTaskDialog.TaskDialogCustomButton(300, "Save Document\nSaves the current document to disk"),
                new ModernTaskDialog.TaskDialogCustomButton(301, "Export as PDF\nExports the document in PDF format"),
                new ModernTaskDialog.TaskDialogCustomButton(302, "Print Document\nSends the document to the printer")
            },
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        int result = dialog.Show();
        Console.WriteLine($"Command link clicked: ID {result}");
    }

    // Test 16: Dynamic Text Updates
    static void Test_DynamicTextUpdates()
    {
        Console.WriteLine("Test 16: Dialog with Dynamic Text Updates");

        ModernTaskDialog dialog = new()
        {
            Title = "Dynamic Updates",
            MainInstruction = "Initial Instruction",
            Content = "Initial content",
            Footer = "Initial footer",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_CALLBACK_TIMER |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information,
            FooterIcon = ModernTaskDialog.TaskDialogIcon.Warning
        };

        int updateCount = 0;
        dialog.Timer += (s, e) =>
        {
            if (e.TickCount % 1000 == 0) // Every second
            {
                updateCount++;
                dialog.SetElementText(ModernTaskDialog.TaskDialogElements.MainInstruction, $"Update #{updateCount}");
                dialog.SetElementText(ModernTaskDialog.TaskDialogElements.Content, $"Content updated {updateCount} time(s)");
                dialog.SetElementText(ModernTaskDialog.TaskDialogElements.Footer, $"Footer update #{updateCount}");

                if (updateCount == 5)
                {
                    dialog.ClickButton(1); // Close dialog
                }
            }
        };

        dialog.Show();
        Console.WriteLine("Dynamic text update test completed.");
    }

    // Test 17: Button Enable/Disable
    static void Test_ButtonEnableDisable()
    {
        Console.WriteLine("Test 17: Dialog with Button Enable/Disable");

        ModernTaskDialog dialog = new()
        {
            Title = "Button Enable/Disable",
            MainInstruction = "Wait 3 seconds to enable the OK button",
            Content = "The OK button will be enabled after a countdown.",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_CALLBACK_TIMER |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        dialog.Created += (s, e) =>
        {
            dialog.EnableButton(1, false); // Disable OK button (ID 1)
        };

        int countdown = 3;
        dialog.Timer += (s, e) =>
        {
            if (e.TickCount % 1000 == 0 && countdown > 0)
            {
                countdown--;
                dialog.SetElementText(ModernTaskDialog.TaskDialogElements.Content,
                    countdown > 0 ? $"The OK button will be enabled in {countdown} second(s)." : "OK button is now enabled!");

                if (countdown == 0)
                {
                    dialog.EnableButton(1, true); // Enable OK button
                }
            }
        };

        dialog.Show();
    }

    // Test 18: UAC Shield Icon
    static void Test_UACShield()
    {
        Console.WriteLine("Test 18: Dialog with UAC Shield Icon on Button");

        ModernTaskDialog dialog = new()
        {
            Title = "UAC Shield Test",
            MainInstruction = "Administrative Action Required",
            Content = "The Install button requires administrator privileges.",
            CustomButtons = new List<ModernTaskDialog.TaskDialogCustomButton>
            {
                new ModernTaskDialog.TaskDialogCustomButton(400, "Install (Requires Admin)"),
                new ModernTaskDialog.TaskDialogCustomButton(401, "Cancel")
            },
            MainIcon = ModernTaskDialog.TaskDialogIcon.Shield
        };

        dialog.Created += (s, e) =>
        {
            dialog.SetButtonElevationRequiredState(400, true); // Add shield to Install button
        };

        int result = dialog.Show();
        Console.WriteLine($"Button clicked: ID {result}");
    }

    // Test 19: Event Handlers
    static void Test_EventHandlers()
    {
        Console.WriteLine("Test 19: Dialog with Multiple Event Handlers");

        ModernTaskDialog dialog = new()
        {
            Title = "Event Handlers Test",
            MainInstruction = "Testing all event handlers",
            Content = "Interact with the dialog to trigger events.",
            VerificationText = "Don't show this again",
            ExpandedInformation = "This is expanded information.",
            CollapsedControlText = "More info",
            ExpandedControlText = "Less info",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_CALLBACK_TIMER |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            RadioButtons = new List<ModernTaskDialog.TaskDialogCustomButton>
            {
                new ModernTaskDialog.TaskDialogCustomButton(500, "Option 1"),
                new ModernTaskDialog.TaskDialogCustomButton(501, "Option 2")
            },
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON |
                           ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        dialog.Created += (s, e) => Console.WriteLine("Event: Dialog Created");
        dialog.ButtonClicked += (s, e) => Console.WriteLine($"Event: Button Clicked (ID: {e.ButtonId})");
        dialog.RadioButtonClicked += (s, e) => Console.WriteLine($"Event: Radio Button Clicked (ID: {e.ButtonId})");
        dialog.VerificationClicked += (s, e) => Console.WriteLine($"Event: Verification Checkbox Clicked (Checked: {e.Checked})");
        dialog.ExpandoButtonClicked += (s, e) => Console.WriteLine($"Event: Expando Button Clicked (Expanded: {e.Expanded})");
        dialog.Destroyed += (s, e) => Console.WriteLine("Event: Dialog Destroyed");

        int timerTicks = 0;
        dialog.Timer += (s, e) =>
        {
            timerTicks++;
            if (timerTicks == 1)
            {
                Console.WriteLine("Event: Timer (First tick)");
            }
        };

        dialog.Show();
        Console.WriteLine("\nAll events have been logged.");
    }

    // Test 20: Complex Dialog
    static void Test_ComplexDialog()
    {
        Console.WriteLine("Test 20: Complex Dialog with Multiple Features");

        ModernTaskDialog dialog = new()
        {
            Title = "Complex Dialog Test",
            MainInstruction = "Installation Wizard",
            Content = "This dialog demonstrates multiple features combined together.",
            Footer = "For more information, visit our website.",
            FooterIcon = ModernTaskDialog.TaskDialogIcon.Information,
            VerificationText = "I agree to the license terms",
            ExpandedInformation = "Additional installation notes:\n• Requires 500MB of disk space\n• Administrator privileges needed\n• Restart may be required",
            CollapsedControlText = "Show installation details",
            ExpandedControlText = "Hide installation details",
            Flags = ModernTaskDialog.TaskDialogFlags.TDF_USE_COMMAND_LINKS |
                   ModernTaskDialog.TaskDialogFlags.TDF_CALLBACK_TIMER |
                   ModernTaskDialog.TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   ModernTaskDialog.TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   ModernTaskDialog.TaskDialogFlags.TDF_SIZE_TO_CONTENT,
            CustomButtons = new List<ModernTaskDialog.TaskDialogCustomButton>
            {
                new ModernTaskDialog.TaskDialogCustomButton(600, "Express Installation\nRecommended settings for most users"),
                new ModernTaskDialog.TaskDialogCustomButton(601, "Custom Installation\nAdvanced options and customization"),
                new ModernTaskDialog.TaskDialogCustomButton(602, "Repair Installation\nFix problems with existing installation")
            },
            MainIcon = ModernTaskDialog.TaskDialogIcon.Shield,
            DefaultButtonId = 600
        };

        dialog.Created += (s, e) =>
        {
            dialog.SetButtonElevationRequiredState(600, true);
            dialog.SetButtonElevationRequiredState(601, true);
            dialog.SetButtonElevationRequiredState(602, true);
        };

        dialog.VerificationClicked += (s, e) =>
        {
            Console.WriteLine($"License agreement checked: {e.Checked}");
        };

        int result = dialog.Show();
        string choice = result switch
        {
            600 => "Express Installation",
            601 => "Custom Installation",
            602 => "Repair Installation",
            _ => "Unknown"
        };
        Console.WriteLine($"User selected: {choice}");
        Console.WriteLine($"License accepted: {dialog.VerificationChecked}");
    }

    // Test 21: Cancel Close Prevention
    static void Test_CancelCloseDialog()
    {
        Console.WriteLine("Test 21: Dialog with CancelClose Prevention");

        int clickCount = 0;

        ModernTaskDialog dialog = new()
        {
            Title = "CancelClose Test",
            MainInstruction = "You must click OK three times",
            Content = "The dialog will not close until you've clicked OK three times.\nClicks so far: 0",
            CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON,
            MainIcon = ModernTaskDialog.TaskDialogIcon.Information
        };

        dialog.ButtonClicked += (s, e) =>
        {
            if (e.ButtonId == 1) // OK button
            {
                clickCount++;
                Console.WriteLine($"OK clicked {clickCount} time(s)");

                if (clickCount < 3)
                {
                    e.CancelClose = true; // Prevent closing
                    dialog.SetElementText(ModernTaskDialog.TaskDialogElements.Content,
                        $"The dialog will not close until you've clicked OK three times.\nClicks so far: {clickCount}");
                }
                else
                {
                    dialog.SetElementText(ModernTaskDialog.TaskDialogElements.MainInstruction, "Success!");
                    dialog.SetElementText(ModernTaskDialog.TaskDialogElements.Content, "You clicked OK three times. Dialog will now close.");
                }
            }
        };

        dialog.Show();
        Console.WriteLine($"Dialog closed after {clickCount} clicks.");
    }

    // Test 22: Shield Icons with Colored Bars
    static void Test_ShieldWithColoredBars()
    {
        Console.WriteLine("Test 22: Shield Icons with Colored Bars");

        string[] shieldNames = { "Shield (Normal)", "Shield Blue Bar", "Shield Yellow Bar", "Shield Red Bar", "Shield Green Bar", "Shield Gray Bar" };
        ModernTaskDialog.TaskDialogIcon[] shieldIcons = {
            ModernTaskDialog.TaskDialogIcon.Shield,
            ModernTaskDialog.TaskDialogIcon.ShieldBlueBar,
            ModernTaskDialog.TaskDialogIcon.ShieldYellowBar,
            ModernTaskDialog.TaskDialogIcon.ShieldRedBar,
            ModernTaskDialog.TaskDialogIcon.ShieldGreenBar,
            ModernTaskDialog.TaskDialogIcon.ShieldGrayBar
        };

        for (int i = 0; i < shieldIcons.Length; i++)
        {
            ModernTaskDialog dialog = new()
            {
                Title = "Shield Icon Variants",
                MainInstruction = shieldNames[i],
                Content = $"This is the {shieldNames[i]} icon.\n\nThese are typically used for UAC/security prompts with different severity levels.",
                MainIcon = shieldIcons[i],
                CommonButtons = ModernTaskDialog.TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON
            };

            dialog.Show();
        }

        Console.WriteLine("All shield icon variants displayed.");
        Console.WriteLine("\nShield color meanings (typical usage):");
        Console.WriteLine("  • Red Bar    - High risk/critical security action");
        Console.WriteLine("  • Yellow Bar - Medium risk/warning");
        Console.WriteLine("  • Blue Bar   - Standard UAC elevation");
        Console.WriteLine("  • Green Bar  - Safe/verified action");
        Console.WriteLine("  • Gray Bar   - Neutral/informational");
    }

    // Test 23
    static void Test_ChangingShieldWithColoredBars()
    {
        Console.WriteLine("Test 23: Comprehensive State Preservation Test");

        // Test with ALL interactive states
        var dlg = new ModernTaskDialog()
        {
            Title = "Complete State Preservation Test",
            MainInstruction = "Test ALL State Preservation Features",
            MainIcon = TaskDialogIcon.Information,
            Content = "Instructions:\n1. Check the verification checkbox\n2. Select a different radio button\n3. Expand the details\n4. Wait - the bar color will change automatically\n5. Verify ALL states are preserved!",
            VerificationText = "I agree to the terms and conditions",
            ExpandedInformation = "This is expanded information that should be preserved.",
            CollapsedControlText = "Show details",
            ExpandedControlText = "Hide details",
            RadioButtons = new List<TaskDialogCustomButton>
            {
                new TaskDialogCustomButton(1, "Option A"),
                new TaskDialogCustomButton(2, "Option B"),
                new TaskDialogCustomButton(3, "Option C")
            },
            DefaultRadioButtonId = 1,
            CustomButtons = new List<TaskDialogCustomButton>
            {
                new TaskDialogCustomButton(100, "Action Button"),
                new TaskDialogCustomButton(101, "Another Action")
            },
            CommonButtons = TaskDialogCommonButtonFlags.TDCBF_OK_BUTTON | TaskDialogCommonButtonFlags.TDCBF_CANCEL_BUTTON,
            Coloredbar = TaskDialogBarColor.Blue,
            Flags = TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION |
                   TaskDialogFlags.TDF_POSITION_RELATIVE_TO_WINDOW |
                   TaskDialogFlags.TDF_SIZE_TO_CONTENT |
                   TaskDialogFlags.TDF_CALLBACK_TIMER |
                   TaskDialogFlags.TDF_SHOW_PROGRESS_BAR
        };

        int tickCount = 0;
        int progress = 0;

        dlg.Created += (s, e) =>
        {
            // Initialize progress bar
            dlg.SetProgressBarRange(0, 100);
            dlg.SetProgressBarPosition(0);

            // Disable one of the custom buttons initially
            dlg.EnableButton(101, false);

            // Add UAC shield to action button
            dlg.SetButtonElevationRequiredState(100, true);

            Console.WriteLine("Initial state set up complete.");
        };

        dlg.Timer += (s, e) =>
        {
            tickCount++;

            // Update progress bar every tick
            progress = Math.Min(100, tickCount * 2);
            dlg.SetProgressBarPosition(progress);

            // Update dynamic text in footer every second
            if (tickCount % 10 == 0)
            {
                int seconds = tickCount / 10;
                dlg.SetElementText(TaskDialogElements.Footer, $"Running for {seconds} seconds... Progress: {progress}%");
            }

            // Enable the disabled button after 1 second
            if (tickCount == 10)
            {
                Console.WriteLine("Enabling 'Another Action' button...");
                dlg.EnableButton(101, true);
            }

            // Enable the disabled button after 1 second
            if (tickCount == 10)
            {
                Console.WriteLine("Changing Icon");
                dlg.UpdateIcon(TaskDialogIconElement.Main, TaskDialogIcon.Warning);
            }

            // Disable Option B radio button after 1.5 seconds
            if (tickCount == 15)
            {
                Console.WriteLine("Disabling 'Option B' radio button...");
                dlg.EnableRadioButton(2, false);
            }

            // Change progress bar state to Error after 2 seconds
            if (tickCount == 20)
            {
                Console.WriteLine("Setting progress bar to Error state...");
                dlg.SetProgressBarState(TaskDialogProgressBarState.Error);
            }

            // Change bar color to Red after 2.5 seconds
            if (tickCount == 25)
            {
                Console.WriteLine("\n=== Changing bar color to RED ===");
                Console.WriteLine("All states should be preserved!");
                dlg.UpdateColoredBar(TaskDialogBarColor.Red);
            }

            // Change to Yellow after 4 seconds
            if (tickCount == 40)
            {
                Console.WriteLine("\n=== Changing bar color to YELLOW ===");
                dlg.UpdateColoredBar(TaskDialogBarColor.Yellow);
            }

            // Change to Green after 5.5 seconds
            if (tickCount == 55)
            {
                Console.WriteLine("\n=== Changing bar color to GREEN ===");
                dlg.UpdateColoredBar(TaskDialogBarColor.Green);
            }

            // Auto-close after 7 seconds
            if (tickCount == 70)
            {
                Console.WriteLine("\nTest complete! Closing dialog...");
                dlg.ClickButton(1); // Close via OK button
            }
        };

        dlg.VerificationClicked += (s, e) =>
        {
            Console.WriteLine($"Verification checkbox: {(e.Checked ? "Checked" : "Unchecked")}");
        };

        dlg.RadioButtonClicked += (s, e) =>
        {
            Console.WriteLine($"Radio button selected: Option {(char)('A' + e.ButtonId - 1)} (ID: {e.ButtonId})");
        };

        dlg.ExpandoButtonClicked += (s, e) =>
        {
            Console.WriteLine($"Expander: {(e.Expanded ? "Expanded" : "Collapsed")}");
        };

        dlg.Show();

        Console.WriteLine("\n=== FINAL RESULTS ===");
        Console.WriteLine($"Final verification state: {dlg.VerificationChecked}");
        Console.WriteLine($"Final radio button selection: Option {(char)('A' + dlg.SelectedRadioButtonId - 1)} (ID: {dlg.SelectedRadioButtonId})");
        Console.WriteLine($"Button clicked to close: {dlg.SelectedButtonId}");
        Console.WriteLine("\nIf you saw 3 color changes and all selections were preserved, the test passed!");
    }


} // End Main
