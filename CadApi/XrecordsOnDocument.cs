using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace CadExtension.CadApi;

internal class XrecordsOnDocument
{
    internal void WriteStringToXrecord(string key, string json)
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Database database = document.Database;

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            DBDictionary nod = transaction.GetObject(database.NamedObjectsDictionaryId, OpenMode.ForWrite) as DBDictionary;

            // Remove existing entry if needed
            if (nod.Contains(key))
            {
                nod.Remove(key);
            }

            Xrecord xrecord = new Xrecord();
            xrecord.Data = new ResultBuffer(new TypedValue((int)DxfCode.Text, json));

            nod.SetAt(key, xrecord);
            transaction.AddNewlyCreatedDBObject(xrecord, true);

            transaction.Commit();
        }
    }

    internal string ReadStringFromXrecord(string key)
    {
        Document document = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
        Database database = document.Database;

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            DBDictionary nod = transaction.GetObject(database.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
            if (nod == null) return string.Empty;

            if (!nod.Contains(key))
                return string.Empty;

            Xrecord xrecord = transaction.GetObject(nod.GetAt(key), OpenMode.ForRead) as Xrecord;
            if (xrecord == null) return string.Empty;

            ResultBuffer buffer = xrecord.Data;

            if (buffer == null)
                return string.Empty;

            TypedValue[] values = buffer.AsArray();
            return values.Length > 0 ? values[0].Value.ToString() : null;
        }
    }
}