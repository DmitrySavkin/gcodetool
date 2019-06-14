using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexTool
{

    public class Vertex
    {
        public static short InnereColor = 4; 
        public static short OutherColor = 2;
        public static string InnerVertexSt = "Innere Kanten";
        public static string OutherVertexSt = "Aussere Kanten";
        // public enum PolygonSelectionMode { Crossing, Window }

        public static List<Entity> InnerPolyline(List<Entity> polylines)
        {
            const string polyline = "Polyline";//Um  die Tippfehler beim switch zu vermeiden,
                                               //würde  ich vorschlagen
                                               //eine Variable einzuführen
            const string circle = "Circle";
            const string hatch = "Hatch";
            int id = 0;
            List<Entity> innerEntities = new List<Entity>();
            foreach (Entity e in polylines)
            {
               if (e.Layer.Equals(Vertex.InnerVertexSt))
                {
                    innerEntities.Add(e);
                }
            }
            /*
            switch (s)
            {

                case polyline:

                    ed.WriteMessage(s + "YEAP");
                    Polyline p = (Polyline)entity;
                    //Polyline2d p2 = (Polyline2d)entity;//Fehler
                    //PolylineCurve2d p3 = entity;//Fehler
                    //  PromptSelectionResult ps = ed.SelectByPolyline(p, PolygonSelectionMode.Window, new TypedValue(0, "INSERT"));
                    Console.WriteLine(p);
                    polylines.Add(p);
                    break;
                case circle:
                    break;
                case hatch:
                    Hatch h = (Hatch)entity;
                    break;
            } 
            */
            return innerEntities;
        }

        public static List<Entity> OuterPolyline(List<Entity> polylines)
        {
            const string polyline = "Polyline";//Um  die Tippfehler beim switch zu vermeiden,
                                               //würde  ich vorschlagen
                                               //eine Variable einzuführen
            const string circle = "Circle";
            const string hatch = "Hatch";
            int id = 0;
            List<Entity> outerEntities = new List<Entity>();
            foreach (Entity e in polylines)
            {
                if (e.Layer.Equals(Vertex.InnerVertexSt))
                {
                    outerEntities.Add(e);
                }
            }
            /*
            switch (s)
            {

                case polyline:

                    ed.WriteMessage(s + "YEAP");
                    Polyline p = (Polyline)entity;
                    //Polyline2d p2 = (Polyline2d)entity;//Fehler
                    //PolylineCurve2d p3 = entity;//Fehler
                    //  PromptSelectionResult ps = ed.SelectByPolyline(p, PolygonSelectionMode.Window, new TypedValue(0, "INSERT"));
                    Console.WriteLine(p);
                    polylines.Add(p);
                    break;
                case circle:
                    break;
                case hatch:
                    Hatch h = (Hatch)entity;
                    break;
            } 
            */
            return outerEntities;
        }
        /*
        public static PromptSelectionResult SelectByPolyline(this Editor ed, Polyline pline, PolygonSelectionMode mode, params TypedValue[] filter)
        {
            if (ed == null) throw new ArgumentNullException("ed");
            if (pline == null) throw new ArgumentNullException("pline");
            Matrix3d wcs = ed.CurrentUserCoordinateSystem.Inverse();
            Point3dCollection polygon = new Point3dCollection();
            for (int i = 0; i < pline.NumberOfVertices; i++)
            {
                polygon.Add(pline.GetPoint3dAt(i).TransformBy(wcs));
            }
            PromptSelectionResult result;
            using (ViewTableRecord curView = ed.GetCurrentView())
            {
                ed.Zoom(pline.GeometricExtents);
                if (mode == PolygonSelectionMode.Crossing)
                    result = ed.SelectCrossingPolygon(polygon, new SelectionFilter(filter));
                else
                    result = ed.SelectWindowPolygon(polygon, new SelectionFilter(filter));
                ed.SetCurrentView(curView);
            }
            return result;
        }

        public static void Zoom(this Editor ed, Extents3d extents)
        {
            if (ed == null) throw new ArgumentNullException("ed");
            using (ViewTableRecord view = ed.GetCurrentView())
            {
                Matrix3d worldToEye =
                    (Matrix3d.Rotation(-view.ViewTwist, view.ViewDirection, view.Target) *
                    Matrix3d.Displacement(view.Target - Point3d.Origin) *
                    Matrix3d.PlaneToWorld(view.ViewDirection))
                    .Inverse();
                extents.TransformBy(worldToEye);
                view.Width = extents.MaxPoint.X - extents.MinPoint.X;
                view.Height = extents.MaxPoint.Y - extents.MinPoint.Y;
                view.CenterPoint = new Point2d(
                    (extents.MaxPoint.X + extents.MinPoint.X) / 2.0,
                    (extents.MaxPoint.Y + extents.MinPoint.Y) / 2.0);
                ed.SetCurrentView(view);
            }
        }
        */
    }
}
