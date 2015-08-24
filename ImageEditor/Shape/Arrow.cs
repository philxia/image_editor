using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Media.Imaging.Shapes;

namespace ImageEditor.Shape
{
   public class Arrow : IShape
   {
      public string DisplayName
      {
         get { return "Arrow"; }
      }

      public System.Windows.Media.Geometry GetShapeGeometry()
      {
         PathFigure outer = new PathFigure();
         outer.IsClosed = true;
         outer.StartPoint = new Point(0, 0);
         outer.Segments.Add(new LineSegment() { Point = new Point(0.82, 0.78) });
         outer.Segments.Add(new LineSegment() { Point = new Point(0.8, 0.64) });
         outer.Segments.Add(new LineSegment() { Point = new Point(1, 1) });
         outer.Segments.Add(new LineSegment() { Point = new Point(0.64, 0.8) });
         outer.Segments.Add(new LineSegment() { Point = new Point(0.78, 0.82) });
         outer.Segments.Add(new LineSegment() { Point = new Point(0, 0) });

         
         PathGeometry logoGeometry = new PathGeometry();
         logoGeometry.Figures.Add(outer);

         return logoGeometry;

      }
   }
}
