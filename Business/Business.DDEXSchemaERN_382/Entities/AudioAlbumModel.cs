using Business.DDEXFactory.Intefaces;
using Business.DDEXSchemaERN_382.BindingObjects;
using Business.DDEXSchemaERN_382.Schema;
using System;
using System.ComponentModel;

namespace Business.DDEXSchemaERN_382.Entities
{
    
    public class AudioAlbumModel: BindableModel
    {
        public AudioAlbumModel()
        {
            MessageCreatedDateTime = DateTime.Now;
        }
        public string FullFileName { get { return Get<string>(); } set { Set(value); } }
        public string EAN { get { return Get<string>(); } set { Set(value); } }
        public string MessageID { get { return Get<string>(); } set { Set(value); } }
        public string SenderPartyID { get { return Get<string>(); } set { Set(value); } }
        public string SenderPartyName { get { return Get<string>(); } set { Set(value); } }
        public string RecipientPartyID { get { return Get<string>(); } set { Set(value); } }
        public string RecipientPartyName { get { return Get<string>(); } set { Set(value); } }
        public DateTime MessageCreatedDateTime { get { return Get<DateTime>(); } set { Set(value); } }
        public UpdateIndicator UpdateIndicator { get { return Get<UpdateIndicator>(); } set { Set(value); } }
        public string MainReleaseReferenceTitle { get { return Get<string>(); } set { Set(value); } }

        public SortableBindingList<TrackModel> Tracks { get; set; } = new SortableBindingList<TrackModel>();
    }
}
