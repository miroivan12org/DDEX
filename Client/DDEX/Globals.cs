using DDEX.Navigation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDEX
{
    public static class Globals
    {
        public static Form MDIMainForm { get; set; }
        public static NavigationModel Model { get; set; } = new NavigationModel();
        public static void LoadNavigation()
        {
            //string navigation = System.IO.File.ReadAllText(Properties.Settings.Default.NavigationFileName);
            //Model = JsonConvert.DeserializeObject<NavigationModel>(navigation);
            if (Model != null)
            {
                Model.Files.Clear();
                if (Model.FolderPath != null && Model.FolderPath != string.Empty)
                {
                    if (Directory.Exists(Model.FolderPath))
                    {
                        DirectoryInfo d = new DirectoryInfo(Model.FolderPath);
                        FileInfo[] Files = d.GetFiles("*.xml");

                        foreach (var f in Files)
                        {
                            var file = new EditXmlFileModel() {
                                FullName = f.FullName,
                                Extension = f.Extension,
                                DirectoryName = f.DirectoryName,
                                Name = f.Name,
                                LastWriteTime = f.LastWriteTime
                            };
                            Model.Files.Add(file);
                        }
                    }
                }
            }
            
        }

        public static void SaveNavigation()
        {
            //string navigation = JsonConvert.SerializeObject(Model);
            //System.IO.File.WriteAllText(Properties.Settings.Default.NavigationFileName, navigation);
        }
    }
}
