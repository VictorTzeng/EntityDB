using System.Windows;
using System.Windows.Media;

namespace WPFArrows.Arrows
{
    /// <summary>
    /// 带箭头的贝塞尔曲线
    /// </summary>
    public class ArrowBezierCurve : ArrowBase
    {
        #region Fields

        /// <summary>
        /// 贝塞尔曲线
        /// </summary>
        private readonly BezierSegment _bezierSegment = new BezierSegment();

        #endregion Fields

        #region Properties

        /// <summary>
        /// 控制点1
        /// </summary>
        public static readonly DependencyProperty ControlPoint1Property = DependencyProperty.Register(
            "ControlPoint1", typeof(Point), typeof(ArrowBezierCurve), new FrameworkPropertyMetadata(new Point(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// 控制点1
        /// </summary>
        public Point ControlPoint1
        {
            get { return (Point)GetValue(ControlPoint1Property); }
            set { SetValue(ControlPoint1Property, value); }
        }

        /// <summary>
        /// 控制点2
        /// </summary>
        public static readonly DependencyProperty ControlPoint2Property = DependencyProperty.Register(
            "ControlPoint2", typeof(Point), typeof(ArrowBezierCurve), new FrameworkPropertyMetadata(new Point(), FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// 控制点2
        /// </summary>
        public Point ControlPoint2
        {
            get { return (Point)GetValue(ControlPoint2Property); }
            set { SetValue(ControlPoint2Property, value); }
        }

        /// <summary>
        /// 结束点
        /// </summary>
        public static readonly DependencyProperty EndPointProperty = DependencyProperty.Register(
            "EndPoint", typeof(Point), typeof(ArrowBezierCurve), new FrameworkPropertyMetadata(new Point(), FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// 结束点
        /// </summary>
        public Point EndPoint
        {
            get { return (Point)GetValue(EndPointProperty); }
            set { SetValue(EndPointProperty, value); }
        }

        #endregion Properties

        #region Protected Methods

        /// <summary>
        /// 填充Figure
        /// </summary>
        protected override PathSegmentCollection FillFigure()
        {
            _bezierSegment.Point1 = ControlPoint1;
            _bezierSegment.Point2 = ControlPoint2;
            _bezierSegment.Point3 = EndPoint;

            return new PathSegmentCollection
            {
                _bezierSegment
            };
        }

        /// <summary>
        /// 获取开始箭头处的结束点
        /// </summary>
        /// <returns>开始箭头处的结束点</returns>
        protected override Point GetStartArrowEndPoint()
        {
            return ControlPoint1;
        }

        /// <summary>
        /// 获取结束箭头处的开始点
        /// </summary>
        /// <returns>结束箭头处的开始点</returns>
        protected override Point GetEndArrowStartPoint()
        {
            return ControlPoint2;
        }

        /// <summary>
        /// 获取结束箭头处的结束点
        /// </summary>
        /// <returns>结束箭头处的结束点</returns>
        protected override Point GetEndArrowEndPoint()
        {
            return EndPoint;
        }

        #endregion  Protected Methods

    }
}
