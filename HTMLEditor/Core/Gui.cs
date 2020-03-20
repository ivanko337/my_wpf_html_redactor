using mshtml;
using HTMLEditor.View;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System;

namespace HTMLEditor.Core
{
    public static class Gui
    {
        public static WebBrowserCtrl webBrowser;

        public static List<ComboBoxItem> FormatComboboxData
        {
            get
            {
                List<ComboBoxItem> list = new List<ComboBoxItem>();
                list.Add(new ComboBoxItem("<p>", "Paragraph"));
                list.Add(new ComboBoxItem("<h1>", "Heading 1"));
                list.Add(new ComboBoxItem("<h2>", "Heading 2"));
                list.Add(new ComboBoxItem("<h3>", "Heading 3"));
                list.Add(new ComboBoxItem("<h4>", "Heading 4"));
                list.Add(new ComboBoxItem("<h5>", "Heading 5"));
                list.Add(new ComboBoxItem("<h6>", "Heading 6"));
                list.Add(new ComboBoxItem("<pre>", "Preformat"));
                return list;
            }
        }

        public static List<string> ComboboxFontSizeData
        {
            get
            {
                List<string> items = new List<string>();

                for (int x = 1; x <= 7; x++)
                {
                    items.Add(x.ToString());
                }

                return items;
            }
        }

        public static void SelectFontColor()
        {
            webBrowser.doc = webBrowser.webBrowser.Document as HTMLDocument;
            if (webBrowser.doc != null)
            {
                System.Windows.Media.Color? col = DialogBox.Pick();

                if (col == null)
                {
                    return;
                }

                string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", col.Value.R, col.Value.G, col.Value.B);
                webBrowser.doc.execCommand("ForeColor", false, colorstr);
            }
        }

        public static void SelectBackColor()
        {
            webBrowser.doc = webBrowser.webBrowser.Document as HTMLDocument;
            if (webBrowser.doc != null)
            {
                System.Windows.Media.Color? col = DialogBox.Pick();

                if (col == null)
                {
                    return;
                }

                string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", col.Value.R, col.Value.G, col.Value.B);
                webBrowser.doc.body.style.background = colorstr;
            }
        }

        private static void PasteHTML(string data)
        {
            dynamic r = webBrowser.doc.selection.createRange();
            r.pasteHTML(data);
        }

        private static void AddUrl(string pattern, string url, string alt)
        {
            if (!string.IsNullOrEmpty(pattern) && !string.IsNullOrEmpty(url))
            {
                string linkStr = string.Format(pattern, url, alt);
                PasteHTML(linkStr);
            }
        }

        public static void AddLink(string url, string alt)
        {
            AddUrl(@"<a href='{0}'target=""_blank"">{1}</a>", url, alt);
        }

        public static void AddImage(string url, string alt)
        {
            AddUrl(@"<img alt=""{1}"" src=""{0}"">", url, alt); // width=100% height=100% //style=""HEIGHT: auto; WIDTH: auto""
        }

        public static void SelectFont(ComboBox fontsCombobox)
        {
            var doc = webBrowser.webBrowser.Document as HTMLDocument;
            if (doc != null)
            {
                doc.execCommand("FontName", false, fontsCombobox.SelectedItem.ToString());
            }
        }

        public static void SelectFontSize(ComboBox fontHeightCombobox)
        {
            IHTMLDocument2 doc = webBrowser.webBrowser.Document as IHTMLDocument2;
            if (doc != null)
            {
                doc.execCommand("FontSize", false, fontHeightCombobox.SelectedItem);
            }
        }

        public static void SelectFormat(ComboBox formatCombobox)
        {
            string id = ((ComboBoxItem)(formatCombobox.SelectedItem)).Id;

            webBrowser.doc = webBrowser.webBrowser.Document as HTMLDocument;
            if (webBrowser.doc != null)
            {
                webBrowser.doc.execCommand("FormatBlock", false, id);
            }
        }

        public static void NewDocument()
        {
            webBrowser.NewWb("", Format.doc);
        }
    }
}
