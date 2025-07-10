using Autodesk.AutoCAD.Runtime;

namespace CadExtension;

public class Initialization : IExtensionApplication
{
    public void Initialize()
    {
        CadApi.Prompt.WriteNewLine("Cad Extension Dll loaded. It's alive!");
    }

    public void Terminate()
    {

    }
}