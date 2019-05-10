using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace AutoCADTool
{
    public class CommandClass
    {
        [CommandMethod("TestComand")]
        public void RunCommand()
        {
            Document autoCadDoc = Application.DocumentManager.MdiActiveDocument;
            if (autoCadDoc == null)
            {
                throw new NullReferenceException("Autocad can not be called");
            }
            Database db = autoCadDoc.Database;
            ObjectId layerTableId = db.LayerTableId;
            List<string> layer = new List<string>();
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                LayerTable  layerTable = tr.GetObject(layerTableId, OpenMode.ForRead) as LayerTable;
                foreach (ObjectId layerRecordId in layerTable)
                {
                    LayerTableRecord layerTableRecord = tr.GetObject(layerRecordId, OpenMode.ForRead) as LayerTableRecord;
                    layer.Add(layerTableRecord.Name);
                }
                tr.Commit();
            }

            Editor ed = autoCadDoc.Editor;
            foreach (string layerName in layer)
            {
                ed.WriteMessage($"\n{layerName}");
            }

        }
    }
}
