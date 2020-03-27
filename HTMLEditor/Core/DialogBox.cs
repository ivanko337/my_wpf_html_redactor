using System.Windows.Forms;

namespace HTMLEditor.Core
{
    public static class DialogBox
    {
        public static System.Windows.Media.Color? Pick()
        {
            System.Windows.Media.Color col = new System.Windows.Media.Color();

            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AllowFullOpen = true;
                colorDialog.FullOpen = true;
                DialogResult result = colorDialog.ShowDialog();

                if (result == DialogResult.OK)
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

        private static bool CheckFileDir(string path)
        {
            return path.StartsWith(Misc.ImagesRootDir, System.StringComparison.OrdinalIgnoreCase);
        }

        public static string SelectImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|gif files (*.gif)|*.gif|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                string filePath = "";
                bool isFileDirCoorect = true;
                do
                {
                    if (!isFileDirCoorect)
                    {
                        ShowWarning("Вы не можете выбрать изображение из данной папки");
                    }

                    openFileDialog.InitialDirectory = Misc.ImagesRootDir;
                    openFileDialog.FileName = "";
                    
                    if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    {
                        return "";
                    }

                    filePath = openFileDialog.FileName;
                    isFileDirCoorect = CheckFileDir(filePath);
                } while (!isFileDirCoorect);

                return filePath;
            }
        }

        /*
        public static string SelectHTMLFileToOpen()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                openFileDialog.ShowDialog();

                return openFileDialog.FileName;
            }
        }

        public static string SaveHTMLFileToSave()
        {
            using (SaveFileDialog SaveFileDialog = new SaveFileDialog())
            {
                SaveFileDialog.Filter = "html files (*.html)|*.html";
                SaveFileDialog.FilterIndex = 2;
                SaveFileDialog.RestoreDirectory = true;

                SaveFileDialog.ShowDialog();

                return SaveFileDialog.FileName;
            }
        }
        */

        public static void ShowWarning(string msg)
        {
            System.Windows.MessageBox.Show(msg, "WARNING", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
        }
    }
}
