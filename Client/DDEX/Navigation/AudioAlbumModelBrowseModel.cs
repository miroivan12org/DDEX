using Business.DDEXFactory.Intefaces;
using Business.DDEXSchemaERN_382;
using Business.DDEXSchemaERN_382.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDEX.Navigation
{
    public class AudioAlbumModelBrowseModel: BindableModel
    {
        public string Name { get { return Get<string>(); } set { Set(value); } }
        public string FullName { get { return Get<string>(); } set { Set(value); } }
        public string Extension { get { return Get<string>(); } set { Set(value); } }
        public string DirectoryName { get { return Get<string>(); } set { Set(value); } }
        public DateTime LastWriteTime { get { return Get<DateTime>(); } set { Set(value); } }
        
        public bool IsValid_Materialized { get { return Get<bool>(); } set { Set(value); } }
        public string ValidationMessage { get { return Get<string>(); } set { Set(value); } }
        public long Size { get { return Get<long>(); } set { Set(value); } }

        public override bool IsValid(out string message)
        {
            bool ret = true;
            message = "";
            
            var binder = new AudioAlbumBinder(new AudioAlbumBinder.AudioAlbumBinderSettings() {
                DeezerPartyID = Properties.Settings.Default.DeezerRecipientPartyID,
                PandoraPartyID = Properties.Settings.Default.PandoraRecipientPartyID,
                SoundCloudPartyID = Properties.Settings.Default.SoundCloudRecipientPartyID
            });

            try
            {
                AudioAlbumModel m = (AudioAlbumModel)binder.GetModelFromXmlObject(binder.GetXmlObjectFromFile(FullName));
                string msg = "";
                if (!m.IsValid(out msg) || !binder.IsModelValid(m, out msg))
                {
                    message = msg;
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            ValidationMessage = message;
            IsValid_Materialized = ret;

            return ret;
        }
    }
}
