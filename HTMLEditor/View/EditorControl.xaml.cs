using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HTMLEditor.Core;
using HTMLEditor.ViewModel;

namespace HTMLEditor.View
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorControl : UserControl
    {
        public string EditorsHTML
        {
            get
            {
                return htmlRedactor.GetHTML();
            }
            set
            {
                htmlRedactor.SetHTML(value);
            }
        }

        public string HTMLToSave
        {
            get
            {
                return Misc.GetCorrectHTMLToSave(htmlRedactor.GetHTML());
            }
        }

        public string RootImagesDir
        {
            set
            {
                Misc.ImagesRootDir = value;
            }
        }

        public EditorControl()
        {
            DataContext = new EditorControlViewModel() { TextLayoutAction = TextLayoutRedactAction };

            InitializeComponent();
        }

        private void TextLayoutRedactAction(object parameter)
        {
            if (!(parameter is string))
            {
                return;
            }

            Format.LayoutChange(parameter as string);
        }

        private void paragraphCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gui.FormatCombobox(paragraphCombobox);
        }

        private void fontCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gui.FontsCombobox(fontCombobox);
        }

        private void fontHeightCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gui.FontHeightCombobox(fontHeightCombobox);
        }

        private void Ctrl_Loaded(object sender, RoutedEventArgs e)
        {
            Gui.webBrowser = htmlRedactor;
            Gui.NewDocument();

            fontCombobox.ItemsSource = Fonts.SystemFontFamilies;
            fontCombobox.Text = "Times New Roman";

            paragraphCombobox.ItemsSource = Gui.FormatComboboxData;
            paragraphCombobox.SelectedIndex = 0;

            fontHeightCombobox.ItemsSource = Gui.ComboboxFontSizeData;
            fontHeightCombobox.Text = "3";
        }

        private void SettingsFontColor_Click(object sender, RoutedEventArgs e)
        {
            Gui.SettingsFontColor();
        }

        private void SettingsBackColor_Click(object sender, RoutedEventArgs e)
        {
            Gui.SettingsBackColor();
        }

        private void SettingsAddLink_Click(object sender, RoutedEventArgs e)
        {
            Gui.AddLink();
        }

        private void SettingsAddImage_Click(object sender, RoutedEventArgs e)
        {
            Gui.SettingsAddImage();
        }
    }
}
