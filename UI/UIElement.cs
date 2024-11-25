using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Neuron.UI
{    
    public abstract class UIElement : IDisposable
    {
        public void OleDragDrop(IDataObject obj)
        {
            OnOleDragDrop(obj);
        }

        protected internal virtual void OnOleDragDrop(IDataObject obj)
        {
        }

        public string TooltipText
        {
            get;
            set;
        }

        public virtual string Name { get; set; }

        public bool IsSelected
        {
            get
            {
                return Canvas.SelectedElement == this;
            }
        }

        public event EventHandler DataChanged;

        object _data;
        public object Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                if (DataChanged != null)
                {
                    DataChanged(this, EventArgs.Empty);
                }
            }
        }

        public virtual bool Drop(UIElement element)
        {
            return false;
        }

        internal void BeginDrag()
        {
            if (!CanDrag) throw new InvalidOperationException("Cannot drag and element when CanDrag is false.");

            IsDragging = true;
        }

        internal void EndDrag()
        {
            IsDragging = false;
        }

        public bool CanDropAnywhere
        {
            get;
            set;
        }

        bool _visible = true;
        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
                Invalidate();
            }
        }

        bool _canDrag;
        public bool CanDrag
        {
            get
            {
                return _canDrag;
            }
            set
            {
                _canDrag = value;

                if (_isDragging && !value)
                {
                    EndDrag();
                }
            }
        }

        bool _isDragging;
        public bool IsDragging
        {
            get
            {
                return _isDragging;
            }
            private set
            {
                if (_isDragging != value)
                {
                    _isDragging = value;
                    if (DraggingChanged != null) DraggingChanged(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler DraggingChanged;

        public virtual IEnumerable<UIElement> GetDraggingElements()
        {
            return new[] { this };
        }

        internal void MouseDown(MouseEventArgs e)
        {
            try
            {
                OnMouseDown(e);

                if (MouseButtons.Left != e.Button || 1 != e.Clicks || !this.CanDrag
                    || this.Canvas.DraggingElements.Count != 0)
                {
                    return;
                }

                foreach (var el in this.GetDraggingElements())
                {
                    this.Canvas.BeginDrag(el);
                }
            }
            catch (CancelClickException)
            {
            }
        }

        internal void MouseUp(MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        internal void MouseMove(MouseEventArgs e)
        {
            OnMouseMove(e);
        }


        protected virtual void OnMouseDown(MouseEventArgs e)
        {
        }


        protected virtual void OnMouseUp(MouseEventArgs e)
        {
        }


        protected virtual void OnMouseMove(MouseEventArgs e)
        {

        }

        public int Width
        {
            get
            {
                return Bounds.Width;
            }
        }

        public int Height
        {
            get
            {
                return Bounds.Height;
            }
        }

        public void Offset(int xOffset, int yOffset)
        {
            Bounds = new Rectangle(Bounds.Left + xOffset, Bounds.Top + yOffset, Bounds.Width, Bounds.Height);
        }

        public void Offset(Point p)
        {
            Offset(p.X, p.Y);
        }
        
        public UIElementCanvas Canvas
        {
            get
            {
                if (Container == null)
                {
                    return _canvas;
                }

                var c = Container;
                while (c.Container != null)
                {
                    c = c.Container;
                }

                return c.Canvas;
            }
        }

        public Point PointToClient(Point p)
        {
            return _canvas.PointToClient(p);
        }

        protected void ShowTooltip(string message)
        {
            _tooltip.Show(message, _canvas, Bounds.Left, Bounds.Top + Bounds.Height, 500);
        }

        ToolTip _tooltip = new ToolTip();

        UIElementCanvas _canvas;

        public void Attach(UIElementCanvas parent)
        {            
            _canvas = parent;

            OnAttach(parent);

            Invalidate();
        }

        protected virtual void OnAttach(UIElementCanvas c)
        {
        }

        protected virtual void OnDetach(UIElementCanvas c)
        {

        }

        public event EventHandler Click;

        protected virtual void OnValidate()
        {
        }

        public void Validate()
        {
            try
            {
                OnValidate();
                IsValid = true;
            }
            catch (UIElementValidationException ex)
            {
                ValidationException = ex;
                IsValid = false;
            }
        }

        public UIElementValidationException ValidationException
        {
            get;
            private set;
        }

        bool _isValid = true;
        public bool IsValid
        {
            get
            {
                return _isValid;
            }

            private set
            {
                if (_isValid != value)
                {
                    _isValid = value;
                    Invalidate();
                }
            }
        }

        internal void MouseClick(MouseEventArgs e)
        {
            OnMouseClick(e);

            
            if (e.Button == MouseButtons.Left)
            {
                if (Click != null)
                {
                    Click(this, EventArgs.Empty);
                }
            }
        }

        protected virtual void OnMouseClick(MouseEventArgs e)
        {
            
        }

        internal void MouseDoubleClick(MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        protected virtual void OnMouseDoubleClick(MouseEventArgs e)
        {

        }

        internal virtual void KeyPress(KeyEventArgs e)
        {
            OnKeyPress(e);
        }

        protected virtual void OnKeyPress(KeyEventArgs e)
        {

        }

        public void Detach(Control parent)
        {
            if (_canvas == null) throw new InvalidOperationException("UIElement is not attached to a control");

            Invalidate();

            _canvas = null;

            OnDetach((UIElementCanvas)parent);
        }

        internal int DragStartX;
        internal int DragStartY;

        Rectangle _bounds;
        public virtual Rectangle Bounds
        {
            get
            {
                return _bounds;
            }
            set
            {
                Invalidate();
                var oldBounds = _bounds;
                _bounds = value;
                var newRegion = CalculateRegion();
                if (Region != null)
                {
                    Region.Dispose();
                }

                Region = newRegion;

                if (BoundsChanged != null)
                {
                    BoundsChanged(this, new BoundsChangedEventArgs(oldBounds));
                }

                Invalidate();
            }
        }

        protected virtual Region CalculateRegion()
        {
            return new Region(Bounds);           
        }

        public event EventHandler<BoundsChangedEventArgs> BoundsChanged;

        Region _region;
        public Region Region
        {
            get
            {                
                return Visible ? _region : null;
            }

            private set
            {
                _region = value;
            }
        }

        public Cursor Cursor
        {
            get;
            private set;
        }

        bool _hovering;
        public bool Hovering
        {
            get
            {
                return _hovering;
            }
            internal set
            {
                if (this._hovering == value)
                {
                    return;
                }

                this._hovering = value;
                if (this._hovering)
                {
                    this.Canvas.ShowTooltip(this);
                }

                if (this.HoveringChanged != null)
                {
                    this.HoveringChanged(this, EventArgs.Empty);
                }

                this.Canvas.Invalidate();
            }
        }

        public void Invalidate()
        {
            if (_canvas != null)
            {
                _canvas.Invalidate();
            }
        }

        public event EventHandler HoveringChanged;

        internal void Paint(PaintEventArgs e)
        {
            if (!this.Visible)
            {
                return;
            }

            try
            {
                this.OnPaint(e);
            }
            catch(Exception ex)
            {
                e.Graphics.FillRectangle(Brushes.White, this.Bounds);
                e.Graphics.DrawRectangle(Pens.Black, this.Bounds);
                using(var errorFont= new Font("Segoe UI", 10F))
                {
                    var sf = new StringFormat()
                                 {
                                     Alignment = StringAlignment.Center,
                                     LineAlignment = StringAlignment.Center,
                                     Trimming = StringTrimming.Character
                                 };
                    e.Graphics.DrawString(ex.ToString(), errorFont, Brushes.Red, this.Bounds, sf);
                }
            }
        }

        protected abstract void OnPaint(PaintEventArgs e);

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (Region != null)
                {
                    Region.Dispose();
                }
                _tooltip.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(false);
        }

        #endregion

        public void AnimatedMove(int x, int y)
        {
            var animation = new RectangleAnimation(
                this,
                TimeSpan.FromSeconds(.2),
                new Rectangle(Bounds.X - Container.Bounds.X, Bounds.Y - Container.Bounds.Y, Width, Height),
                new Rectangle(x - Container.Bounds.X, y - Container.Bounds.Y, Width, Height));
            animation.Updated += (o, e) =>
            {
                var target = (UIElement)((RectangleAnimation)o).Target;
                if (target.Container == null)
                {
                    return;
                }

                var parentBounds = target.Container.Bounds;
                var currentBounds = ((RectangleAnimation)o).Current;

                target.Bounds = new Rectangle(
                    parentBounds.X + currentBounds.X,
                    parentBounds.Y + currentBounds.Y,
                    currentBounds.Width,
                    currentBounds.Height);
            };
            Canvas.Animations.ExecuteExclusive(animation);        
        }

        public void AnimatedMove(Rectangle newBounds)
        {
            var animation = new RectangleAnimation(this, TimeSpan.FromSeconds(.2), Bounds, newBounds);
            animation.Updated += (o, e) =>
            {
                var target = (UIElement)((RectangleAnimation)o).Target;
                if (target.Container == null)
                {
                    return;
                }

                var currentBounds = ((RectangleAnimation)o).Current;
                target.Bounds = currentBounds;
            };
            Canvas.Animations.ExecuteExclusive(animation);
        }

        public void Move(int x, int y)
        {
            Bounds = new Rectangle(x, y, Width, Height);
        }

        public void Resize(int w, int h)
        {
            Bounds = new Rectangle(Bounds.X, Bounds.Y, w, h);
        }

        public UIElementContainer Container
        {
            get;
            internal set;
        }

        internal void Modified()
        {
            if (Canvas!=null)
            Canvas.Modified = true;
        }
    }

    public abstract class UIElement<T> : UIElement
    {
        protected UIElement(T data)
        {
            TypedData = data;
        }

        public T TypedData
        {
            get
            {
                return (T)Data;
            }

            set
            {
                Data = value;

            }
        }
    }

    [global::System.Serializable]
    public class UIElementValidationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public UIElementValidationException() { }
        public UIElementValidationException(string message) : base(message) { }
        public UIElementValidationException(string message, Exception inner) : base(message, inner) { }
        protected UIElementValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    public class BoundsChangedEventArgs : EventArgs
    {
        public BoundsChangedEventArgs(Rectangle oldBounds)
        {
            OldBounds = oldBounds;
        }

        public Rectangle OldBounds
        {
            get;
            private set;
        }
    }

    public interface IPropertyGridBindable
    {
        object BindTo { get; }
    }
}
