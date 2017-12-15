namespace Business.DDEXFactory.Interfaces
{
    public interface IXmlGenerator
    {
        string SerializeXmlObject(IXmlObject value);
        IXmlObject DeserializeXmlObject(string value);
        bool IsValid(string xmlValue, out string outMessage);
        IXmlGenerationFactory Factory { get; }
        string LoadXmlFile(string fileName);
        void WriteXmlFile(string fileName, string value);
    }
}
