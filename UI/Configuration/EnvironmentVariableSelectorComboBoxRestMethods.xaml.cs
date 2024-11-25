using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Neuron.UI.Configuration
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class EnvironmentVariableSelectorComboBoxRestMethods : UserControl
    {
        public string SelectedHttpMethod
        {
            get { return HttpMethod.Text; }

            set
            {
                HttpMethod.Text = value;
            }
        }

        private readonly ObservableCollection<string> environmentVariables = new ObservableCollection<string>();
        public EnvironmentVariableSelectorComboBoxRestMethods()
        {

            InitializeComponent();
        }
        private void HttpMethod_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            HttpMethod.IsDropDownOpen = true;
        }
        public IEnumerable<string> HttpMethods
        {
            get
            {
                return new List<string>
            {
                "CONNECT",
                "COPY",                
                "GET",
                "DELETE",
                "HEAD",
                "LOCK",
                "MKCOL",
                "MOVE",
                "OPTIONS",
                "PATCH",
                "POST",
                "PROPFIND",
                "PROPPATCH",
                "PUT",
                "SEARCH",
                "TRACE",
                "UNLOCK"
            };
            }
        }
    }
}
