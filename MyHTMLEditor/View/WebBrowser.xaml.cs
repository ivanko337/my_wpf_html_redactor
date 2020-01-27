using mshtml;
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

namespace MyHTMLEditor.View
{
    /// <summary>
    /// Interaction logic for HTMLRedactor.xaml
    /// </summary>
    public partial class MyWebBrowser : UserControl
    {
        public HTMLDocument doc;
        public WebBrowser webBrowser;

        public MyWebBrowser()
        {
            InitializeComponent();
        }

        public void NewWb(string url)
        {
            if (webBrowser != null)
            {
                webBrowser.LoadCompleted -= Completed;
                webBrowser.Dispose();
                htmlReactorGrid.Children.Remove(webBrowser);
            }

            if (doc != null)
            {
                doc.clear();
            }

            webBrowser = new WebBrowser();
            webBrowser.LoadCompleted += Completed;
            htmlReactorGrid.Children.Add(webBrowser);

            Script.HideScriptErrors(webBrowser, true);

            if (url == "")
            {
                string s = Properties.Resources.NewDocument;
                webBrowser.NavigateToString(s);
                doc = webBrowser.Document as HTMLDocument;
                doc.designMode = "On";
                Format.doc = doc;
                return;
            }
            else
            {
                webBrowser.Navigate(url);
            }

            doc = webBrowser.Document as HTMLDocument;
            doc.charset = "utf-8";
            Format.doc = doc;
        }

        private void Completed(object sender, NavigationEventArgs e)
        {
            doc = webBrowser.Document as HTMLDocument;
            doc.designMode = "On";
        }
    }
}
