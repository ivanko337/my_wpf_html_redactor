namespace MyHTMLEditor
{
    public static class DialogBox
    {
        public static System.Windows.Media.Color Pick()
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
            }

            return col;
        }

        public static string SelectFile()
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

        public static string SaveFile()
        {
            using (System.Windows.Forms.SaveFileDialog SaveFileDialog = new System.Windows.Forms.SaveFileDialog())
            {
                SaveFileDialog.InitialDirectory = @"C:\";
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
    }
}
