using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;

namespace CadExtension.LayerObjects;

internal class LayersInfo : List<LayerInfo>
{
    internal void GetLayersState()
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Database database = document.Database;

        List<LayerInfo> layers = new List<LayerInfo>();

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            LayerTable layerTable = transaction.GetObject(database.LayerTableId, OpenMode.ForRead) as LayerTable;
            foreach (ObjectId layerId in layerTable)
            {
                LayerTableRecord layerRecord = transaction.GetObject(layerId, OpenMode.ForRead) as LayerTableRecord;
                Add(new LayerInfo(layerRecord.Name, layerRecord.IsOff == false));
            }

            transaction.Commit();
        }
    }

    internal void UpdateLayersState()
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Database database = document.Database;

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            LayerTable layerTable = transaction.GetObject(database.LayerTableId, OpenMode.ForRead) as LayerTable;

            foreach (LayerInfo info in this)
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