using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using Neuron.Configuration;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Neuron.ComponentModel;
using System.Drawing;
using Neuron.Explorer;

namespace Neuron.UI.Configuration
{
    public class BindingExpressionUITypeEditor : UITypeEditor
    {        
        public static string[] GetPropertyNames(ExpressionBoundProperties bindings )
        {            
            return (from b in bindings.Parent.GetType().GetProperties()
             where (b.GetCustomAttributes(typeof(BindableAttribute), true)
             .OfType<BindableAttribute>().FirstOrDefault() ?? new BindableAttribute(true)).Bindable
             select b.Name).ToArray();
        }

        public static PropertyInfo[] GetPropertyInfo(ExpressionBoundProperties bindings)
        {
            return (from b in bindings.Parent.GetType().GetProperties()
                    where (b.GetCustomAttributes(typeof(BindableAttribute), true)
                    .OfType<BindableAttribute>().FirstOrDefault() ?? new BindableAttribute(true)).Bindable
                    select b).ToArray<PropertyInfo>();
        }
 
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ExpressionBoundProperties bindings = ((ExpressionBoundProperties)value);

            EntityBindingExpressionEditorDialog dlg = new EntityBindingExpressionEditorDialog();
            dlg.StartedOnPrimaryScreen = ResizeUtil.StartedOnPrimaryScreen;
            dlg.DpiScalingValue = ResizeUtil.DpiScalingValue == 0 ? 1 : ResizeUtil.DpiScalingValue;
            ResizeUtil.ScaleAll(dlg);
            dlg.lstBindings.ItemHeight = (int)(dlg.lstBindings.ItemHeight * (ResizeUtil.DpiScalingValue == 0 ? 1 : ResizeUtil.DpiScalingValue));
            var list = new BindingList<ExpressionBoundProperty>();
            foreach (var binding in bindings)
            {
                list.Add(new ExpressionBoundProperty(binding.PropertyName, binding.Expression));
            }
            dlg.Bindings = list;
            dlg.PropertyInfo = GetPropertyInfo(bindings);

            if (dlg.PropertyInfo.Length == 0)
            {
                MessageBox.Show("There are no bindable properties on this object.", 
                    "No bindings", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            else
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Attempt to determine if the list has actually changed.
                    bool listChanged = false;
                    if (dlg.Bindings.Count != bindings.Count) listChanged = true;
                    else
                    {
                        // Check and make sure every value in the new list can be found in the original list.
                        foreach (ExpressionBoundProperty prop in dlg.Bindings)
                        {
                            if (!bindings.Any<ExpressionBoundProperty>(x => prop.PropertyName == x.PropertyName && prop.Expression == x.Expression))
                            {
                                listChanged = true;
                                break;
                            }
                        }
                    }

                    if (listChanged == true)
                    {
                        PropertyInfo ownerGridProperty = provider.GetType().GetProperty("OwnerGrid", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                        var ownerGrid = (PropertyGrid)ownerGridProperty.GetValue(provider);

                        /// <summary>
                        /// Hack used to detect changes in the BindingExpressionUITypeEditor. When values change, we change the 
                        /// Property Grid text property to an empty string. this triggers the Property Grid's Text change event
                        /// where we then do a refresh on the property grid. This way, the apply button will be enabled when 
                        /// users change a bindings property. Refreshing the property grid within the editor has no effect.
                        /// </summary>
                        ownerGrid.Text = "";

                        bindings.Clear();
                        foreach (var binding in dlg.Bindings)
                            bindings.Add(binding);
                       
                        return bindings;
                    }
                }
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
}
