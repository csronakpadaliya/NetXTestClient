using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Neuron.Pipelines;
using Neuron.Esb;

namespace Neuron.UI
{
    public class UIElementContainer<T> : UIElementContainer
    {
        public UIElementContainer()
        {
        }

        public UIElementContainer(T data)
        {
            TypedData = data;
        }

        public T TypedData
        {
            get
            {
                return (T)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }
    }

    public class UIElementContainer : UIElement, IEnumerable<UIElement>
    {
        public UIElementContainer()
        {
            HoveringChanged += this.UIElementContainer_HoveringChanged;
            BoundsChanged += this.UIElementContainer_BoundsChanged;

            Layout = new ManualLayout();
        }

        void UIElementContainer_HoveringChanged(object sender, EventArgs e)
        {
            if (!Hovering)
            {
                foreach (UIElement el in _elements)
                {
                    el.Hovering = false;
                }
            }
        }

        public UIElement FindElement<T>(T data) where T : class
        {
            foreach (UIElement element in _elements)
            {            
                if (data == element.Data)
                {
                    return element;
                }

                if (data is PipelineStep<ESBMessage> && element.Data is PipelineStep<ESBMessage>)
                {
                    var step = data as PipelineStep<ESBMessage>;
                    var elementStep = element.Data as PipelineStep<ESBMessage>;
                    if (step.Id == elementStep.Id)
                    {
                        return element;
                    }
                }
                var container = element as UIElementContainer;
                if (container == null)
                {
                    continue;
                }

                if (container is UIElementContainer<T>)
                {
                    if (data == ((UIElementContainer<T>)container).TypedData)
                    {
                        return container;
                    }

                    if (data is PipelineStep<ESBMessage> && ((UIElementContainer<T>)container).TypedData is PipelineStep<ESBMessage>)
                    {
                        var step = data as PipelineStep<ESBMessage>;
                        var elementStep = ((UIElementContainer<T>)container).TypedData as PipelineStep<ESBMessage>;
                        if (step.Id == elementStep.Id)
                        {
                            return container;
                        }
                    }
                }

                var containerElement = container.FindElement<T>(data);
                if (containerElement != null)
                {
                    return containerElement;
                }
            }

            return null;
        }

        public event EventHandler<UIElementEventArgs> ElementAdded;
        public event EventHandler<UIElementEventArgs> ElementRemoved;

        protected override void OnAttach(UIElementCanvas c)
        {
            base.OnAttach(c);

            foreach (var element in _elements.ToArray())
            {
                element.Attach(c);
            }
        }

        protected override void OnDetach(UIElementCanvas c)
        {
            base.OnDetach(c);

            foreach (UIElement element in _elements.ToArray())
            {
                element.Detach(c);
            }
        }

        public IEnumerable<UIElement> EnumerateReverse()
        {
            for (var i = _elements.Count - 1; i >= 0; i--)
            {
                yield return _elements[i];
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            foreach (var el in this.EnumerateReverse())
            {
                el.Container = this;
                if (el.Region == null)
                {
                    continue;
                }

                if (!el.Region.IsVisible(new Point(e.X, e.Y)))
                {
                    continue;
                }

                el.MouseDoubleClick(e);
                break;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            foreach (var el in this.EnumerateReverse().Where(el => el.Region != null))
            {
                if (!this.Canvas.DraggingElements.Contains(el) && el.Region.IsVisible(new Point(e.X, e.Y)))
                {
                    el.Hovering = true;
                    el.MouseMove(e);
                    break;
                }

                el.Hovering = false;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            foreach (var el in this.EnumerateReverse())
            {
                el.Container = this;
                if (el.Region == null)
                {
                    continue;
                }

                if (!el.Region.IsVisible(new Point(e.X, e.Y)))
                {
                    continue;
                }

                el.MouseClick(e);
                break;
            }
        }

        protected override Region CalculateRegion()
        {
            if (Layout != null)
            {
                var actualBounds = new Rectangle(
                    Bounds.X + Layout.Margin.Left,
                    Bounds.Y + Layout.Margin.Top,
                    Bounds.Width - (Layout.Margin.Left + Layout.Margin.Right),
                    Bounds.Height - (Layout.Margin.Top + Layout.Margin.Bottom));
                return new Region(actualBounds);
            }

            return base.CalculateRegion();
        }

        public UIElement GetElementAtPoint(Point point)
        {
            return GetElementAtPoint(point, false);
        }

        public UIElement GetElementAtPoint(Point point, bool excludeDragging)
        {
            return
                this.EnumerateReverse()
                    .Where(el => !excludeDragging || !el.IsDragging)
                    .Where(el => el.Region != null)
                    .FirstOrDefault(el => el.Region.IsVisible(point));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            foreach (
                var el in
                    this.EnumerateReverse()
                        .Where(el => el.Region != null)
                        .Where(el => el.Region.IsVisible(new Point(e.X, e.Y))))
            {
                el.MouseDown(e);
                break;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            foreach (
                var el in
                    this.EnumerateReverse()
                        .Where(el => el.Region != null)
                        .Where(el => el.Region.IsVisible(new Point(e.X, e.Y))))
            {
                el.MouseUp(e);
                break;
            }
        }

        public void BringToFront(UIElement element)
        {
            if (!_elements.Contains(element))
            {
                throw new InvalidOperationException("The element is not a member of this container");
            }

            _elements.Remove(element);
            _elements.Add(element);

            element.Invalidate();
        }

        public void SendToBack(UIElement element)
        {
            if (!_elements.Contains(element))
            {
                throw new InvalidOperationException("The element is not a member of this container");
            }

            _elements.Remove(element);
            _elements.Insert(0, element);

            element.Invalidate();
        }

        void UIElementContainer_BoundsChanged(object sender, BoundsChangedEventArgs e)
        {
            int xOffset = Bounds.Left - e.OldBounds.Left;
            int yOffset = Bounds.Top - e.OldBounds.Top;

            foreach (UIElement el in _elements)
            {
                el.Offset(xOffset, yOffset);
            }
        }

        readonly List<UIElement> _elements = new List<UIElement>();
        public IList<UIElement> Elements
        {
            get
            {
                return _elements;
            }
        }

        public int Count
        {
            get
            {
                return Elements.Count;
            }
        }

        public bool Contains(UIElement element)
        {
            return Elements.Contains(element);
        }

        public void InsertElement(int pos, UIElement element)
        {
            if (Canvas != null)
            {
                element.Attach(Canvas);
                Canvas.Modified = true;
            }

            element.Container = this;

            _elements.Insert(pos, element);

            if (ElementAdded != null)
            {
                ElementAdded(this, new UIElementEventArgs(element));
            }

            if (Canvas != null)
            {
                Canvas.LayoutElements();
            }
            else if(Layout != null)
            {
                this.Layout.PerformLayout(this);
            }

        }

        public void InsertTemporarilyRemovedElement(int pos, UIElement element)
        {            
            element.Container = this;

            _elements.Insert(pos, element);

            if (ElementAdded != null)
            {
                ElementAdded(this, new UIElementEventArgs(element));
            }

            if (Canvas != null)
            {
                Canvas.LayoutElements();
            }
            else if (Layout != null)
            {
                this.Layout.PerformLayout(this);
            }
        }

        public event EventHandler<EventArgs> ElementsCleared;

        public void ClearElements()
        {
            if (Canvas != null)
            {
                foreach (var el in _elements)
                {                    
                    el.Detach(Canvas);
                    
                    if (ElementRemoved != null)
                    {
                        ElementRemoved(this, new UIElementEventArgs(el));
                    }
                }

                Canvas.Modified = true;
            }
            
            _elements.Clear();

            if (Canvas != null)
            {
                Canvas.LayoutElements();
            }
            else if (Layout != null)
            {
                this.Layout.PerformLayout(this);
            }

            if (ElementsCleared != null)
            {
                ElementsCleared(this, new EventArgs());
            }
        }

        public void AddElement(UIElement element)
        {
            if (Canvas != null)
            {
                element.Attach(Canvas);
                Canvas.Modified = true;
            }

            element.Container = this;

            _elements.Add(element);

            if (ElementAdded != null)
            {
                ElementAdded(this, new UIElementEventArgs(element));
            }

            if (Canvas != null)
            {
                Canvas.LayoutElements();
            }
            else if (Layout != null)
            {
                Layout.PerformLayout(this);
            }
          
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            foreach (var element in this.Elements)
            {
                element.Dispose();
            }
        }

        public void RemoveElement(UIElement element)
        {
            if (Canvas != null)
            {
                element.Detach(Canvas);
            }

            element.Container = null;

            if (_elements.Contains(element))
            {
                _elements.Remove(element);

                if (ElementRemoved != null)
                {
                    ElementRemoved(this, new UIElementEventArgs(element));
                }
            }
            else
            {
                throw new InvalidOperationException("The element does not belong to this control");
            }

            if (Canvas != null)
            {
                Canvas.LayoutElements();
            }
            else if (Layout != null)
            {
                this.Layout.PerformLayout(this);
            }

        }

        public void RemoveElementTemporarily(UIElement element)
        {
            element.Container = null;

            if (_elements.Contains(element))
            {
                _elements.Remove(element);

                if (ElementRemoved != null)
                {
                    ElementRemoved(this, new UIElementEventArgs(element));
                }
            }
            else
            {
                throw new InvalidOperationException("The element does not belong to this control");
            }

            if (Canvas != null)
            {
                Canvas.LayoutElements();
            }
            else if (Layout != null)
            {
                this.Layout.PerformLayout(this);
            }

        }
        Layout _layout;
        public Layout Layout
        {
            get
            {
                return _layout;
            }
            set
            {
                _layout = value;
                if (Canvas != null)
                {
                    Canvas.LayoutElements();
                }
                else
                {
                    Layout.PerformLayout(this);
                }
            }
        }

        protected void PaintChildren(PaintEventArgs e)
        {
            foreach (UIElement el in this._elements.Where(el => !el.IsDragging))
            {
                el.Paint(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintChildren(e);
        }

        #region IEnumerable<UIElement> Members

        public IEnumerator<UIElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        #endregion

        public override bool Drop(UIElement element)
        {
            var el = GetElementAtPoint(Canvas.RelativeMousePosition);
            return el != null && el.Drop(element);
        }
    }

}
