using System;
using System.Collections.Generic;
using ThioWinUtils;
using static ThioWinUtils.ModernTaskDialog.Template;

namespace TestConsoleApp;

internal class TestModernTaskDialogTemplates
{
    internal static void Run()
    {
        Console.WriteLine("ModernTaskDialog Templates Test Suite");
        Console.WriteLine("=====================================\n");

        while (true)
        {
            Console.WriteLine("Choose a template test to run:");
            Console.WriteLine("1. ShowInfo");
            Console.WriteLine("2. ShowWarning");
            Console.WriteLine("3. ShowError");
            Console.WriteLine("4. ShowSuccess (green bar)");
            Console.WriteLine("5. ShowYesNo");
            Console.WriteLine("6. ShowYesNoCancel");
            Console.WriteLine("7. ShowOkCancel");
            Console.WriteLine("8. ShowRetryCancel");
            Console.WriteLine("9. ShowWithDontShowAgain");
            Console.WriteLine("10. ShowYesNoWithVerification");
            Console.WriteLine("11. ShowCommandLinks");
            Console.WriteLine("12. ShowRadioSelection");
            Console.WriteLine("13. ShowErrorWithDetails");
            Console.WriteLine("14. ShowException");
            Console.WriteLine("15. ShowInfoWithHyperlinks");


            Console.WriteLine("0. Exit");
            Console.Write("\nEnter choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Test_ShowInfo();
                    break;
                case "2":
                    Test_ShowWarning();
                    break;
                case "3":
                    Test_ShowError();
                    break;
                case "4":
                    Test_ShowSuccess();
                    break;
                case "5":
                    Test_ShowYesNo();
                    break;
                case "6":
                    Test_ShowYesNoCancel();
                    break;
                case "7":
                    Test_ShowOkCancel();
                    break;
                case "8":
                    Test_ShowRetryCancel();
                    break;
                case "9":
                    Test_ShowWithDontShowAgain();
                    break;
                case "10":
                    Test_ShowYesNoWithVerification();
                    break;
                case "11":
                    Test_ShowCommandLinks();
                    break;
                case "12":
                    Test_ShowRadioSelection();
                    break;
                case "13":
                    Test_ShowErrorWithDetails();
                    break;
                case "14":
                    Test_ShowException();
                    break;
                case "15":
                    Test_ShowInfoHyperlinks();
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

    static void Test_ShowInfo()
    {
        Console.WriteLine("Test: ShowInfo");
        ShowInfo("Application", "Operation completed successfully.", "Your file has been saved.");
        Console.WriteLine("Dialog closed.");
    }

    static void Test_ShowWarning()
    {
        Console.WriteLine("Test: ShowWarning");
        ShowWarning("Warning", "Low disk space detected.", "You have less than 1GB of free space remaining.");
        Console.WriteLine("Dialog closed.");
    }

    static void Test_ShowError()
    {
        Console.WriteLine("Test: ShowError");
        ShowError("Error", "Failed to save file.", "The file could not be written to disk. Check permissions.");
        Console.WriteLine("Dialog closed.");
    }

    static void Test_ShowSuccess()
    {
        Console.WriteLine("Test: ShowSuccess (with green bar)");
        ShowSuccess("Success", "Installation Complete!", "The application has been installed successfully.");
        Console.WriteLine("Dialog closed.");
    }

    static void Test_ShowYesNo()
    {
        Console.WriteLine("Test: ShowYesNo");
        bool result = ShowYesNo("Confirm Delete", "Are you sure you want to delete this file?",
            "This action cannot be undone.");
        Console.WriteLine($"User clicked: {(result ? "Yes" : "No")}");
    }

    static void Test_ShowYesNoCancel()
    {
        Console.WriteLine("Test: ShowYesNoCancel");
        int result = ShowYesNoCancel("Save Changes", "Do you want to save changes before closing?",
            "Your changes will be lost if you don't save them.");

        string resultText = result switch
        {
            ButtonIds.Yes => "Yes",
            ButtonIds.No => "No",
            ButtonIds.Cancel => "Cancel",
            _ => $"Unknown ({result})"
        };
        Console.WriteLine($"User clicked: {resultText}");
    }

    static void Test_ShowOkCancel()
    {
        Console.WriteLine("Test: ShowOkCancel");
        bool result = ShowOkCancel("Confirm Action", "Do you want to continue?",
            "This will apply the selected settings.");
        Console.WriteLine($"User clicked: {(result ? "OK" : "Cancel")}");
    }

    static void Test_ShowRetryCancel()
    {
        Console.WriteLine("Test: ShowRetryCancel");
        bool result = ShowRetryCancel("Connection Failed", "Unable to connect to server.",
            "Please check your network connection and try again.");
        Console.WriteLine($"User clicked: {(result ? "Retry" : "Cancel")}");
    }

    static void Test_ShowWithDontShowAgain()
    {
        Console.WriteLine("Test: ShowWithDontShowAgain");
        var result = ShowWithDontShowAgain("Tip", "Keyboard Shortcut",
            "You can press Ctrl+S to quickly save your work.");
        Console.WriteLine($"Dialog closed. Don't show again: {result.VerificationChecked}");
    }

    static void Test_ShowYesNoWithVerification()
    {
        Console.WriteLine("Test: ShowYesNoWithVerification");
        var result = ShowYesNoWithVerification("Confirm Reset", "Reset all settings to default?",
            "This will erase all your custom configurations.",
            verificationText: "Apply to all users");

        string buttonText = result.ButtonId == ButtonIds.Yes ? "Yes" : "No";
        Console.WriteLine($"User clicked: {buttonText}");
        Console.WriteLine($"Apply to all users: {result.VerificationChecked}");
    }

    static void Test_ShowCommandLinks()
    {
        Console.WriteLine("Test: ShowCommandLinks");

        var options = new List<CommandLinkOption>
        {
            new CommandLinkOption(100, "Express Installation", "Recommended settings for most users"),
            new CommandLinkOption(101, "Custom Installation", "Advanced options and customization"),
            new CommandLinkOption(102, "Repair", "Fix problems with existing installation")
        };

        int result = ShowCommandLinks("Setup Wizard", "Choose an installation option:", options,
            content: "Select how you would like to install the application.");

        string choice = result switch
        {
            100 => "Express Installation",
            101 => "Custom Installation",
            102 => "Repair",
            ButtonIds.Cancel => "Cancelled",
            _ => $"Unknown ({result})"
        };
        Console.WriteLine($"User selected: {choice}");
    }

    static void Test_ShowRadioSelection()
    {
        Console.WriteLine("Test: ShowRadioSelection");

        var options = new Dictionary<int, string>
        {
            { 1, "Small (640x480)" },
            { 2, "Medium (1280x720)" },
            { 3, "Large (1920x1080)" }
        };

        var result = ShowRadioSelection("Export Settings", "Select export resolution:", options,
            defaultRadioId: 2, content: "Choose the image resolution for export.");

        if (result.Accepted)
        {
            string selected = options[result.SelectedRadioId];
            Console.WriteLine($"User selected: {selected}");
        }
        else
        {
            Console.WriteLine("User cancelled.");
        }
    }

    static void Test_ShowErrorWithDetails()
    {
        Console.WriteLine("Test: ShowErrorWithDetails");

        string details = "Error Code: 0x80070005\n" +
                        "Source: FileSystem\n" +
                        "Target: C:\\Program Files\\MyApp\\data.dat\n\n" +
                        "Access is denied. The current user does not have write permissions " +
                        "to the target directory. Please run the application as administrator " +
                        "or change the file permissions.";

        ShowErrorWithDetails("File Error", "Access Denied",
            "Unable to write to the application data folder.",
            details);

        Console.WriteLine("Dialog closed.");
    }

    static void Test_ShowException()
    {
        Console.WriteLine("Test: ShowException");

        try
        {
            // Simulate an exception with inner exception
            try
            {
                throw new InvalidOperationException("Database connection failed");
            }
            catch (Exception inner)
            {
                throw new ApplicationException("Unable to load user settings", inner);
            }
        }
        catch (Exception ex)
        {
            ShowException("Application Error", ex, "An error occurred while loading your settings.");
        }

        Console.WriteLine("Dialog closed.");
    }

    static void Test_ShowInfoHyperlinks()
    {
        Console.WriteLine("Test: ShowInfo with Hyperlinks");
        string content = "For more information, visit the " +
                         "<a href=\"https://www.example.com/help\">Help Center</a> " +
                         "or contact <a href=\"mailto:support@example.com\">Support</a>.";

        ShowInfoWithHyperlinks("Information", "Main Instruction Here", content);   
    }
}

