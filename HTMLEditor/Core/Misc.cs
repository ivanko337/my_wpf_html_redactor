using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HTMLEditor.Core
{
    public static class Misc
    {
        public static string ImagesRootDir { get; set; }

        public static void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo FieldInfoComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);

            if (FieldInfoComWebBrowser == null)
            {
                return;
            }

            object ComWebBrowser = FieldInfoComWebBrowser.GetValue(wb);

            if (ComWebBrowser == null)
            {
                return;
            }

            ComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, ComWebBrowser, new object[] { Hide });
        }

        public static string GetCorrectHTMLData(string html)
        {
            string rootImagesDir = ImagesRootDir;
            string newHtml = html.Replace("$rootImagesDir$", rootImagesDir.Replace("\\", "/"));

            return newHtml;
        }

        private static string ReplaceWidthAndHeightFromImages(string html)
        {
            var imgMatches = Regex.Matches(html, "<IMG[a-zA-zА-Яа-я\\s\\d\\W]+>$");
            
            for (int i = 0; i < imgMatches.Count; ++i)
            {
                string match = imgMatches[i].Value.Clone().ToString();

                match = Regex.Replace(match, "\\s*width=\\d{0,}\\s*", "");
                match = Regex.Replace(match, "\\s*height=\\d{0,}\\s*", "");
                html = html.Replace(imgMatches[i].Value, match);
            }

            return html;
        }

        private static string CorrectReplaceRootImgDir(string html)
        {
            StringBuilder sb = new StringBuilder(html);

            while (true)
            {
                int index = sb.IndexOf(ImagesRootDir.Replace("\\", "/"), ignoreCase: true);

                if (index == -1)
                {
                    break;
                }

                sb.Remove(index, ImagesRootDir.Length);
                sb.Insert(index, "$rootImagesDir$");
            }

            return sb.ToString();
        }

        public static string GetCorrectHTMLToSave(string html)
        {
            //string imagesRootDir = ImagesRootDir;

            //html = html.Replace(imagesRootDir.Replace("\\", "/"), "$rootImagesDir$");
            html = CorrectReplaceRootImgDir(html);

            html = ReplaceWidthAndHeightFromImages(html);

            return html;
        }
    }
}
