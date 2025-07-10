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
}