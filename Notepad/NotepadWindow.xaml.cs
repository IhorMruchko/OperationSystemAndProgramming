using Notepad.InputHadlers;
using OperationSystemAndProgrammingLIB;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Notepad
{
    public partial class NotepadWindow : Window
    {
        private int _savedTextHash;
        private string _lastFileOpenned = string.Empty;
        private Encoding _encoding = _possibleEncodings[nameof(Encoding.Unicode)];
        
        private static readonly Dictionary<string, Encoding> _possibleEncodings = new()
        { 
            [nameof(Encoding.Unicode)] = new UnicodeEncoding(false, false),
            [nameof(Encoding.ASCII)] = Encoding.ASCII,
            [nameof(Encoding.UTF8)] = new UTF8Encoding(false),
            [nameof(Encoding.Latin1)] = Encoding.Latin1,
            [nameof(Encoding.UTF32)] = Encoding.UTF32,
        };

        public NotepadWindow()
        {
            InitializeComponent();
            InitializeEncoding();
        }
        public string LastFileOpenned
        {
            get => _lastFileOpenned;
            set
            {
                _lastFileOpenned = value;
                OpenFile();
                SavedTextHash = TextContainer.Text.GetHashCode();
            }
        }

        public int SavedTextHash
        {
            get => _savedTextHash;
            set
            {
                _savedTextHash = value;
                Title = Constants.App.NOTEPAD_TITLE;
            }
        }

        internal void OpenFile()
        {
            if (File.Exists(_lastFileOpenned) == false)
            {
                TextContainer.Clear();
                SavedTextHash = TextContainer.Text.GetHashCode();
                return;
            }
            TextContainer.Text = File.ReadAllText(_lastFileOpenned, _encoding);
        }

        internal void SaveFile()
        {
            if (File.Exists(_lastFileOpenned) == false)
            {
                KeyHandlersAccessor.GetHandler(nameof(SaveFileAsKeyEventHandler))?.HadleEvent(this);
                return;
            }
            File.WriteAllText(_lastFileOpenned, TextContainer.Text, _encoding);
            SavedTextHash = TextContainer.Text.GetHashCode();
        }

        internal void SaveFileAs(string saveFileName)
        {
            File.WriteAllText(saveFileName, TextContainer.Text, _encoding);
            SavedTextHash = TextContainer.Text.GetHashCode();
            LastFileOpenned = saveFileName;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var handler = KeyHandlersAccessor.GetHandler(e);
            if (handler is null)
            {
                return;
            }
            handler.HadleEvent(this, e);
            e.Handled = true;
        }
        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
            => KeyHandlersAccessor.GetHandler(nameof(CreateNewFileKeyEventHandler))?.HadleEvent(this);

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e) 
            => KeyHandlersAccessor.GetHandler(nameof(OpenFileKeyEventHandler))?.HadleEvent(this);

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e) 
            => KeyHandlersAccessor.GetHandler(nameof(SaveFileKeyEventHandler))?.HadleEvent(this);

        private void SaveAsMenuItem_Click(object sender, RoutedEventArgs e) 
            => KeyHandlersAccessor.GetHandler(nameof(SaveFileAsKeyEventHandler))?.HadleEvent(this);

        private void FontMenuItem_Click(object sender, RoutedEventArgs e)
            => KeyHandlersAccessor.GetHandler(nameof(FontChangerKeyEventHandler))?.HadleEvent(this);

        private void ColorMenuItem_Click(object sender, RoutedEventArgs e)
            => KeyHandlersAccessor.GetHandler(nameof(ColorChangeKeyEventHandler))?.HadleEvent(this);

        private void ZoomInMenuItem_Click(object sender, RoutedEventArgs e)
            => KeyHandlersAccessor.GetHandler(nameof(IncreaseFontSizeKeyEventHandler))?.HadleEvent(this);

        private void ZoomOutMenuItem_Click(object sender, RoutedEventArgs e)
            => KeyHandlersAccessor.GetHandler(nameof(DecreaseFontSizeKeyEventHandler))?.HadleEvent(this);

        private void TextContainer_TextChanged(object sender, TextChangedEventArgs e)
        {
           Title = SavedTextHash.Equals(TextContainer.Text.GetHashCode()) 
                ? Constants.App.NOTEPAD_TITLE
                : Constants.App.NOTEPAD_TITLE_MODIFIED;
        }

        private void InitializeEncoding()
        {
            foreach (var encoding in _possibleEncodings.Keys)
            {
                var item = new MenuItem()
                {
                    Header = encoding,
                };
                item.Click += ChangeEncoding;
                EncodingMenuItem.Items.Add(item);
            }
        }

        private void ChangeEncoding(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.Header is string header)
                _encoding = _possibleEncodings[header];                
            
            OpenFile();
        }
    }
}
