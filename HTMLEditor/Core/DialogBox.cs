namespace HTMLEditor.Core
{
    public static class DialogBox
    {
        public static System.Windows.Media.Color? Pick()
        {
            System.Windows.Media.Color col = new System.Windows.Media.Color();

            using (System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog())
            {
                colorDialog.AllowFullOpen = true;
                colorDialog.FullOpen = true;
                System.Windows.Forms.DialogResult result = colorDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    col.A = colorDialog.Color.A;
                    col.B = colorDialog.Color.B;
                    col.G = colorDialog.Color.G;
                    col.R = colorDialog.Color.R;
                }
                else
                {
                    return null;
                }
            }

            return col;
        }

        public static string SelectImage()
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Misc.ImagesRootDir;
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|gif files (*.gif)|*.gif|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                openFileDialog.ShowDialog();

                return openFileDialog.FileName;
            }
        }

        public static string SelectHTMLFileToOpen()
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                openFileDialog.ShowDialog();

                return openFileDialog.FileName;
            }
        }

        public static string SaveHTMLFileToSave()
        {
            using (System.Windows.Forms.SaveFileDialog SaveFileDialog = new System.Windows.Forms.SaveFileDialog())
            {
                SaveFileDialog.Filter = "html files (*.html)|*.html";
                SaveFileDialog.FilterIndex = 2;
                SaveFileDialog.RestoreDirectory = true;

                SaveFileDialog.ShowDialog();

                return SaveFileDialog.FileName;
            }
        }

        public static void ShowWarning(string msg)
        {
            System.Windows.MessageBox.Show(msg, "WARNING", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
        }
    }
}
