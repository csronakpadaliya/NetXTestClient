using Neuron.NetX;
using Neuron.NetX.Pipelines;

namespace Neuron.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using Design;

    public class UIElementCanvas : ScrollableControl
    {
        private static readonly AnimationEngine animations = new AnimationEngine();

        public UIElementCanvas()
        {
            AllowPanning = true;
            ElementContainer = new UIElementContainer();
            DoubleBuffered = true;
            ElementContainer.ElementRemoved += this.ElementContainer_ElementRemoved;
        }

        public void LayoutElements()
        {
            foreach (
                var container in
                    this.ElementContainer.OfType<UIElementContainer>().Where(container => container.Layout != null))
            {
                container.Layout.PerformLayout(container);
            }
        }

        [DefaultValue(true)]
        public bool AllowPanning
        {
            get;
            set;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            UIElement element = ElementContainer.GetElementAtPoint(RelativeMousePosition);
            element.OnOleDragDrop(drgevent.Data);
            base.OnDragDrop(drgevent);
        }

        void ElementContainer_ElementRemoved(object sender, UIElementEventArgs e)
        {
            foreach (UIElementAttachment attachment in Attachments.Where(a => a.LeftElement == e.Element || a.RightElement == e.Element).ToArray())
            {
                Attachments.Remove(attachment);
            }

            SelectedElement = null;
        }

        bool _modified;
        public bool Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
                if (ModifiedChanged != null )
                {
                    ModifiedChanged(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler ModifiedChanged;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
            {
                return;
            }

            this._toolTip.Active = false;
            this._toolTip.RemoveAll();
            this._toolTip.Dispose();
            if (this.ElementContainer != null)
            {
                this.ElementContainer.Dispose();
            }
        }

        public AnimationEngine Animations
        {
            get
            {
                return animations;
            }
        }

        int _dragLastX;
        int _dragLastY;

        IList<UIElement> _draggingElements = new List<UIElement>();
        public IList<UIElement> DraggingElements
        {
            get
            {
                return _draggingElements;
            }
        }

        UIElement _selectedElement;
        public UIElement SelectedElement
        {
            get
            {
                return _selectedElement;
            }
            set
            {
                _selectedElement = value;
                var evt = SelectedElementChanged;
                if (evt != null)
                {
                    evt(this, EventArgs.Empty);
                }

                Invalidate();
            }
        }

        public event EventHandler SelectedElementChanged;


        ToolTip _toolTip = new ToolTip()
        {
            UseAnimation = true,
            UseFading = true,
            IsBalloon = false,
            ShowAlways = false,
            AutoPopDelay = 5000,
            AutomaticDelay = 5000, 
            ReshowDelay = 2000
        };

        protected Point CanvasToClient(Point p)
        {            
            var pt = new Point[] { p };
            _matrix.TransformPoints(pt);
            return pt[0];
        }

        protected Point ClientToCanvas(Point p)
        {
            var pt = new Point[] { p };
            var matrix = _matrix.Clone();
            matrix.Invert();
            matrix.TransformPoints(pt);
            return pt[0];
        }

        public Point RelativeMousePosition
        {
            get
            {
                var mouse = PointToClient(Form.MousePosition);
                var pt = new Point[] { mouse };
                var clone = _matrix.Clone();
                clone.Invert();
                clone.TransformPoints(pt);
                return pt[0];
            }
        }

        private float currentZoom = 1.0f;

        public float SelectedZoom { get; private set; }

        public void ZoomByAnimated(float zoom)
        {
            SelectedZoom = zoom;
            var zoomAnimation = new DoubleAnimation(zoom, TimeSpan.FromSeconds(.1), Zoom, Zoom * zoom);
            zoomAnimation.Updated += this.zoomAnimation_Updated;
            Animations.ExecuteExclusive(zoomAnimation);            
        }

        void zoomAnimation_Updated(object sender, EventArgs e)
        {            
            var anim = (DoubleAnimation)sender;
            ZoomBy((float)anim.Current / Zoom );            
        }

        readonly object _translateLock = new object();

        public void ZoomBy(float f)
        {
            //Trace.TraceInformation("Zoom by "+ f+" "+Zoom);
            lock (_translateLock)
            {
                Matrix clone = _matrix.Clone();
                clone.Invert();

                Point[] top = new Point[] { new Point(Width / 2, Height / 2) };
                clone.TransformPoints(top);

                Point original = top[0];

                _matrix = new Matrix();

                this.currentZoom = f;
                _matrix.Scale(this.currentZoom, this.currentZoom, MatrixOrder.Append);

                clone = _matrix.Clone();
                clone.Invert();

                top = new Point[] { new Point(Width / 2, Height / 2) };
                clone.TransformPoints(top);

                Point after = top[0];

                _matrix.Translate(after.X - original.X, after.Y - original.Y);

                Invalidate();
            }
        }

        public float Zoom
        {
            get
            {
                var p1 = new Point(0, 0);
                var p2 = new Point(100, 100);
                this._matrix.TransformPoints(new[] { p1, p2 });
                return (new[] { p1, p2 }[1].X - new[] { p1, p2 }[0].X)/100F;
            }            
        }

        bool _draggingCanvas;

        public void BeginDrag(UIElement element)
        {
            SelectedZoom = 1.0f;

            if(element != null) _draggingElements.Add(element);

            var p = element != null ? this.RelativeMousePosition : this.PointToClient(MousePosition);

            _dragLastX = p.X;
            _dragLastY = p.Y;

            if (element != null)
            {
                element.DragStartX = element.Bounds.X;
                element.DragStartY = element.Bounds.Y;
                element.BeginDrag();
            }
            else if(AllowPanning)
            {
                _draggingCanvas = true;
            }
        }

        public void EndDrag(bool cancel)
        {
            if (_draggingElements.Count != 0)
            {
                foreach (var el in _draggingElements)
                {
                    if (!el.ToString().StartsWith("Pipeline "))
                    {
                        if (Math.Abs(el.Bounds.X - el.DragStartX) > 10 || Math.Abs(el.Bounds.Y - el.DragStartY) > 10)
                        {
                            el.Modified();
                        }
                    }
                    if (cancel)
                    {
                        el.Move(el.DragStartX, el.DragStartY);
                    }
                    el.EndDrag();
                }
                _draggingElements.Clear();
            }
            else
            {
                _draggingCanvas = false;
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            this.Focus();
            try
            {
                base.OnMouseDoubleClick(e);
                if (ElementContainer.GetElementAtPoint(RelativeMousePosition) == _mouseDownElement)
                {
                    //System.Diagnostics.Trace.WriteLine("Double: " + e.Clicks);
                    ElementContainer.MouseDoubleClick(new MouseEventArgs(e.Button, e.Clicks, RelativeMousePosition.X, RelativeMousePosition.Y, e.Delta));
                }
            }
            catch (CancelClickException)
            {
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (_selectedElement != null)
            {
                _selectedElement.KeyPress(e);
                _selectedElement = null;
            }
        }

        DateTime _lastClick;
        int clickCount = 1;

        readonly static TimeSpan _doubleClickInterval = TimeSpan.FromMilliseconds(2000);

        protected override void OnMouseClick(MouseEventArgs e)
        {
            this.Focus();
            try
            {
                //what is the purpose of all of this?
                //System.Diagnostics.Trace.WriteLine("Click Count: " + e.Clicks);
                if (DateTime.Now - _lastClick < _doubleClickInterval)
                {
                    clickCount++;
                    e = new MouseEventArgs(e.Button, clickCount, e.X, e.Y, e.Delta);
                }
                else
                {
                    clickCount = 1;
                }
                _lastClick = DateTime.Now;

                base.OnMouseClick(e);
                if (ElementContainer.GetElementAtPoint(RelativeMousePosition) == _mouseDownElement)
                {
                    //System.Diagnostics.Trace.WriteLine("Element: " + e.Clicks);
                    ElementContainer.MouseClick(new MouseEventArgs(e.Button, e.Clicks, RelativeMousePosition.X, RelativeMousePosition.Y, e.Delta));
                }
            }
            catch (CancelClickException)
            {
            }
        }

        UIElement _mouseDownElement;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            _mouseDownElement = ElementContainer.GetElementAtPoint(RelativeMousePosition);
            if (_mouseDownElement != null && MouseButtons != MouseButtons.Middle && !PanningMode)
            {
                ElementContainer.MouseDown(new MouseEventArgs(e.Button, e.Clicks, RelativeMousePosition.X, RelativeMousePosition.Y, e.Delta));
            }
            else
            {
                if (e.Button == MouseButtons.Middle || PanningMode && e.Button == MouseButtons.Left)
                {
                    BeginDrag(null);
                }
            }        
        }

        public bool PanningMode
        {
            get;
            set;
        }

        public void AdjustViewToShowAll()
        {
            lock(_translateLock)
            {
                ResetView();

                var rect = DetermineElementBounds();
                if (rect.Width == 0 || rect.Height == 0)
                {
                    return;
                }

                rect.Inflate(Math.Max(0, (this.Width - rect.Width)/2), Math.Max(0, (this.Height - rect.Height)/2));
                    
                // use inverted matrixes to calculate required translation / scaling operations
                var inverted = this._matrix.Clone();
                inverted.Invert();
                    
                var pt = new Point[] { new Point(0, 0), new Point(rect.Width, rect.Height) };
                inverted.TransformPoints(pt);

                int distX = pt[1].X - pt[0].X;
                int distY = pt[1].Y - pt[0].Y;

                float currentZoom = this.Zoom;

                // we should compare to screen size here in case it isn't square
                if (distX > distY)
                {
                    float currentSize = this.Width * currentZoom;
                    float scale = currentSize / distX;
                    if (Math.Abs(Math.Abs(scale) - 1.0) > .1)
                    {
                        this.ZoomBy(scale);
                    }
                }
                else
                {
                    float currentSize = this.Height * currentZoom;
                    float scale = currentSize / distY;
                    if (Math.Abs(Math.Abs(scale) - 1.0) > .1)
                    {
                        this.ZoomBy(scale);
                    }
                }

                pt = new Point[] { rect.GetCenter() };
                inverted.TransformPoints(pt);
                Point newCenter = pt[0];

                pt = new Point[] { new Point(this.Width / 2, this.Height / 2) };
                inverted.TransformPoints(pt);
                Point oldCenter = pt[0];

                pt = new Point[] { new Point(oldCenter.X - newCenter.X, oldCenter.Y - newCenter.Y)};
                Point realTranslate = pt[0];
                Point actualTranslate = new Point(realTranslate.X, realTranslate.Y);
                this._matrix.Translate(actualTranslate.X, actualTranslate.Y);
            }
        }

        public Rectangle DetermineElementBounds()
        {
            Rectangle rect = Rectangle.Empty;
            foreach (UIElement element in ElementContainer)
            {
                if (rect == Rectangle.Empty)
                {
                    rect = element.Bounds;
                }
                else
                {
                    int left = Math.Min(element.Bounds.Left, rect.Left);
                    int right = Math.Max(element.Bounds.Right, rect.Right);
                    int top = Math.Min(element.Bounds.Top, rect.Top);
                    int bottom = Math.Max(element.Bounds.Bottom, rect.Bottom);

                    rect = new Rectangle(left, top, right - left, bottom - top);
                }
            }
            return rect;
        }

        public PersistedLayout GetLayout()
        {
            IDictionary<string, PersistedBounds> layout = new Dictionary<string, PersistedBounds>();
            foreach (var element in this.ElementContainer.Where(element => element.Name != null))
            {
                layout.Add(
                    element.Name,
                    new PersistedBounds(
                        element.Bounds.Left, element.Bounds.Top, element.Bounds.Width, element.Bounds.Height));
            }

            return new PersistedLayout(layout);
        }

        public void Restore(PersistedLayout layout)
        {
            foreach (var element in this.ElementContainer.Where(element => element.Name != null))
            {
                if (!layout.Contains(element.Name))
                {
                    throw new LayoutRestoreException();
                }

                var b = layout[element.Name];
                element.Bounds = new Rectangle(b.Left, b.Top, b.Width, b.Height);
            }
        }

        public void Drop()
        {
            if (DraggingElements.Count > 0)
            {
                if (DraggingElements[0].CanDropAnywhere || DraggingElements.Count > 1)
                {
                    EndDrag(false);
                }
                else
                {
                    EndDrag(!ElementContainer.Drop(DraggingElements[0]));
                }
            }

            _draggingCanvas = false;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Drop();

            base.OnMouseUp(e);
            ElementContainer.MouseUp(new MouseEventArgs(e.Button, e.Clicks, RelativeMousePosition.X, RelativeMousePosition.Y, e.Delta));
        }

        public void ShowTooltip(UIElement element)
        {
            if(element.TooltipText != null)
            {
                _toolTip.Show(element.TooltipText, this, CanvasToClient(new Point(element.Bounds.GetCenter().X, element.Bounds.Y + 40)), 5000);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {            
            base.OnMouseMove(e);

            int edgeWidth = Width  - 100;
            int edgeHeight = Height - 100;

            if (_draggingCanvas)
            {
                Rectangle totalBounds = DetermineElementBounds();
            
                int offsetX = e.X - _dragLastX;
                int offsetY = e.Y - _dragLastY;

                // Constrain drag bounds
                if (offsetX > 0 &&  ClientToCanvas(new Point(0, 0)).X + offsetX < totalBounds.X - edgeWidth / Zoom)
                {
                    offsetX = 0;
                }

                if (offsetY > 0 && ClientToCanvas(new Point(0, 0)).Y + offsetY < totalBounds.Y - edgeHeight / Zoom)
                {
                    offsetY = 0;
                }


                if (offsetX < 0 && ClientToCanvas(new Point(Width, 0)).X + offsetX > totalBounds.Right + edgeWidth / Zoom)
                {
                    offsetX = 0;
                }

                if (offsetY < 0 && ClientToCanvas(new Point(0, Height)).Y + offsetY > totalBounds.Bottom + edgeHeight / Zoom)
                {
                    offsetY = 0;
                }


                Offset(new PointF(offsetX, offsetY));
            }
            else
            {
                e = new MouseEventArgs(e.Button, e.Clicks, RelativeMousePosition.X, RelativeMousePosition.Y, e.Delta);

                foreach(UIElement draggingElement in DraggingElements)
                {
                    int offsetX = e.X - _dragLastX;
                    int offsetY = e.Y - _dragLastY;

                    draggingElement.Offset(offsetX, offsetY);

                }                
                ElementContainer.MouseMove(e);                        

            }
            _dragLastX = e.X;
            _dragLastY = e.Y;

            Cursor = (e.Button == MouseButtons.Middle || PanningMode) ? (AllowPanning ? Cursors.SizeAll : Cursors.Default) : Cursors.Default;
        }

        private const int WHEEL_DELTA = 120;

        abstract class Win32Messages
        {
            public const int WM_MOUSEHWHEEL = 0x020E;//discovered via Spy++
        }

        public event EventHandler<MouseEventArgs> MouseHWheel;
        protected void FireMouseHWheel(IntPtr wParam, IntPtr lParam)
        {
            try
            {
                uint wParamValue;
                uint lParamValue;
                if (8 == IntPtr.Size)
                {
                    wParamValue = (uint)((ulong)wParam.ToInt64() & 0xffffffff);
                    lParamValue = (uint)((ulong)wParam.ToInt64() & 0xffffffff);
                }
                else
                {
                    wParamValue = (uint)wParam.ToInt32();
                    lParamValue = (uint)lParam.ToInt32();
                }

                var tilt = (short)((wParamValue >> 16) & 0xffff);
                var x = Utils.LOWORD(lParamValue);
                var y = Utils.HIWORD(lParamValue);
                this.FireMouseHWheel(MouseButtons.None, 0, x, y, tilt);
            }
            catch (OverflowException)
            {
                var errorMessage = string.Format(
                    CultureInfo.InvariantCulture,
                    "Overflow exception: wParam = {0}, lParam = {1}",
                    wParam.ToInt32(),
                    lParam.ToInt32());
                Trace.WriteLine(errorMessage);
            }
        }        

        abstract class Utils
        {
            internal static int HIWORD(uint ptr)
            {
                return (int)((ptr >> 16) & 0xFFFF);
            }

            internal static int LOWORD(uint ptr)
            {
                return (int)(ptr & 0xFFFF);
            }
        }

        protected void FireMouseHWheel(MouseButtons buttons, int clicks, int x, int y, int delta)
        {
            MouseEventArgs args = new MouseEventArgs(buttons, clicks, x, y, delta);
            OnMouseHWheel(args);
            //let everybody else have a crack at it
            if (MouseHWheel != null)
            {
                MouseHWheel(this, args);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.HWnd != this.Handle)
            {
                return;
            }
            switch (m.Msg)
            {
                case Win32Messages.WM_MOUSEHWHEEL:
                    try
                    {
                        FireMouseHWheel(m.WParam, m.LParam);
                        m.Result = (IntPtr)1;
                    }
                    catch (OverflowException)
                    {
                        var errorMessage = string.Format(
                            CultureInfo.InvariantCulture,
                            "Overflow exception:");
                        Trace.WriteLine(errorMessage);
                    }
                    break;
                default:
                    break;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                var newZoom = this.currentZoom + (e.Delta > 0 ? 0.1f : -0.1f);
                if (0.1f > newZoom)
                {
                    newZoom = 0.1f;
                }
                else if (2.0f < newZoom)
                {
                    newZoom = 2.0f;
                }

                this.ZoomBy(newZoom);
            }
            else
            {
                Offset(new Point(0, e.Delta));
            }
        }

        protected virtual void OnMouseHWheel(MouseEventArgs e)
        {
            Offset(new Point(e.Delta, 0));
        }

        public bool IsPanning
        {
            get
            {
                return _draggingCanvas;
            }
        }

        protected void Offset(PointF offset)
        {            
            _matrix.Translate(offset.X, offset.Y, MatrixOrder.Append);
            Invalidate();   
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            ElementContainer.Attach(this);
        }

        public UIElementContainer ElementContainer
        {
            get;
            protected set;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Invalidate();
        }

        Matrix _matrix = new Matrix();

        public void ResetView()
        {
            _matrix = new Matrix();
            Invalidate();
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            lock (_translateLock)
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                e.Graphics.Transform = _matrix;

                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                base.OnPaint(e);

                foreach (UIElementAttachment attachment in Attachments)
                {
                    attachment.Draw(e);
                }

                ElementContainer.Paint(e);

                foreach (UIElement dragging in DraggingElements) // special case dragging is always level element
                {
                    dragging.Paint(e);
                }
            }

            e.Graphics.Transform = new Matrix();

            if (_draggingElements.Count > 0 || _draggingCanvas)
            {
                Rectangle totalBounds = DetermineElementBounds();

                totalBounds = new Rectangle(totalBounds.Left - Width / 2, totalBounds.Top - Height / 2, totalBounds.Width + Width, totalBounds.Height + Height);

                if (totalBounds.Width > 0)
                {
                    double visibleWidth = this.ClientToCanvas(new Point(Width, 0)).X - this.ClientToCanvas(new Point(0, 0)).X ;                    
                    double widthPercent = visibleWidth / totalBounds.Width;

                    double visibleX = this.ClientToCanvas(new Point(Width / 2, 0)).X;
                    double scrollPercent = visibleX == 0 ? 0 : (visibleX - totalBounds.Left) / totalBounds.Width;

                    int barWidth = (int)((Width - 10) * widthPercent);
                    int barPos = (int)((Width - 10) * scrollPercent);

                    if(barWidth < Width)
                    {

                        using (GraphicsPath gp = RoundedRectangle.Create(new Rectangle(barPos - barWidth / 2, Height - 10, barWidth, 5), 3))
                        {
                            e.Graphics.FillPath(Brushes.LightGray, gp);
                            e.Graphics.DrawPath(Pens.Gray, gp);
                        }
                    }
                }

                if (totalBounds.Height > 0)
                {
                    double visibleHeight = this.ClientToCanvas(new Point(0, Height)).Y - this.ClientToCanvas(new Point(0, 0)).Y;
                    double heightPercent = visibleHeight / totalBounds.Height;

                    double visibleY = this.ClientToCanvas(new Point(0, Height / 2)).Y;
                    double scrollPercent = visibleY == 0 ? 0 : (visibleY - totalBounds.Top) / totalBounds.Height;

                    int barHeight = (int)((Height - 10) * heightPercent);
                    int barPos = (int)((Height - 10) * scrollPercent);

                    if(barHeight < Height)
                    {
                        using (GraphicsPath gp = RoundedRectangle.Create(new Rectangle(Width - 10, barPos - barHeight / 2, 5, barHeight), 3))
                        {
                            e.Graphics.FillPath(Brushes.LightGray, gp);
                            e.Graphics.DrawPath(Pens.Gray, gp);
                        }
                    }
                }
            }

            e.Graphics.Transform = _matrix;
        }

        UIElementAttachments _attachments = new UIElementAttachments();

        public UIElementAttachments Attachments
        {
            get
            {
                return _attachments;
            }
        }
    }
}
