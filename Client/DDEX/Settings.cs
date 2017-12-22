using Business.DDEXFactory.Intefaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDEX
{
    public class AppSettings : BindableModel
    {
        private AppSettings()
        {
        }
        private static AppSettings instance;
        public static AppSettings GetInstance()
        {
            if (instance == null)
            {
                instance = new AppSettings()
                {
                    NavigationFolderPath = @"",
                    PLineText = @"",
                    LabelName = @"",
                    IndirectContributors = @"Composer;Producer;Lyricist;Arranger",
                    DisplayArtistRoles = @"FeaturedArtist",
                    DeezerRecipientPartyID = @"PADPIDA2011021513H",
                    DeezerRecipientPartyName = @"DEEZER",
                    SenderPartyName = @"",
                    SenderPartyID = @"",
                    PandoraRecipientPartyID = @"PADPIDA20140404055",
                    PandoraRecipientPartyName = @"PANDORA",
                    SoundCloudRecipientPartyID = @"PADPIDA20121010037",
                    SoundCloudRecipientPartyName = @"SOUNDCLOUD"
                };
            }

            return instance;
        }
        public string NavigationFolderPath { get { return Get<string>(); } set { Set(value); } }
        public string PLineText { get { return Get<string>(); } set { Set(value); } }
        public string LabelName { get { return Get<string>(); } set { Set(value); } }
        public string IndirectContributors { get { return Get<string>(); } set { Set(value); } }
        public string DisplayArtistRoles { get { return Get<string>(); } set { Set(value); } }
        public string DeezerRecipientPartyID { get { return Get<string>(); } set { Set(value); } }
        public string DeezerRecipientPartyName { get { return Get<string>(); } set { Set(value); } }
        public string SenderPartyName { get { return Get<string>(); } set { Set(value); } }
        public string SenderPartyID { get { return Get<string>(); } set { Set(value); } }
        public string PandoraRecipientPartyID { get { return Get<string>(); } set { Set(value); } }
        public string PandoraRecipientPartyName { get { return Get<string>(); } set { Set(value); } }
        public string SoundCloudRecipientPartyID { get { return Get<string>(); } set { Set(value); } }
        public string SoundCloudRecipientPartyName { get { return Get<string>(); } set { Set(value); } }

        public static void LoadSettings()
        {
            var regKey = Registry.CurrentUser.OpenSubKey("DDEXEditor");
            if (regKey != null)
            {
                var props = typeof(AppSettings).GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (regKey.GetValueNames().ToList().Contains(p.Name))
                    {
                        p.SetValue(GetInstance(), regKey.GetValue(p.Name));
                    }
                }
                regKey.Close();
            }
        }

        public static void SaveSettings()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey("DDEXEditor");
                var props = typeof(AppSettings).GetProperties();
                foreach (PropertyInfo p in props)
                {
                    string value = (string)p.GetValue(GetInstance());
                    if (value == null) value = "";
                    regKey.SetValue(p.Name, value);
                }
                regKey.Close();
            }
            catch (UnauthorizedAccessException)
            {
                Framework.UI.Forms.MRMessageBox.Show("System unauthorized exception.\nPlease run application in administrator mode.", Framework.UI.Forms.MRMessageBox.eMessageBoxStyle.OK, Framework.UI.Forms.MRMessageBox.eMessageBoxType.Warning);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
