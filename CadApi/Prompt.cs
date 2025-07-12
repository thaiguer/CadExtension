using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;

namespace CadExtension.CadApi;

internal static class Prompt
{
    internal static void Write(string message)
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Editor editor = document.Editor;
        editor.WriteMessage($"{message}");
    }

    internal static void WriteLine(string message)
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Editor editor = document.Editor;
        editor.WriteMessage($"{Environment.NewLine}{message}");
    }

    internal static void WriteNewLine(string message)
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Editor editor = document.Editor;
        editor.WriteMessage($"{Environment.NewLine}");
        editor.WriteMessage($"{Environment.NewLine}{message}");
    }

    internal static string AskUserForString(string message)
    {
        Document document = Application.DocumentManager.MdiActiveDocument;
        Editor editor = document.Editor;

        PromptStringOptions options = new PromptStringOptions($"{Environment.NewLine}{message}");
        options.AllowSpaces = false;
        options.DefaultValue = string.Empty;

        PromptResult result = editor.GetString(options);

        if (result.Status == PromptStatus.OK)
        {
            return result.StringResult;
        }

        return string.Empty;
    }

    internal static int AskUserForInt(string message)
    {
        Document document = Application.DocumentManager.MdiActiveDocument;
        Editor editor = document.Editor;

        PromptIntegerOptions options = new PromptIntegerOptions($"{Environment.NewLine}{message}")
        {
            AllowZero = false,
            AllowNegative = false,
            DefaultValue = 1
        };

        PromptIntegerResult result = editor.GetInteger(options);

        if (result.Status == PromptStatus.OK)
        {
            return result.Value;
        }

        return -1;
    }
}