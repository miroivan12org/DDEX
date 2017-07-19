using Business.DDEXFactory.Interfaces;

namespace Business.DDEXFactory.Generation
{
    public abstract class GenerationFactory: IXmlGenerationFactory
    {
        public abstract IXmlGenerator GetGenerator();
    }
}
