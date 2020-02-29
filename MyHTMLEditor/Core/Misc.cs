using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Controls;

namespace MyHTMLEditor
{
    static class Misc
    {
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

        /// <summary>
        /// Возвращает путь к корневой папке с изображениями, прочитанный из конфигурации приложения.
        /// Если в конфиге папка не указана, то создаётся темповая папка, которая и будет использована для изображений.
        /// Путь к созданной папке записывается в конфиг
        /// </summary>
        public static string GetRootImageDirPath()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            try
            {
                string initialCatalog = configuration.AppSettings.Settings["imagesFolder"].Value;

                if (!Directory.Exists(initialCatalog))
                {
                    configuration.AppSettings.Settings["imagesFolder"].Value = "";
                    throw new Exception();
                }

                return initialCatalog;
            }
            catch
            {
                string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                Directory.CreateDirectory(tempDirectory);

                configuration.AppSettings.Settings.Add("imagesFolder", tempDirectory);
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");

                return tempDirectory;
            }
        }
    }
}
