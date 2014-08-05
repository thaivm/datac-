using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using LogViewer.Model;
using System.Windows.Media;
using System.Windows;
using System.Globalization;


namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class register parameter of graph in CXDI log
    /// </summary>
    public class ProtobyteToDrawingConverter : IValueConverter
    {
        #region IValueConverter Members

        private static Geometry _circleGeometry;
        private static Geometry _squareGeometry;
        private static Geometry _starGeometry;
        private static Geometry _triangleGeometry;

        private static GeometryDrawing _blackCircle;
        private static GeometryDrawing _blackSquare;
        private static GeometryDrawing _blackStar;
        private static GeometryDrawing _blackTriangle;
        private static GeometryDrawing _whiteCircle;
        private static GeometryDrawing _whiteSquare;
        private static GeometryDrawing _whiteStar;
        private static GeometryDrawing _whiteTriangle;

        static ProtobyteToDrawingConverter()
        {
            // SET UP GEOMETRY
            _circleGeometry = new EllipseGeometry(new Point(23, 0), 23, 23);
            _squareGeometry = new RectangleGeometry(new Rect(new Point(156, 155), new Point(205, 201)));
            //star
            UniversalValueConverter conv = new UniversalValueConverter();
            PathGeometry starPathGeo = new PathGeometry();
            string starPathFigs = "M 156,171 L 174,171 L 180,155 L 186,171 L 204,171 L 190,182 L 195,199 L 180,189 L 165,199 L 170,182 Z";
            starPathGeo.Figures = (PathFigureCollection)conv.Convert(starPathFigs, starPathGeo.Figures.GetType(), null, CultureInfo.InvariantCulture);
            _starGeometry = starPathGeo;
            //triangle
            PathGeometry trianglePathGeo = new PathGeometry();
            string trianglePathFigs = "M 156,196 L 180,155 L 204,196 Z";
            trianglePathGeo.Figures = (PathFigureCollection)conv.Convert(trianglePathFigs, trianglePathGeo.Figures.GetType(), null, CultureInfo.InvariantCulture);
            _triangleGeometry = trianglePathGeo;
            //---DONE---

            //SET UP GEOMETRY DRAWING
            CreateGeometryDrawing(out _blackCircle, _circleGeometry, Colors.Black);
            CreateGeometryDrawing(out _blackSquare, _squareGeometry, Colors.Black);
            CreateGeometryDrawing(out _blackStar, _starGeometry, Colors.Black);
            CreateGeometryDrawing(out _blackTriangle, _triangleGeometry, Colors.Black);
            CreateGeometryDrawing(out _whiteCircle, _circleGeometry, Colors.White);
            CreateGeometryDrawing(out _whiteSquare, _squareGeometry, Colors.White);
            CreateGeometryDrawing(out _whiteStar, _starGeometry, Colors.White);
            CreateGeometryDrawing(out _whiteTriangle, _triangleGeometry, Colors.White);
            //---DONE---


        }

        private static void CreateGeometryDrawing(out GeometryDrawing drawing, Geometry geometry, Color color)
        {
            drawing = new GeometryDrawing();
            drawing.Pen = new Pen(new SolidColorBrush(Colors.Black), 2);
            drawing.Pen.DashStyle = DashStyles.Solid;
            drawing.Brush = new SolidColorBrush(color);
            drawing.Geometry = geometry;
        }
        /// <summary>
        /// Convert to prototype
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Return a boolean value</returns>
        /// <returns>Prototype enum</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var protobyte = (Prototype)value;
            switch (protobyte)
            {
                case Prototype.BlackCircle:
                    {
                        return _blackCircle;
                    }
                case Prototype.BlackSquare:
                    {
                        return _blackSquare;
                    }
                case Prototype.BlackStar:
                    {
                        return _blackStar;
                    }
                case Prototype.BlackTriangle:
                    {
                        return _blackTriangle;
                    }
                case Prototype.WhiteCircle:
                    {
                        return _whiteCircle;
                    }
                case Prototype.WhiteSquare:
                    {
                        return _whiteSquare;
                    }
                case Prototype.WhiteStar:
                    {
                        return _whiteStar;
                    }
                case Prototype.WhiteTriangle:
                    {
                        return _whiteTriangle;
                    }
            }
            throw new NotSupportedException();
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
