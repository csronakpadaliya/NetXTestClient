using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.Windows.Controls.SyntaxEditor;
using ActiproSoftware.Windows.Controls.SyntaxEditor.IntelliPrompt.Implementation;

namespace Neuron.UI.Configuration
{
    /// <summary>
    ///     This is copied and pasted from ActiPro samples...
    ///     Interaction logic for EnvironmentVariableSelector.xaml
    /// </summary>
    public partial class BodyAutoCompletionBox
    {
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof (IList),
            typeof (BodyAutoCompletionBox), new PropertyMetadata(new List<string>()));

        public delegate void MenuItemEventHandler(object sender, RoutedEventArgs args);
        public event MenuItemEventHandler OnMenuItemClicked;

        public SyntaxEditor Editor
        {
            get { return editor; }
        }
        public System.Windows.Controls.Primitives.Popup Pop
        {
            get { return pop; }
        }

        public BodyAutoCompletionBox()
        {
            InitializeComponent();
            Items = new List<string>();

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
            CommandManager.RegisterClassCommandBinding(typeof (BodyAutoCompletionBox), commandBinding);
            editor.Document.SetText("");
        }

        public IList Items
        {
            get { return (IList) GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public string Text
        {
            get
            {
                return this.editor.Text;
            }

            set
            {
                this.editor.Text = value;
            }
        }

        public bool ShowLineNumbers
        {
            get
            {
                return this.editor.IsLineNumberMarginVisible;
            }

            set
            {
                this.editor.IsLineNumberMarginVisible = value;
            }
        }
        public void CopyToClipboard()
        {
            this.editor.ActiveView.CopyToClipboard();
        }

        public void PasteFromClipboard()
        {
            this.editor.ActiveView.PasteFromClipboard();
        }
        private void MenuItemLoadBody_Click(object sender, RoutedEventArgs e)
        {
            if (OnMenuItemClicked != null)
                OnMenuItemClicked(this, e);
        }
        private void MenuItemSaveBody_Click(object sender, RoutedEventArgs e)
        {
            if (OnMenuItemClicked != null)
                OnMenuItemClicked(this, e);
        }

        public void FormatDocument()
        {
            EditorCommands.FormatDocument.Execute(null, this.editor);
        }

        public void FormatSelection()
        {
            EditorCommands.FormatSelection.Execute(null, this.editor);
        }

        public void Indent()
        {
            EditorCommands.Indent.Execute(null, this.editor);
        }

        public void Outdent()
        {
            EditorCommands.Outdent.Execute(null, this.editor);
        }

        private void MenuItemFormat_Click(object sender, RoutedEventArgs e)
        {
            if (OnMenuItemClicked != null)
                OnMenuItemClicked(this, e);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            pop.Visibility = System.Windows.Visibility.Visible;
            pop.IsOpen = true;
            pop.StaysOpen = true;

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            pop.Visibility = System.Windows.Visibility.Hidden;
            pop.IsOpen = false;
            pop.StaysOpen = false;
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
            var control = sender as BodyAutoCompletionBox;
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
            // The items for this completion lisytwsx    t are hardcoded in this sample and
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

            foreach (var environmentVariable in Items)
            {
                session.Items.Add(new CompletionItem(environmentVariable.ToString(),
                    new CommonImageSourceProvider(CommonImageKind.PropertyPublic)));
            }
            session.Open(editor.ActiveView);
        }
    }
}