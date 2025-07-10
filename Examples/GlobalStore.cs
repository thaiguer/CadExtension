using Autodesk.AutoCAD.Runtime;
using CadExtension.CadApi;

namespace CadExtension.Examples;

public class Class1
{
    [CommandMethod("Test123Write")]
    public void WriteTest()
    {
        var xHandler = new XrecordsOnDocument();
        xHandler.WriteStringToXrecord("MyThing", "aaaSecretaaa");
    }

    [CommandMethod("Test123Read")]
    public void ReadTest()
    {
        var xHandler = new XrecordsOnDocument();
        var result = xHandler.ReadStringFromXrecord("MyThing");

        Prompt.WriteNewLine(result);
    }
}