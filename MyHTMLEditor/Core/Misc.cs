using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Controls;

namespace MyHTMLEditor
{
    static class Misc
    {
        /// <summary>
        /// Корневая папка для изображений
        /// </summary>
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

        public static string GetCorrectHTMLToSave(string html)
        {
            string imagesRootDir = ImagesRootDir;
            return html.Replace(imagesRootDir.Replace("\\", "/"), "$rootImagesDir$");
        }
    }
}
