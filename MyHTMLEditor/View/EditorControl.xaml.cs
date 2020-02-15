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

namespace MyHTMLEditor.View
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorControl : UserControl
    {
        private bool isFileSaved = false;

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


        public EditorControl()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            Gui.NewDocumentFile();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            isFileSaved = Gui.ButtonSave();
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

        private void SettingsBold_Click(object sender, RoutedEventArgs e)
        {
            Format.Bold();
        }

        private void SettingsItalic_Click(object sender, RoutedEventArgs e)
        {
            Format.Italic();
        }

        private void SettingsUnderLine_Click(object sender, RoutedEventArgs e)
        {
            Format.Underline();
        }

        private void SettingsRightAlign_Click(object sender, RoutedEventArgs e)
        {
            Format.Underline();
        }

        private void SettingsLeftAlign_Click(object sender, RoutedEventArgs e)
        {
            Format.JustifyLeft();
        }

        private void SettingsCenter2_Click(object sender, RoutedEventArgs e)
        {
            Format.JustifyCenter();
        }

        private void SettingsJustifyRight_Click(object sender, RoutedEventArgs e)
        {
            Format.JustifyRight();
        }

        private void SettingsJustifyFull_Click(object sender, RoutedEventArgs e)
        {
            Format.JustifyFull();
        }

        private void SettingsInsertOrderedList_Click(object sender, RoutedEventArgs e)
        {
            Format.InsertOrderedList();
        }

        private void SettingsBullets_Click(object sender, RoutedEventArgs e)
        {
            Format.InsertUnorderedList();
        }

        private void SettingsOutIdent_Click(object sender, RoutedEventArgs e)
        {
            Format.Outdent();
        }

        private void SettingsIdent_Click(object sender, RoutedEventArgs e)
        {
            Format.Indent();
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
            Gui.SettingsAddLink();
        }

        private void SettingsAddImage_Click(object sender, RoutedEventArgs e)
        {
            Gui.SettingsAddImage();
        }
    }
}
