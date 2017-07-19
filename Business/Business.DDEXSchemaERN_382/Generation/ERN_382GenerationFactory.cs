using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DDEXFactory.Interfaces;
using Business.DDEXFactory.Generation;

namespace Business.DDEXSchemaERN_382.Generation
{
    public class ERN_382GenerationFactory : GenerationFactory
    {    
        public override IXmlGenerator GetGenerator()
        {
            return new ERN_382Generator(this);
        }
    }
}
