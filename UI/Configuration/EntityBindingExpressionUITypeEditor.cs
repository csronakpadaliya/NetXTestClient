using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;
using Neuron.ComponentModel;
using System.Drawing;

namespace Neuron.UI.Configuration
{
    public class EntityBindingExpressionUITypeEditor : BindingExpressionUITypeEditor
    {
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ExpressionBoundProperties bindings = ((ExpressionBoundProperties)value);

            EntityBindingExpressionEditorDialog dlg = new EntityBindingExpressionEditorDialog();
            var list = new BindingList<ExpressionBoundProperty>();
            foreach (var binding in bindings)
            {
                list.Add(new ExpressionBoundProperty(binding.PropertyName, binding.Expression));
            }
            dlg.Bindings = list;
            dlg.PropertyInfo = GetPropertyInfo(bindings);

            if (dlg.PropertyInfo.Length == 0)
            {
                MessageBox.Show("There are no bindable properties on this object.", "No bindings", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        // create a new object so any property grids will get the value changed event.
                        bindings = new ExpressionBoundProperties();
                        foreach (var binding in dlg.Bindings) bindings.Add(binding);
                    }
                }
            }
            return bindings;
        }
    }
}
