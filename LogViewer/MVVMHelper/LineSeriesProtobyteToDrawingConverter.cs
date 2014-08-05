using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using LogViewer.Model;
using System.Globalization;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class register event of graph in CXDI log
    /// </summary>
    class LineSeriesProtobyteToDrawingConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        private static Geometry _circleGeometry;
        private static Geometry _squareGeometry;
        private static Geometry _starGeometry;
        private static Geometry _triangleGeometry;

        static LineSeriesProtobyteToDrawingConverter()
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

            _drawingDict = new Dictionary<string,GeometryDrawing>();


        }
        private static Dictionary<string, GeometryDrawing> _drawingDict;
        private static GeometryDrawing CreateGeometryDrawing(Geometry geometry, Color color)
        {
            string key = String.Format("{0}{1}",geometry.GetHashCode(),color.ToString());
            if (!_drawingDict.ContainsKey(key))
            {
                GeometryDrawing drawing = new GeometryDrawing();
                drawing.Pen = new Pen(new SolidColorBrush(Colors.Black), 2);
                drawing.Pen.DashStyle = DashStyles.Solid;
                drawing.Brush = new SolidColorBrush(color);
                drawing.Geometry = geometry;
                _drawingDict.Add(key, drawing);
            }
            return _drawingDict[key];
        }
        /// <summary>
        /// Convert Prototype to CreateGeometryDrawing
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>CreateGeometryDrawing value</returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values == null || values.Count() != 2)
                return DependencyProperty.UnsetValue;
            if (values.ElementAt(0) == DependencyProperty.UnsetValue)
                return DependencyProperty.UnsetValue;
            var protobyte = (Prototype)values.ElementAt(0);

            var colorCode = values.ElementAt(1) as string;
            if (String.IsNullOrEmpty(colorCode))
            {
                ProtobyteToDrawingConverter normalProtobyteConv = new ProtobyteToDrawingConverter();
                return normalProtobyteConv.Convert(protobyte, targetType, parameter, culture);
            }
            switch (protobyte)
            {
                case Prototype.BlackCircle:
                case Prototype.WhiteCircle:
                    {
                        return CreateGeometryDrawing(_circleGeometry, (Color)ColorConverter.ConvertFromString(colorCode));
                    }
                case Prototype.BlackSquare:
                case Prototype.WhiteSquare:
                    {
                        return CreateGeometryDrawing(_squareGeometry, (Color)ColorConverter.ConvertFromString(colorCode));
                    }
                case Prototype.BlackStar:
                case Prototype.WhiteStar:
                    {
                        return CreateGeometryDrawing(_starGeometry, (Color)ColorConverter.ConvertFromString(colorCode));
                    }
                case Prototype.BlackTriangle:
                case Prototype.WhiteTriangle:
                    {
                        return CreateGeometryDrawing(_triangleGeometry, (Color)ColorConverter.ConvertFromString(colorCode));
                    }
            }
            throw new NotSupportedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
