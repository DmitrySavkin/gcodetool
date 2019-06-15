using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    public class PolylineCommand : ITask
    {
        public Polyline Polyline { get; }

        public Point2d BasePoint
        {
            get;
        }


        public PolylineCommand(Point2d basePoint, Polyline p)
        {
            if (basePoint == null)
            {
                throw new NullReferenceException("The basePoint is null");
            }

            if (p == null)
            {
                throw new NullReferenceException("The polyline is null");
            }
            this.BasePoint = basePoint;
            this.Polyline = p;
        }

        private Point2d GetRealPoint(Point2d p)
        {
            if (p == null)
            {
                throw new NullReferenceException("The point is null");
            }
            return new Point2d(p.X - BasePoint.X, p.Y - BasePoint.Y);
        }
        public Command Run()
        {
            Command c = new Command();
            c.Position(GetRealPoint(Polyline.GetPoint2dAt(0)));

            c.RotationOn();
            c.Down();
            c.CoolingOn();
            for (int i = 1; i < Polyline.NumberOfVertices; i++)
            {
                c.Move(GetRealPoint(Polyline.GetPoint2dAt(i)));
            }
            c.Up();
            c.RotationOff();
            c.CoolingOff();

            return c;
        }
    }
}
