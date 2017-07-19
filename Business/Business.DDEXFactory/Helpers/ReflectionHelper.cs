using System.IO;
using System.Reflection;

namespace Business.DDEXFactory.Helpers
{
    public static class ReflectionHelper
    {
        private static Assembly _CurrentAssembly = Assembly.GetExecutingAssembly();
        public static Assembly CurrentAssembly
        {
            get
            {
                return _CurrentAssembly;
            }
        }

        public static string ReadEmbeddedResource(Assembly ass, string resourceName)
        {
            string result = null;

            using (Stream stream = ass.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
                reader.Close();
            }

            return result;
        }
    }
}
