using System.IO;
using System.Reflection;

namespace AlertToCare_Tests
{
    public class DbPath
    {
        protected static string GetDbPathForTesting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dbPath = Path.GetFullPath(Path.Combine(path ?? string.Empty, @"..\..\..\Hospital.db"));
            return dbPath;
        }
    }
}
