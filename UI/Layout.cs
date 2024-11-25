using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Neuron.UI
{
    public abstract class Layout
    {

        public event EventHandler LayoutComplete;


        protected abstract void OnLayout(UIElementContainer elements);
        
        public void PerformLayout(UIElementContainer elements)
        {
            foreach (UIElement element in elements)
            {
                UIElementContainer container = element as UIElementContainer;
                if (container != null)
                {
                    if (container.Layout != null)
                    {
                        container.Layout.PerformLayout(container);
                    }
                }
            }

            OnLayout(elements);

            var handler = LayoutComplete;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

        }


        public Padding Margin
        {
            get;
            set;
        }

        public Padding Padding
        {
            get;
            set;
        }
    }

    public class ManualLayout : Layout
    {
        public ManualLayout()
        {
        }

        protected override void OnLayout(UIElementContainer elements)
        {
            
        }

    }

    public enum StackDirection
    {
        Horizontal,
        Vertical
    }

    public enum StackAlignment
    {
        Near, Center, Far
    }

    

    public class StackLayout : Layout
    {
        public StackLayout()
        {
            Alignment = StackAlignment.Center;
        }

        public bool MakeSameHeight
        {
            get;
            set;
        }

        public bool MakeSameWidth
        {
            get;
            set;
        }

        public StackDirection Direction
        {
            get;
            set;
        }

        
        public int Spacing
        {
            get;
            set;
        }

        public bool SuppressContainerResize
        {
            get;
            set;
        }

        public StackAlignment Alignment
        {
            get;
            set;
        }

        protected override void OnLayout(UIElementContainer container)
        {
            int x = container.Bounds.X + Padding.Left + Margin.Left;
            int y = container.Bounds.Y + Padding.Top + Margin.Top;

            int maxWidth = MinimumContainerSize.Width;
            int maxHeight = MinimumContainerSize.Height;

            bool first = true;

            int maxElementWidth = 0;
            int maxElementHeight = 0;

            foreach (UIElement element in container)
            {
                maxWidth = Math.Max(maxWidth, element.Bounds.Width +  Padding.Left + Padding.Right + Margin.Left + Margin.Right);
                maxHeight = Math.Max(maxHeight, element.Bounds.Height + Padding.Top + Padding.Bottom + Margin.Top + Margin.Bottom);

                maxElementHeight = Math.Max(maxElementHeight, element.Bounds.Height);
                maxElementWidth = Math.Max(maxElementWidth, element.Bounds.Width);
            }

            foreach (UIElement element in container)
            {
                if (MakeSameHeight)
                {
                    element.Resize(element.Width, maxElementHeight);
                    maxHeight = Math.Max(maxHeight, maxElementHeight + Margin.Vertical + Padding.Vertical);
                }

                if (MakeSameWidth)
                {
                    element.Resize(maxElementWidth, element.Height);
                    maxWidth = Math.Max(maxWidth, maxElementWidth + Margin.Horizontal + Padding.Horizontal);
                }

                if (!first)
                {
                    if (Direction == StackDirection.Horizontal)
                    {
                        x += Spacing;

                    }
                    else if (Direction == StackDirection.Vertical)
                    {
                        y += Spacing;
                    }   
                }

                if (Direction == StackDirection.Horizontal)
                {
                    switch(Alignment)
                    {
                        case StackAlignment.Center:
                            y = container.Bounds.Top + maxHeight / 2 - element.Height / 2;
                            break;
                        case StackAlignment.Far:
                            y = container.Bounds.Bottom - element.Height + Padding.Top + Margin.Top;
                            break;
                        case StackAlignment.Near:
                            y = container.Bounds.Top + Padding.Top + Margin.Top;
                            break;  
                    }
                }
                else if (Direction == StackDirection.Vertical)
                {
                    switch(Alignment)
                    {
                        case StackAlignment.Center:
                            x = container.Bounds.Left + maxWidth / 2 - element.Width / 2;
                            break;
                        case StackAlignment.Far:
                            x = container.Bounds.Right - element.Width + Padding.Left + Margin.Left;
                            break;
                        case StackAlignment.Near:
                            x = container.Bounds.Left + Padding.Left + Margin.Left;
                            break;
                    }
                }

                if (element.Canvas != null && element.Container != null)
                {
                    element.AnimatedMove(x, y);
                }
                else
                {
                    element.Move(x, y);
                }

                first = false;

                if (Direction == StackDirection.Horizontal)
                {
                    x += element.Bounds.Width;
                }
                else if (Direction == StackDirection.Vertical)
                {
                    y += element.Bounds.Height;
                }
            }

            if (!SuppressContainerResize)
            {
                if (Direction == StackDirection.Horizontal)
                {
                    container.Bounds = new Rectangle(container.Bounds.X, container.Bounds.Y, Math.Max(MinimumContainerSize.Width, (x + Padding.Right + Margin.Right) - container.Bounds.X), maxHeight);

                }
                else if (Direction == StackDirection.Vertical)
                {
                    container.Bounds = new Rectangle(container.Bounds.X, container.Bounds.Y, maxWidth, Math.Max(MinimumContainerSize.Height, (y + Padding.Bottom + Margin.Bottom) - container.Bounds.Y));
                }

            }

        }

        public Size MinimumContainerSize
        {
            get;
            set;
        }
    }

    public class TableLayout : Layout
    {
        public TableLayout()
        {
            
        }

        public Size ColumnSize
        {
            get;
            set;
        }
        
        public int ColumnCount
        {
            get;
            set;
        }

        public int Spacing
        {
            get;
            set;
        }

        public bool SuppressContainerResize
        {
            get;
            set;
        }


        protected override void OnLayout(UIElementContainer container)
        {            
            int maxWidth = MinimumContainerSize.Width;
            int maxHeight = MinimumContainerSize.Height;
          
            foreach (UIElement element in container)
            {
                maxWidth = Math.Max(maxWidth, element.Bounds.Width + Padding.Left + Padding.Right + Margin.Left + Margin.Right);
                maxHeight = Math.Max(maxHeight, element.Bounds.Height + Padding.Left + Padding.Right + Margin.Left + Margin.Right);
            }
            
            int index = 0;
            foreach (UIElement element in container)
            {
                int column = index % ColumnCount;
                int row = index / ColumnCount;

                int x = container.Bounds.X + column * (ColumnSize.Width + Spacing) + Padding.Left + Margin.Left;
                int y = container.Bounds.Y + row * (ColumnSize.Height + Spacing) + Padding.Top + Margin.Top;

                element.Bounds = new Rectangle(element.Bounds.X, element.Bounds.Y, ColumnSize.Width, ColumnSize.Height);

                if (element.Canvas != null && element.Container != null)
                {
                    element.AnimatedMove(x, y);
                }
                else
                {
                    element.Move(x, y);
                }
                
                index++;
            }
            int rowCount;

            if (ColumnCount > 0)
            {
                rowCount = container.Count / ColumnCount;

                if (container.Count % ColumnCount != 0)
                {
                    rowCount++;
                }
            }
            else
            {
                rowCount = 1; 
            }

            int maxX = ColumnCount * (ColumnSize.Width + Spacing) - Spacing;
            int maxY = rowCount * (ColumnSize.Height + Spacing) - Spacing;

            

            if (!SuppressContainerResize)
            {
                container.Bounds = new Rectangle(container.Bounds.X, container.Bounds.Y, Math.Max(MinimumContainerSize.Width, (Padding.Left + Margin.Left + maxX + Padding.Right + Margin.Right)), Math.Max(Padding.Top + Margin.Top + maxY + Padding.Bottom + Margin.Bottom, maxHeight));
            }

        }

        public Size MinimumContainerSize
        {
            get;
            set;
        }
    }

}
