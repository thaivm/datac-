using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class catch event of mouse.
    /// </summary>
    class MouseWheelGesture : MouseGesture
    {
        /// <summary>
        /// Get and set direction
        /// </summary>
        public WheelDirection Direction { get; set; }

        /// <summary>
        /// Get Ctrl Down
        /// </summary>
        public static MouseWheelGesture CtrlDown
        {
            get
            {
                return new MouseWheelGesture(ModifierKeys.Control) { Direction = WheelDirection.Down };
            }
        }
        /// <summary>
        /// Get Ctrl Up
        /// </summary>
        public static MouseWheelGesture CtrlUp
        {
            get
            {
                return new MouseWheelGesture(ModifierKeys.Control) { Direction = WheelDirection.Up };
            }
        }
        /// <summary>
        /// Initializes the <see cref="T:MouseWheelGesture"/> class.
        /// </summary>
        public MouseWheelGesture()
            : base(MouseAction.WheelClick)
        {
        }
        /// <summary>
        /// Initializes the <see cref="T:MouseWheelGesture"/> class.
        /// </summary>
        public MouseWheelGesture(ModifierKeys modifiers)
            : base(MouseAction.WheelClick, modifiers)
        {
        }
        /// <summary>
        /// Matches mouse event wheel
        /// </summary>
        /// <param name="targetElement"></param>
        /// <param name="inputEventArgs"></param>
        /// <returns>bool</returns>
        public override bool Matches(object targetElement, InputEventArgs inputEventArgs)
        {
            if (!base.Matches(targetElement, inputEventArgs)) return false;
            if (!(inputEventArgs is MouseWheelEventArgs)) return false;
            var args = (MouseWheelEventArgs)inputEventArgs;
            switch (Direction)
            {
                case WheelDirection.None:
                    return args.Delta == 0;
                case WheelDirection.Up:
                    return args.Delta > 0;
                case WheelDirection.Down:
                    return args.Delta < 0;
                default:
                    return false;
            }
        }
        /// <summary>
        /// Register enum for event wheel of mouse
        /// </summary>
        public enum WheelDirection
        {
            None,
            Up,
            Down,
        }
    }
}
