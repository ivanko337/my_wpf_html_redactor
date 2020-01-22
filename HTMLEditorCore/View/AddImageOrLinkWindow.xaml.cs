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
using mshtml;

namespace HTMLEditorCore.View
{
    /// <summary>
    /// Interaction logic for AddImageOrLinkWindow.xaml
    /// </summary>
    public partial class AddImageOrLinkWindow : Window
    {
        public HTMLDocument doc;
        private bool isImg;

        /// <summary>
        /// </summary>
        /// <param name="isImg">true if you need to add image, and false if you need to add link</param>
        public AddImageOrLinkWindow(HTMLDocument document, bool isImg = true)
        {
            InitializeComponent();

            doc = document;
            this.isImg = isImg;

            if (!isImg)
            {
                label.Content = "Enter a web page location or a local file";
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (doc != null)
            {
                dynamic r = doc.selection.createRange();
                r.pasteHTML(string.Format(isImg ? @"<img alt=""{1}"" src=""{0}"">" : @"<a href='{0}'target=""_blank"">{1}</a>", pathTextBox.Text, descriptionTextBox.Text));
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\";
                openFileDialog.Filter = isImg ? "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|gif files (*.gif)|*.gif|All files (*.*)|*.*" : "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                System.Windows.Forms.DialogResult result = openFileDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    pathTextBox.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
