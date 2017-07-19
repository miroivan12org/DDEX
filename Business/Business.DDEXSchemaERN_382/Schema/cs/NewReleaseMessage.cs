using Business.DDEXFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DDEXSchemaERN_382.Schema
{
    public partial class NewReleaseMessage : IXmlObject
    {
        public string FullFileName { get; set; }
    }
}
