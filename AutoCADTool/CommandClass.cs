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
using Autodesk.AutoCAD.Colors;

namespace AutoCADTool
{
    public class CommandClass
    {
        
      /*  public CommandClass()
        {
            autoCadDoc = Application.DocumentManager.MdiActiveDocument;
            if (autoCadDoc == null)
            {
                Polyline3d d;

                throw new NullReferenceException("Autocad can not be called");
            }
            db = autoCadDoc.Database;
            if (db == null)
            {
                Polyline3d d;
                throw new NullReferenceException("Autocad can not be called");
            }
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                const string outerLayerStr = "Aussene Kanten";
                if (!lt.Has(outerLayerStr))
                {
                    LayerTableRecord outerLayer = new LayerTableRecord();
                    outerLayer.Name = outerLayerStr;
                    lt.Add(outerLayer);
                    db.Clayer = lt[outerLayerStr];
                }
                const string innerLayerStr = "Innere Kanten";
                if (!lt.Has(innerLayerStr))
                {
                    LayerTableRecord innerLayer = new LayerTableRecord();
                    innerLayer.Name = innerLayerStr;
                    lt.Add(innerLayer);
                    db.Clayer = lt[innerLayerStr];
                }
                tr.Commit();
            }
        }*/

        //Testmethode. Ein bischen ausprobiert, wie die Kommanden funktionieren 
        [CommandMethod("TestComand")]
        public void RunCommand()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                // Document autoCadDoc = Application.DocumentManager.MdiActiveDocument;
                Document autoCadDoc = Application.DocumentManager.MdiActiveDocument;

                if (autoCadDoc == null)
                {
                    Polyline3d d;

                    throw new NullReferenceException("Autocad can not be called");
                }

                autoCadDoc = Application.DocumentManager.MdiActiveDocument;
                if (autoCadDoc == null)
                {
                    Polyline3d d;

                    throw new NullReferenceException("Autocad can not be called");
                }
                Database db = autoCadDoc.Database;
                if (db == null)
                {
                    Polyline3d d;
                    throw new NullReferenceException("Autocad can not be called");
                }
               
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

        //Testmethode. Ein bischen ausprobiert, wie die Kommanden funktionieren
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
                if (db == null)
                {
                    Polyline3d d;
                    throw new NullReferenceException("Autocad can not be called");
                }
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

        [CommandMethod("GetLayers")]
        public void ListLayers()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                Document autoCadDoc = Application.DocumentManager.MdiActiveDocument;

            //    autoCadDoc = Application.DocumentManager.MdiActiveDocument;
                if (autoCadDoc == null)
                {
                    Polyline3d d;

                    throw new NullReferenceException("Autocad can not be called");
                }
                Database db = autoCadDoc.Database;
                if (db == null)
                {
                    throw new NullReferenceException("Autocad can not be called");
                }
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    
                    if (!lt.Has(VertexTool.Vertex.OutherVertexSt))
                    {
                        lt.UpgradeOpen();
                        LayerTableRecord outerLayer = new LayerTableRecord();
                        outerLayer.Name = VertexTool.Vertex.OutherVertexSt;
                        outerLayer.Color = Color.FromColorIndex(ColorMethod.ByAci, VertexTool.Vertex.OutherColor);
                        lt.Add(outerLayer);
                        tr.AddNewlyCreatedDBObject(outerLayer, true);
                        db.Clayer = lt[VertexTool.Vertex.OutherVertexSt];
                    }
                    
                    if (!lt.Has(VertexTool.Vertex.InnerVertexSt))
                    {

                        lt.UpgradeOpen();
                        LayerTableRecord innerLayer = new LayerTableRecord();
                        innerLayer.Name = VertexTool.Vertex.InnerVertexSt;
                      
                        innerLayer.Color = Color.FromColorIndex(ColorMethod.ByAci, VertexTool.Vertex.InnereColor);
                        lt.Add(innerLayer);
                        tr.AddNewlyCreatedDBObject(innerLayer, true);
                        LinetypeTable ltt = tr.GetObject(db.LinetypeTableId, OpenMode.ForRead) as LinetypeTable;
                        
                        db.Clayer = lt[VertexTool.Vertex.InnerVertexSt];
                    }
                    tr.Commit();
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
            }
        }


        [CommandMethod("GetPolyline")]
        public void GetsPolyLine()
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
                List<Entity> polylines = new List<Entity>();
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
                                    ed.WriteMessage(s + "  TYPE");
                                    polylines.Add(entity);
                                }

                            }
                        }
                        VertexTool.Vertex.InnerPolyline(polylines);
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
