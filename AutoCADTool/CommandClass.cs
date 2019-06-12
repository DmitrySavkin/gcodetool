﻿using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using SortTool;

namespace AutoCADTool
{
    public class EntityInfo
    {
        private Entity entity;
        private bool done;

        public EntityInfo(Entity entity)
        {
            this.entity = entity;
            this.done = false;
        }

        public bool Done
        {
            set
            {
                Hatch h;
                this.done = value;
            }
            get
            {
                return this.done;

            }
        }

        public Entity Entity
        {
            set
            {

                this.entity = value;

            }
            get
            {
                return this.entity;

            }
        }
    }

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
                List<EntityInfo> allEntities = new List<EntityInfo>();
                using (Transaction t = db.TransactionManager.StartTransaction())
                {
                    PromptSelectionResult sPrompt = ed.SelectImplied();
                    if (sPrompt.Status != PromptStatus.OK)
                    {
                        sPrompt = ed.GetSelection();
                    }
                    if (sPrompt.Status == PromptStatus.OK)
                    {
                        bool test = false;
                        foreach (SelectedObject item in sPrompt.Value)
                        {
                            if (item != null)
                            {
                                Entity entity = t.GetObject(item.ObjectId, OpenMode.ForWrite) as Entity;
                                if (entity != null)
                                {
                                    string entName = entity.GetType().Name;
                                    if (entName == "Polyline" || entName == "Circle")
                                    {
                                        allEntities.Add(new EntityInfo(entity));
                                    }
                                    if (entName == "Polyline")
                                    {
                                        Polyline p3 = (Polyline)entity;
                                        Point2d p = new Point2d(2226, 1633);
                                       // test = IsInsideThePolygon(p3, p);
                                    }
                                    ed.WriteMessage("Type: " + entName);
                                    //polylines.Add(entity);
                                }

                            }
                        }
                        //VertexTool.Vertex.InnerPolyline(polylines);
                    }

                    genOrderedEntities(allEntities);
                    t.Commit();
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
            }

        }
        // private void Ordered(List<E>)
        private void genOrderedEntities(List<EntityInfo> allEntities)
        {
            List<EntityInfo> resEntities = new List<EntityInfo>();
            bool wasProcessed;
            do
            {

                wasProcessed = false;
                for (int i = 0; i < allEntities.Count; i++)
                {
                    EntityInfo curEntity = allEntities[i];
                    if (curEntity.Done) continue;
                    bool hasInternals = false;
                    for (int j = 0; j < allEntities.Count; j++)
                    {
                        EntityInfo compEntity = allEntities[j];
                        if (curEntity == compEntity || compEntity.Done) continue;
                        if (EntityOrder.isInside(compEntity.Entity, curEntity.Entity))
                        {
                            hasInternals = true;
                        }
                    }
                    if (!hasInternals)
                    {
                        resEntities.Add(curEntity);
                        wasProcessed = true;
                        curEntity.Done = true;
                    }
                }
            } while (wasProcessed);
            for (int i = 0; i < resEntities.Count; i++)
            {
                Entity curEntity = resEntities[i].Entity;
                Polyline p = curEntity as Polyline;
                if (p == null) continue;
                if (p.StartPoint != p.EndPoint)
                {
                    Console.WriteLine("Bad figure here");
                    
                }
            }
            int iii = 2;
        }

      


    

        /*
        public static bool IsInsideThePolygon(Polyline p, Point2d pt)
        {
            double angles = 0;
            for (int i = 0; i < p.NumberOfVertices; i++)
            {

                angles += Convert.ToDouble(pt.GetVectorTo(p.GetPoint2dAt(i)).Angle.ToString());

            }
            angles = Math.Abs(angles / (2.0 * Math.PI));
            return angles > 0.5;
        }
        
        public static bool IsInsideThePolygon2(Polyline p, Point2d pt)
        {
            Point2d[] points = new Point2d[p.NumberOfVertices];
            for (int i = 0; i < p.NumberOfVertices; i++)
            {
                Point2d p2 = p.GetPoint2dAt(i);
                points[i] = p2;

            }
            bool res = false;
            int j = points.Length - 1;
           for (int i = 0; i < points.Length; i++)
            {
                if (points[i].Y < pt.Y && points[j].Y >= pt.Y || points[j].Y < pt.Y && points[i].Y >= pt.Y)
                {
                    if (points[i].X + (pt.Y - points[i].Y) / (points[j].Y - points[i].Y) * (points[j].X - points[i].X) < pt.X)
                    {
                        res = !res;
                    }
                }
                j = i;
            }
            return res;
        }*/
    }
}