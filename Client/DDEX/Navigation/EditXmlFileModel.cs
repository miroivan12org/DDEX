using Business.DDEXFactory.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDEX.Navigation
{
    public class EditXmlFileModel: BindableModel
    {
        public string Name { get { return Get<string>(); } set { Set(value); } }
        public string FullName { get { return Get<string>(); } set { Set(value); } }
        public string Extension { get { return Get<string>(); } set { Set(value); } }
        public string DirectoryName { get { return Get<string>(); } set { Set(value); } }
        public DateTime LastWriteTime { get { return Get<DateTime>(); } set { Set(value); } }

        public override bool IsValid(out string message)
        {
            bool ret = true;
            message = "";
            
            return ret;
        }
    }
}
