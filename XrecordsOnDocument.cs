using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace CadExtension;

internal class XrecordsOnDocument
{
    internal void WriteStringToXrecord(string key, string json)
    {
        Document document = Application.DocumentManager.MdiActiveDocument;
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
        Document document = Application.DocumentManager.MdiActiveDocument;
        Database database = document.Database;

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            DBDictionary nod = transaction.GetObject(database.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;

            if (!nod.Contains(key))
                return null;

            Xrecord xrecord = transaction.GetObject(nod.GetAt(key), OpenMode.ForRead) as Xrecord;
            ResultBuffer buffer = xrecord.Data;

            if (buffer == null)
                return null;

            TypedValue[] values = buffer.AsArray();
            return values.Length > 0 ? values[0].Value.ToString() : null;
        }
    }
}