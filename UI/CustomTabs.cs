using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Neuron.UI
{
    public class CustomTabs : Control
    {
        public CustomTabs()
        {            
        }
        public CustomTabCollection _tabs = new CustomTabCollection();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomTabCollection Tabs
        {
            get
            {
                return _tabs;
            }
        }

        protected override void OnCreateControl()
        {
            if (_tabs.Count > 0)
            {
                SelectedTab = _tabs[0];
            }
        }

        protected override void OnClick(EventArgs e)
        {
            int pos = PointToClient(Form.MousePosition).X;

            int x = 0;
            foreach (CustomTab tab in _tabs)
            {
                if (pos < x + tab.Width)
                {
                    SelectedTab = tab;
                    Invalidate();
                    if (SelectedTabChanged != null)
                    {
                        SelectedTabChanged(this, EventArgs.Empty);
                    }
                    break;
                }
                x += tab.Width;
            }
            base.OnClick(e);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            base.OnPaint(e);

            int x = 0;
            for (int i = 0; i < _tabs.Count - 1; i++)
            {
                x += _tabs[i].Width;
            }
            int selectedTabX = 0;
            int height = Height - 1;
                    
            StringFormat center = new StringFormat();
            center.Alignment = StringAlignment.Near;
            center.LineAlignment = StringAlignment.Center;
            
            for(int i = _tabs.Count - 1; i >= 0; i--)
            {
                CustomTab tab = _tabs[i];
                if (tab != SelectedTab)
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddLine(x, 0, x, height - 5);
                        path.AddBezier(new Point(x, height - 5), new Point(x, height - 2), new Point(x + 2, height), new Point(x + 5, height));
                        path.AddLine(x + 5, height, x + tab.Width - 25, height);
                        path.AddBezier(new Point(x + tab.Width - 25, height), new Point(x + tab.Width, height), new Point(x + tab.Width, 4), new Point(x + tab.Width + 10, 4));
                        path.AddLine(x + tab.Width + 10, 4, x + tab.Width + 10, 0);
                        path.CloseFigure();

                        using (LinearGradientBrush tabFill = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(0xa0,0xa0,0xa0), Color.FromArgb(0xd0,0xd0,0xd0)))
                        {   
                            ColorBlend blend = new ColorBlend(3);
                            blend.Colors = new Color[] 
                            { 
                                Color.FromArgb(0xa0, 0xa0, 0xa0), 
                                Color.FromArgb(0xd0, 0xd0, 0xd0), 
                                Color.FromArgb(0xd0, 0xd0, 0xd0) 
                            };
                            
                            blend.Positions = new float[] { 0F, .4F, 1F };
                            tabFill.InterpolationColors = blend;
                            
                            
                            e.Graphics.FillPath(tabFill, path);                        
                        }
                        e.Graphics.DrawPath(Pens.Gray, path);
                        e.Graphics.DrawString(tab.Text, Font, Brushes.Black, new RectangleF(x + 10, 8, tab.Width - 10, height - 10), center);
                    }
                }
                else
                {
                    selectedTabX = x;
                }

                x -= tab.Width;
            }

            if (SelectedTab != null)
            {
                CustomTab tab = SelectedTab;
                x = selectedTabX;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddLine(0, 0, 0, 4);
                    path.AddLine(0, 4, x, 4);
                    path.AddLine(x, 4, x, height - 5);
                    path.AddBezier(new Point(x, height - 5), new Point(x, height - 2), new Point(x + 2, height), new Point(x + 5, height));
                    path.AddLine(x + 5, height, x + tab.Width - 25, height);
                    path.AddBezier(new Point(x + tab.Width - 25, height), new Point(x + tab.Width, height), new Point(x + tab.Width, 4), new Point(x + tab.Width + 10, 4));
                    path.AddLine(x + tab.Width + 10, 4, Width, 4);
                    path.AddLine(Width, 4, Width, 0);
                    path.CloseFigure();

                    using (LinearGradientBrush tabFill = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.White, Color.FromArgb(0xd0, 0xd0, 0xd0)))
                    {
                        ColorBlend blend = new ColorBlend(3);
                        blend.Colors = new Color[] 
                            { 
                                BackColor, 
                                Color.White,
                                Color.White
                            };

                        blend.Positions = new float[] { 0F, .5F, 1F };
                        tabFill.InterpolationColors = blend;
                            
                            
                        e.Graphics.FillPath(tabFill, path);
                    }
                    e.Graphics.DrawPath(Pens.Gray, path);
                    using(Font selectedFont = new Font(Font, FontStyle.Bold))
                    {
                        e.Graphics.DrawString(tab.Text, selectedFont, Brushes.Black, new RectangleF(x + 10, 5, tab.Width - 10, height - 10), center);
                    }
                }
            }

            using (Pen back = new Pen(BackColor, 1))
            {
                e.Graphics.DrawLine(back, 1, 0, Width-1, 0);                
            }

            
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CustomTab SelectedTab
        {
            get;
            set;
        }

        public event EventHandler SelectedTabChanged;

    }

    public class CustomTabCollection : Collection<CustomTab>
    {
    }

    public class CustomTab
    {
        public string Id
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }
    }
}
