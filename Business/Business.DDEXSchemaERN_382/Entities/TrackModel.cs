using Business.DDEXFactory.Intefaces;
using System;

namespace Business.DDEXSchemaERN_382.Entities
{
    public class TrackModel: BindableModel
    {
        // track release
        public int Ordinal{ get { return Get<int>(); } set { Set(value); } }      
        public string ISRC { get { return Get<string>(); } set { Set(value); } }
        public string Title { get { return Get<string>(); } set { Set(value); } }

        // soundrecording
        public string Genre { get { return Get<string>(); } set { Set(value); } }
        public string SubGenre { get { return Get<string>(); } set { Set(value); } }
        public override bool IsValid(out string message)
        {
            return base.IsValid(out message);
        }
    }
}
