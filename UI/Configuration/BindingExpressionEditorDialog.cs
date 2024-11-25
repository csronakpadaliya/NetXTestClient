using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neuron.Configuration;
using System.Drawing.Design;
using System.Reflection;
using System.Collections;
using Neuron.ComponentModel;

namespace Neuron.UI.Configuration
{
    public partial class BindingExpressionEditorDialog : Form
    {
        public BindingExpressionEditorDialog()
        {
            InitializeComponent();
            Neuron.Explorer.ResizeUtil.ScaleAll(this);
            PropertyInfo = new PropertyInfo[] { };            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Bindings == null)
            {
                MessageBox.Show("The Bindings property has not been set");
                return;
            }

            pnlEdit.Enabled = false;

            Bindings.RaiseListChangedEvents = true;

            foreach (PropertyInfo property in PropertyInfo)
            {
                var binding = Bindings.FirstOrDefault(x => x.PropertyName == property.Name);
                
                if(binding == null)
                {
                    Bindings.Add(new ExpressionBoundProperty(property.Name, null));
                }
            }

            lstBindings.DataSource = Bindings;
        }


        public PropertyInfo[] PropertyInfo
        {
            get;
            set;
        }

        public BindingList<ExpressionBoundProperty> Bindings
        {
            get;
            set;
        }

        protected ExpressionBoundProperty SelectedBinding
        {
            get
            {
                return (ExpressionBoundProperty)lstBindings.SelectedItem;
            }
            set
            {
                lstBindings.SelectedItem = value;
            }
        }

        private void txtBindingExpression_TextChanged(object sender, EventArgs e)
        {
            if (SelectedBinding != null) SelectedBinding.Expression = txtBindingExpression.Text;
        }
        private void lstBindings_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlEdit.Enabled = SelectedBinding != null;

          
            if (SelectedBinding != null)
            {
                txtBindingExpression.Text = SelectedBinding.Expression;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {                        
            try
            {
                HashSet<string> properties = new HashSet<string>();
                foreach (var b in Bindings)
                {
                    if (properties.Contains(b.PropertyName))
                    {
                        throw new InvalidOperationException();
                    }
                    properties.Add(b.PropertyName);
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Properties cannot be bound more than once.");
                return;
            }

            Bindings = new BindingList<ExpressionBoundProperty>(Bindings.Where(b => !String.IsNullOrEmpty(b.Expression)).ToArray()); 

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            
            Close();
        }

        private String getItemDisplayText(ExpressionBoundProperty item)
        {
            PropertyInfo info = Array.Find<PropertyInfo>(PropertyInfo, x => item.PropertyName == x.Name);
            return info.Name;
        }

        private void lstBindings_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0 && e.Index < Bindings.Count)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();

                StringFormat format = new StringFormat() { Trimming = StringTrimming.EllipsisCharacter };
                Rectangle bounds = e.Bounds;
                if (!Neuron.Explorer.ResizeUtil.StartedOnPrimaryScreen)
                {
                    bounds.Size = new Size((int)(bounds.Size.Width * Neuron.Explorer.ResizeUtil.DpiScalingValue), (int)(bounds.Size.Height * Neuron.Explorer.ResizeUtil.DpiScalingValue));
                }
                int scaledX = (int)(17 * Neuron.Explorer.ResizeUtil.DpiScalingValue);
                int scaledY = (int)(2 * Neuron.Explorer.ResizeUtil.DpiScalingValue);
                bounds.Offset(scaledX, scaledY);
                int scaledSize = (int)(16 * Neuron.Explorer.ResizeUtil.DpiScalingValue);
                e.Graphics.DrawImage(Properties.Resources.Database, e.Bounds.X, e.Bounds.Y, scaledSize, scaledSize);
                using (Brush fontBrush = new SolidBrush(e.ForeColor))
                {
                    if (Bindings[e.Index].IsEmpty)
                    {
                        String text = getItemDisplayText(Bindings[e.Index]);
                        e.Graphics.DrawString(text, e.Font, fontBrush, bounds, format);

                    }
                    else
                    {
                        using (Font boldFont = new Font(e.Font, FontStyle.Bold))
                        {
                            String text = getItemDisplayText(Bindings[e.Index]);
                            e.Graphics.DrawString(text, boldFont, fontBrush, bounds, format);
                        }
                    }
                }
                
            }
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {

        }

    }


}
