using Business.DDEXSchemaERN_382.BindingObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDEX.Navigation
{
    public class NavigationModel
    {
        private string folderPath = string.Empty;
        public string FolderPath
        {
            get
            {
                return folderPath;
            }
            set
            {
                if (folderPath != value)
                {
                    folderPath = value;
                    Globals.LoadNavigation();
                }
            }
        }
        public SortableBindingList<EditXmlFileModel> Files { get; set; } = new SortableBindingList<EditXmlFileModel>();
    }
}
