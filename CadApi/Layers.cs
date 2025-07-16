using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using CadExtension.LayerObjects;

namespace CadExtension.CadApi;

internal static class Layers
{
    internal static LayerStateCollection GetLayersState()
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Database database = document.Database;

        LayerStateCollection layers = new LayerStateCollection();

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            LayerTable layerTable = transaction.GetObject(database.LayerTableId, OpenMode.ForRead) as LayerTable;
            foreach (ObjectId layerId in layerTable)
            {
                LayerTableRecord layerRecord = transaction.GetObject(layerId, OpenMode.ForRead) as LayerTableRecord;
                layers.LayerStates.Add(new LayerState(layerRecord.Name, layerRecord.IsOff == false));
            }

            transaction.Commit();
        }

        return layers;
    }

    internal static void UpdateLayersState(LayerStateCollection layers)
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Database database = document.Database;

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            //get layers
            LayerTable layerTable = transaction.GetObject(database.LayerTableId, OpenMode.ForRead) as LayerTable;
            if (layerTable == null)
            {
                transaction.Commit();
                return;
            }

            //turn all off
            foreach (var objectId in layerTable)
            {
                var layerTableRecord = transaction.GetObject(objectId, OpenMode.ForWrite) as LayerTableRecord;
                if (layerTableRecord == null) continue;

                layerTableRecord.IsOff = true;
            }

            //turn some on
            foreach (var objectId in layerTable)
            {
                var layerTableRecord = transaction.GetObject(objectId, OpenMode.ForWrite) as LayerTableRecord;
                if (layerTableRecord == null) continue;
                
                foreach(var layer in layers.LayerStates)
                {
                    if (layer.LayerName == layerTableRecord.Name && layer.IsOn == true)
                    {
                        layerTableRecord.IsOff = false;
                    }
                }
            }

            transaction.Commit();
        }
    }
}