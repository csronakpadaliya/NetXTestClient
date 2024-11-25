namespace Neuron.UI.Configuration
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using ActiproSoftware.Text.Implementation;
    using ActiproSoftware.Windows.Controls.SyntaxEditor;
    using ActiproSoftware.Windows.Controls.SyntaxEditor.IntelliPrompt.Implementation;
    using Neuron.ComponentModel;

    /// <summary>
    /// This is copied and pasted from ActiPro samples...    
    /// Interaction logic for EnvironmentVariableSelector.xaml
    /// </summary>
    public partial class EnvironmentVariableSelectorRouting
    {
        private readonly ObservableCollection<string> environmentVariables = new ObservableCollection<string>();

        public ExpressionBoundProperty SelectedBinding { get; set; }

        public SyntaxEditor Editor
        {
            get
            {
                return editor;
            }
        }

        public string Watermark
        {
            get
            {
                return watermark.Text;
            }
            set
            {
                watermark.Text = value;
               
            }
        }
        public EnvironmentVariableSelectorRouting()
        {
            InitializeComponent();

            // these make the white left hand margin disappear
            editor.IsOutliningMarginVisible = false;
            editor.IsSelectionMarginVisible = false;
            editor.IsIndicatorMarginVisible = false;
            editor.IsLineNumberMarginVisible = false;
            editor.Document.TabSize = 1;

            // Load a language from a language definition
            editor.Document.Language = SyntaxLanguage.PlainText;

            // New EditActionData() With {.Category = IntelliPromptCategory, .Action = New RequestIntelliPromptAutoCompleteAction()}, 
            for (var index = editor.CommandBindings.Count - 1; index >= 0; index--)
            {
                if (editor.CommandBindings[index].Command == EditorCommands.RequestIntelliPromptAutoComplete)
                    editor.CommandBindings.RemoveAt(index);
            }

            // Register class command bindings
            var commandBinding = new CommandBinding(
                EditorCommands.RequestIntelliPromptAutoComplete,
                OnRequestIntelliPromptAutoCompleteExecuted);
            CommandManager.RegisterClassCommandBinding(typeof(EnvironmentVariableSelectorRouting), commandBinding);
            editor.DocumentTextChanged += this.editor_DocumentTextChanged;
            editor.Text = null;
        }

        public IEnumerable<string> EnvironmentVariables
        {
            get
            {
                return this.environmentVariables;
            }
        }

        public void SetEnvironmentVariables(IEnumerable<string> vars)
        {
            this.environmentVariables.Clear();
            foreach (var variable in vars)
            {
                this.environmentVariables.Add(variable);
            }
        }

        void editor_DocumentTextChanged(object sender, EditorSnapshotChangedEventArgs e)
        {
            if (SelectedBinding != null)
            {
                SelectedBinding.Expression = editor.Text ;
            }

            watermark.Visibility = !string.IsNullOrEmpty(editor.Text) ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // NON-PUBLIC PROCEDURES
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        ///     Occurs when the <see cref="RoutedCommand" /> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs" /> that contains the event data.</param>
        private static void OnRequestIntelliPromptAutoCompleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var control = sender as EnvironmentVariableSelectorRouting;
            control.ShowCompletionList(true);

        }

        /// <summary>
        ///     Shows a mocked-up completion list.
        /// </summary>
        /// <param name="allowAutoComplete">
        ///     Whether to allow an immediate auto-complete without showing the popup if there is a
        ///     single match.
        /// </param>
        private void ShowCompletionList(bool allowAutoComplete)
        {
            // Ensure the editor has focus
            editor.Focus();

            //
            // IMPORTANT NOTE:
            // The items for this completion list are hardcoded in this sample and
            // are simply meant to illustrate the rich features of the SyntaxEditor completion list.
            // When implementing a real language, you should vary the items based
            // on the current context of the caret.
            //

            // Create a session
            var session = new CompletionSession();
            session.AllowedCharacters.Add('.');
            session.CanCommitWithoutPopup = allowAutoComplete;

            // Insert the custom completion item matcher as the second thing in the list so that starts-with continues to match first
            session.ItemMatchers.Insert(1, new CustomCompletionItemMatcher());
            session.ControlKeyDownOpacity = 1.0;

            foreach (var environmentVariable in this.environmentVariables)
            {
                session.Items.Add(new CompletionItem(environmentVariable,
                    new CommonImageSourceProvider(CommonImageKind.PropertyPublic)));
            }
            session.Open(editor.ActiveView);
        }

    }
}
