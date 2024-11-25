using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using Neuron.Configuration;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Neuron.ComponentModel;
using System.Drawing;

namespace Neuron.UI.Configuration
{
    public class BindingExpressionTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            ExpressionBoundProperties bindings = ((ExpressionBoundProperties)value);

            string[] prop = BindingExpressionUITypeEditor.GetPropertyNames(bindings);
            return prop.Length == 0 ? "(No bindable properties)" : "(Collection)";
        }
    }
}
