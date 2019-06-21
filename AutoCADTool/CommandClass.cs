using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using SortTool;
using GCodeTool;
using System.Reflection;

namespace AutoCADTool
{

    public class CommandClass : IExtensionApplication
    {
        Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
        Document autoCadDoc = Application.DocumentManager.MdiActiveDocument;
        public void ListLayers()
        {
           
            try
            {
                if (autoCadDoc == null)
                {
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

                    if (!lt.Has(EdgeTool.Edge.OutherVertexSt))
                    {
                        lt.UpgradeOpen();
                        LayerTableRecord outerLayer = new LayerTableRecord();
                        outerLayer.Name = EdgeTool.Edge.OutherVertexSt;
                        outerLayer.Color = Color.FromColorIndex(ColorMethod.ByAci, EdgeTool.Edge.OutherColor);
                        lt.Add(outerLayer);
                        tr.AddNewlyCreatedDBObject(outerLayer, true);
                        db.Clayer = lt[EdgeTool.Edge.OutherVertexSt];
                    }

                    if (!lt.Has(EdgeTool.Edge.InnerVertexSt))
                    {

                        lt.UpgradeOpen();
                        LayerTableRecord innerLayer = new LayerTableRecord();
                        innerLayer.Name = EdgeTool.Edge.InnerVertexSt;

                        innerLayer.Color = Color.FromColorIndex(ColorMethod.ByAci, EdgeTool.Edge.InnereColor);
                        lt.Add(innerLayer);
                        tr.AddNewlyCreatedDBObject(innerLayer, true);
                        LinetypeTable ltt = tr.GetObject(db.LinetypeTableId, OpenMode.ForRead) as LinetypeTable;

                        db.Clayer = lt[EdgeTool.Edge.InnerVertexSt];
                    }
                    tr.Commit();
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
            }
        }


        [CommandMethod("GCode")]
        public void GetsPolyLine()
        {
            try
            {
              
                if (autoCadDoc == null)
                {
                    throw new NullReferenceException("Autocad can not be called");
                }

                Database db = autoCadDoc.Database;
                List<CurveInfo> allEntities = new List<CurveInfo>();
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

                                Hatch hatch = t.GetObject(item.ObjectId, OpenMode.ForWrite) as Hatch;
                                if (hatch == null)
                                {
                                    continue;
                                }
                                for (int loopIndex = 0; loopIndex < hatch.NumberOfLoops; loopIndex++)
                                {
                                    var loopInfo = hatch.GetLoopAt(loopIndex);
                                    if (!loopInfo.LoopType.HasFlag(HatchLoopTypes.External) && !loopInfo.LoopType.HasFlag(HatchLoopTypes.Outermost))
                                    {
                                        continue;
                                    }
                                    var isOuter = loopInfo.LoopType.HasFlag(HatchLoopTypes.External);
                                    foreach (var objID in hatch.GetAssociatedObjectIdsAt(loopIndex))
                                    {
                                        if (!(objID is ObjectId))
                                        {
                                            continue;
                                        }
                                        var ent = t.GetObject(((ObjectId)objID), OpenMode.ForWrite) as Curve;
                                        var entInfo = new CurveInfo(ent, isOuter);
                                        allEntities.Add(entInfo);
                                    }
                                }
                            }
                        }
                    }
                    t.Commit();
                }
                List<CurveInfo> sortedEntities = EntityOrder.GetOrderedEntities(allEntities);
                string code = CommandManager.Gcode(sortedEntities);
             
                Form1 f = new Form1();
                f.SetTextGCode(code);
                f.Show();
                code = "";
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
            }

        }

        public void Initialize()
        {
            ListLayers();

        }

        public void Terminate()
        {
            
        }


       
    }
}