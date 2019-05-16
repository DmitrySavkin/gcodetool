using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace AutoCADTool
{
    public class CommandClass
    {
        [CommandMethod("TestComand")]
        public void RunCommand()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                Document autoCadDoc = Application.DocumentManager.MdiActiveDocument;

                if (autoCadDoc == null)
                {
                    Polyline3d d;

                    throw new NullReferenceException("Autocad can not be called");
                }

                Database db = autoCadDoc.Database;
                Transaction t = db.TransactionManager.StartTransaction();
                BlockTable bt = t.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                BlockTableRecord btr = t.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                PromptPointOptions pOpt = new PromptPointOptions("Specify circle center");
                PromptPointResult pPntResult = ed.GetPoint(pOpt);
                if (pPntResult.Status == PromptStatus.OK)
                {
                    Circle c = new Circle();
                    c.Radius = 5;
                    Point3d p3d = pPntResult.Value;
                    c.Center = p3d;
                    btr.AppendEntity(c);
                    t.AddNewlyCreatedDBObject(c, true);
                }
                t.Commit();
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
            }

        }

        [CommandMethod("TestColor")]
        public void ChangeColor()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                Document autoCadDoc = Application.DocumentManager.MdiActiveDocument;

                if (autoCadDoc == null)
                {
                    Polyline3d d;

                    throw new NullReferenceException("Autocad can not be called");
                }

                Database db = autoCadDoc.Database;
                using (Transaction t = db.TransactionManager.StartTransaction())
                {
                    PromptSelectionResult psr = ed.GetSelection();
                    if (psr.Status == PromptStatus.OK)
                    {
                        foreach (SelectedObject item in psr.Value)
                        {
                            if (item != null)
                            {
                                Entity entity = t.GetObject(item.ObjectId, OpenMode.ForWrite) as Entity;
                                if (entity != null)
                                {
                                    entity.ColorIndex = 4;
                                }
                            }
                        }

                    }
                    t.Commit();
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
            }
        }

        [CommandMethod("TestLayers")]
        public void ListLayers()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                Document autoCadDoc = Application.DocumentManager.MdiActiveDocument;

                if (autoCadDoc == null)
                {
                    Polyline3d d;

                    throw new NullReferenceException("Autocad can not be called");
                }

                Database db = autoCadDoc.Database;
                using (Transaction t = db.TransactionManager.StartTransaction())
                {
                    LayerTable lt = t.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    foreach (var layerID in lt)
                    {
                        LayerTableRecord ltr = t.GetObject(layerID, OpenMode.ForRead) as LayerTableRecord;
                        ed.WriteMessage(ltr.Name + System.Environment.NewLine);
                    }
                 //   t.Commit();
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
            }
        }


        [CommandMethod("GetPolyline")]
        public void GetsPolyLine() {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                Document autoCadDoc = Application.DocumentManager.MdiActiveDocument;

                if (autoCadDoc == null)
                {
                    Polyline3d d;

                    throw new NullReferenceException("Autocad can not be called");
                }

                Database db = autoCadDoc.Database;
                using (Transaction t = db.TransactionManager.StartTransaction())
                {
                    PromptSelectionResult sPrompt = ed.SelectImplied();
                    if (sPrompt.Status != PromptStatus.OK)
                    {
                        sPrompt = ed.GetSelection();
                    }
                    if (sPrompt.Status == PromptStatus.OK)
                    {
                        foreach (SelectedObject item in sPrompt.Value)
                        {
                            if (item != null)
                            {
                                Entity entity = t.GetObject(item.ObjectId, OpenMode.ForWrite) as Entity;
                                if (entity != null)
                                {
                                    string s = entity.GetType().Name;
                                    ed.WriteMessage(s);
                                }
                            }
                        }
                    }
                      t.Commit();
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
            }

        }
    }
}
