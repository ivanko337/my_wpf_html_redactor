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
using MyHTMLEditor;
using System.IO;

namespace MyHTMLEditor.View
{
    /// <summary>
    /// Interaction logic for WebBrowserControl.xaml
    /// </summary>
    public partial class WebBrowserCtrl : UserControl
    {
        public HTMLDocument doc;
        public WebBrowser webBrowser;

        public WebBrowserCtrl()
        {
            InitializeComponent();
        }

        public void SetHTML(string html)
        {
            NewWb("", Format.doc, html);
        }

        public string GetHTML()
        {
            return this.doc.documentElement.innerHTML;
        }

        public void NewWb(string path, HTMLDocument formatDoc, string htmlData = null)
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

            Misc.HideScriptErrors(webBrowser, true);

            if (path != "")
            {
                htmlData = File.ReadAllText(path);
            }

            if (htmlData != null)
            {
                htmlData = Misc.GetCorrectHTMLData(htmlData);
            }

            webBrowser.NavigateToString(htmlData ?? Properties.Resources.NewDocument);
            doc = webBrowser.Document as HTMLDocument;
            doc.designMode = "On";
            doc.charset = "utf-8";
            formatDoc = doc;
            Format.doc = doc;
        }

        private void Completed(object sender, NavigationEventArgs e)
        {
            doc = webBrowser.Document as HTMLDocument;
            doc.designMode = "On";
        }
    }
}
