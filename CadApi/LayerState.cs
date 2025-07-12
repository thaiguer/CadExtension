using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using CadExtension.LayerObjects;

namespace CadExtension.CadApi;

internal static class LayerState
{
    internal static List<LayerObjects.LayerState> GetLayersState()
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Database database = document.Database;

        List<LayerObjects.LayerState> layers = new List<LayerObjects.LayerState>();

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            LayerTable layerTable = transaction.GetObject(database.LayerTableId, OpenMode.ForRead) as LayerTable;
            foreach (ObjectId layerId in layerTable)
            {
                LayerTableRecord layerRecord = transaction.GetObject(layerId, OpenMode.ForRead) as LayerTableRecord;
                layers.Add(new LayerObjects.LayerState(layerRecord.Name, layerRecord.IsOff == false));
            }

            transaction.Commit();
        }

        return layers;
    }

    internal static void UpdateLayersState(List<LayerObjects.LayerState> layers)
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Database database = document.Database;

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            LayerTable layerTable = transaction.GetObject(database.LayerTableId, OpenMode.ForRead) as LayerTable;

            foreach (LayerObjects.LayerState info in layers)
            {
                if (layerTable.Has(info.LayerName))
                {
                    LayerTableRecord layerRecord = transaction.GetObject(layerTable[info.LayerName], OpenMode.ForWrite) as LayerTableRecord;
                    layerRecord.IsOff = !info.IsOn;
                }
            }

            transaction.Commit();
        }
    }
}