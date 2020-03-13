using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewProj
{
    public static class Misc
    {
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

        public static void CopyImagesToRootDir()
        {
            string rootImgDir = GetRootImageDirPath();
            string sourceImgDir = "E:\\TEST_IMAGES";

            if (!Directory.Exists(sourceImgDir))
            {
                return;
            }

            DirectoryInfo rootImgDirInfo = new DirectoryInfo(rootImgDir);
            DirectoryInfo sourceImgDirInfo = new DirectoryInfo(sourceImgDir);
            
            try
            {
                CopyAll(sourceImgDirInfo, rootImgDirInfo);
            }
            catch
            {
                System.Windows.MessageBox.Show("Не удалось загрузить картинки");
            }
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
