﻿using Business.DDEXFactory.Intefaces;
using Business.DDEXSchemaERN_382.BindingObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDEX.Navigation
{
    public class NavigationModel: BindableModel
    {
        
        public string FolderPath { get { return Get<string>(); } set { Set(value); } }
        public bool ScanSubFolders { get { return Get<bool>(); } set { Set(value); } }
        public SortableBindingList<AudioAlbumModelBrowseModel> Files { get; set; } = new SortableBindingList<AudioAlbumModelBrowseModel>();

        public void Refresh()
        {
            Files.Clear();
            if (FolderPath != null && FolderPath != string.Empty)
            {
                if (Directory.Exists(FolderPath))
                {
                    DirectoryInfo d = new DirectoryInfo(FolderPath);

                    var so = SearchOption.TopDirectoryOnly;
                    if (ScanSubFolders) so = SearchOption.AllDirectories;
                    try
                    {
                        FileInfo[] files = d.GetFiles("*.xml", so);

                        foreach (var f in files)
                        {
                            var file = new AudioAlbumModelBrowseModel()
                            {
                                FullName = f.FullName,
                                Extension = f.Extension,
                                DirectoryName = f.DirectoryName,
                                Name = f.Name,
                                LastWriteTime = f.LastWriteTime
                            };

                            string msg = "";
                            file.IsValid(out msg);

                            long len = 0;
                            if (File.Exists(file.FullName))
                            {
                                len = (new FileInfo(file.FullName)).Length;
                            }
                            file.Size = len;

                            Files.Add(file);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Framework.UI.Forms.MRMessageBox.Show("System unauthorized exception.\nPlease choose a folder which can be read including subfolders.", Framework.UI.Forms.MRMessageBox.eMessageBoxStyle.OK, Framework.UI.Forms.MRMessageBox.eMessageBoxType.Warning);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
