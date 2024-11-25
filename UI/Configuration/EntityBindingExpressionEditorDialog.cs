using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Neuron.ComponentModel;
using Neuron.Explorer;
using Neuron.UI.Properties;

namespace Neuron.UI.Configuration
{
    public partial class EntityBindingExpressionEditorDialog : Form
    {
        public EntityBindingExpressionEditorDialog()
        {
            InitializeComponent();
            if(Neuron.Explorer.DPIUtil.PrimaryScaleFactor(this) != 100)
            {
                var dpiScaling = (float)Neuron.Explorer.DPIUtil.ScaleFactor(this, this.Location) / 100;
                this.lstBindings.ItemHeight = (int)(this.lstBindings.ItemHeight * dpiScaling);
            }
            
            PropertyInfo = new PropertyInfo[] {};
        }

        public float DpiScalingValue = 1.0F;

        public bool StartedOnPrimaryScreen = true;

        public static ObservableCollection<string> EnvironmentNamesCollection { get; set; }

        public PropertyInfo[] PropertyInfo { get; set; }

        public BindingList<ExpressionBoundProperty> Bindings { get; set; }

        protected ExpressionBoundProperty SelectedBinding
        {
            get { return (ExpressionBoundProperty) lstBindings.SelectedItem; }
            set { lstBindings.SelectedItem = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Bindings == null)
            {
                MessageBox.Show(this,"The Bindings property has not been set");
                return;
            }


            pnlEdit.Enabled = false;

            Bindings.RaiseListChangedEvents = true;
            List<PropInfo> tempPropList = new List<PropInfo>();
            foreach (PropertyInfo property in PropertyInfo)
            {
                
                tempPropList.Add(new PropInfo{ Name = property.Name, DisplayName = getItemDisplayText(property.Name)});

            }
            // remove old properties no longer supported
            for (int x = Bindings.Count -1; x >= 1; x--)
            {
                var prop = Bindings[x].PropertyName;
                bool found = false;
                foreach(var tempProp in tempPropList)
                {
                    if(tempProp.Name == prop) 
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    Bindings.RemoveAt(x);
            }
            tempPropList.Sort((a, b) => string.Compare(a.DisplayName, b.DisplayName));
            foreach (var property in tempPropList)
            {
                ExpressionBoundProperty binding = Bindings.FirstOrDefault(x => x.PropertyName == property.Name);

                if (binding == null)
                {
                    Bindings.Add(new ExpressionBoundProperty(property.Name, null));
                }
            }

            lstBindings.DataSource = Bindings;
            GetEnvironmentVariableRefrence();
            pnlEdit.SizeChanged += pnlEdit_SizeChanged;
        }

        private void pnlEdit_SizeChanged(object sender, EventArgs e)
        {
            labelPropertyActualDescription.Size = labelPropertyActualDescription.GetPreferredSize(pnlEdit.Size);
        }

        private EnvironmentVariableSelector GetEnvironmentVariableRefrence()
        {
            if (elementHost1.Child == null)
            {
                elementHost1.Child = new EnvironmentVariableSelector();

            }
            var window = (EnvironmentVariableSelector) elementHost1.Child;
            window.SetEnvironmentVariables((IEnumerable<string>)EnvironmentNamesCollection ?? new string[0]);
            window.SelectedBinding = SelectedBinding;
            return window;
        }

        private void lstBindings_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlEdit.Enabled = SelectedBinding != null;
        
            if (SelectedBinding != null)
            {
                var window = GetEnvironmentVariableRefrence();
                window.editor.Text = !string.IsNullOrEmpty(SelectedBinding.Expression) ? SelectedBinding.Expression : null;
            }

            PropertyInfo info = Array.Find(PropertyInfo, x => SelectedBinding.PropertyName == x.Name);
            if (info != null)
            {
                DescriptionAttribute att =
                    info.GetCustomAttributes(typeof(DescriptionAttribute), true)
                        .OfType<DescriptionAttribute>()
                        .FirstOrDefault();
                labelPropertyActualDescription.Text = att != null
                    ? att.Description
                    : "No description is available for this property.";
                labelPropertyActualDescription.Size = labelPropertyActualDescription.GetPreferredSize(pnlEdit.Size);
            }
            else
            {
                labelPropertyActualDescription.Text = "No description is available for this property.";
                labelPropertyActualDescription.Size = labelPropertyActualDescription.GetPreferredSize(pnlEdit.Size);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var properties = new HashSet<string>();
                foreach (ExpressionBoundProperty b in Bindings)
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

            Bindings =
                new BindingList<ExpressionBoundProperty>(
                    Bindings.Where(b => !String.IsNullOrEmpty(b.Expression)).ToArray());

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

         private String getItemDisplayText(string propertyName)
        {
            PropertyInfo info = Array.Find(PropertyInfo, x => propertyName == x.Name);
            if (info != null)
            {
                DisplayNameAttribute att =
                    info.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                        .OfType<DisplayNameAttribute>()
                        .FirstOrDefault();

                //get the category
                CategoryAttribute catAtt =
                    info.GetCustomAttributes(typeof(CategoryAttribute), true)
                        .OfType<CategoryAttribute>()
                        .FirstOrDefault();

                string categoryName = null;
                if (catAtt != null && !String.IsNullOrEmpty(catAtt.Category))
                {
                    categoryName = catAtt.Category.Trim();
                    if (categoryName.Contains("Properties"))
                    {
                        categoryName = categoryName.Replace("Properties", "").Trim();
                    }
                    if(!categoryName.StartsWith("("))
                    {
                        categoryName = "(" + categoryName + ")";
                    }
                }

                //format the display text as 'Property Display name (Category Name)'
                String displayText = info.Name;
                if(att != null)
                {
                    displayText = att.DisplayName.Trim();
                    if(categoryName != null)
                    {
                        displayText += " " + categoryName;
                    }
                }
                return displayText;
            }
            return string.Empty;
        }

        private String getItemDisplayText(ExpressionBoundProperty item)
        {
            PropertyInfo info = Array.Find(PropertyInfo, x => item.PropertyName == x.Name);
            if (info != null)
            {
                DisplayNameAttribute att =
                    info.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                        .OfType<DisplayNameAttribute>()
                        .FirstOrDefault();

                //get the category
                CategoryAttribute catAtt =
                    info.GetCustomAttributes(typeof(CategoryAttribute), true)
                        .OfType<CategoryAttribute>()
                        .FirstOrDefault();

                string categoryName = null;
                if (catAtt != null && !String.IsNullOrEmpty(catAtt.Category))
                {
                    categoryName = catAtt.Category.Trim();
                    if (categoryName.Contains("Properties"))
                    {
                        categoryName = categoryName.Replace("Properties", "").Trim();
                    }
                    if (!categoryName.StartsWith("("))
                    {
                        categoryName = "(" + categoryName + ")";
                    }
                }
                //format the display text as 'Property Display name (Category Name)'
                String displayText = info.Name;
                if (att != null)
                {
                    displayText = att.DisplayName.Trim();
                    if (categoryName != null)
                    {
                        displayText += " " + categoryName;
                    }
                }
                return displayText;
            }
            return string.Empty;
        }

        private void lstBindings_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0 && e.Index < Bindings.Count)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();

                var format = new StringFormat {Trimming = StringTrimming.None};
                Rectangle bounds = e.Bounds;
                var dpiScaling = Neuron.Explorer.ResizeUtil.DpiScalingValue == 0.0F ? (float)Neuron.Explorer.DPIUtil.ScaleFactor(this, this.Location) / 100 : Neuron.Explorer.ResizeUtil.DpiScalingValue;

                bounds.Size = new Size((int)(bounds.Size.Width * dpiScaling), (int)(bounds.Size.Height * dpiScaling));

                int scaledX = (int)(17 * dpiScaling);
                int scaledY = (int)(2 * dpiScaling);
                bounds.Offset(scaledX, scaledY);
                int scaledSize = (int)(16 * dpiScaling);
                e.Graphics.DrawImage(Resources.Database, e.Bounds.X, e.Bounds.Y, scaledSize, scaledSize);
                using (System.Drawing.Brush fontBrush = new SolidBrush(e.ForeColor))
                {
                    if (Bindings[e.Index].IsEmpty)
                    {
                        String text = getItemDisplayText(Bindings[e.Index]);
                        
                        if (!string.IsNullOrEmpty(text))
                            e.Graphics.DrawString(text, e.Font, fontBrush, bounds.Location, format);
                    }
                    else
                    {
                        using (var boldFont = new Font(e.Font, FontStyle.Bold))
                        {
                            String text = getItemDisplayText(Bindings[e.Index]);
                           
                            if (!string.IsNullOrEmpty(text))
                                e.Graphics.DrawString(text, boldFont, fontBrush, bounds.Location, format);
                        }
                    }
                }
            }
        }
    }
    internal class PropInfo
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}