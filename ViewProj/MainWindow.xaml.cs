using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HTMLEditor.View;
using System.IO;
using HTMLEditor.Core;

namespace ViewProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Gui.GetImageFunc = GetImage;
            Gui.GetLinkFunc = GetLink;
        }

        private string SelectHTMLFile()
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                System.Windows.Forms.DialogResult result = openFileDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }

                return "";
            }
        }

        private string SelectHTMLFileToSave()
        {
            using (System.Windows.Forms.SaveFileDialog SaveFileDialog = new System.Windows.Forms.SaveFileDialog())
            {
                //SaveFileDialog.InitialDirectory = @"C:\";
                SaveFileDialog.Filter = "html files (*.html)|*.html";
                SaveFileDialog.FilterIndex = 2;
                SaveFileDialog.RestoreDirectory = true;

                if (SaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    return SaveFileDialog.FileName;
                }
                return "";
            }
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = SelectHTMLFile();
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            string htmlData = File.ReadAllText(filePath);

            editorControl.EditorsHTML = htmlData;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = SelectHTMLFileToSave();
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            File.WriteAllText(filePath, editorControl.HTMLToSave);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            editorControl.RootImagesDir = Misc.GetRootImageDirPath();
            Misc.CopyImagesToRootDir();
        }

        private UrlToInsert GetUrl(bool isImage)
        {
            AddPictureOrLinkWindow wnd = new AddPictureOrLinkWindow(isImage);

            if (!wnd.ShowDialog().Value)
            {
                return null;
            }

            return new UrlToInsert()
            {
                ResultAlt = wnd.ResultAlt,
                ResultUrl = wnd.ResultPath
            };
        }

        public UrlToInsert GetImage()
        {
            return GetUrl(true);
        }

        public UrlToInsert GetLink()
        {
            return GetUrl(false);
        }
    }
}
