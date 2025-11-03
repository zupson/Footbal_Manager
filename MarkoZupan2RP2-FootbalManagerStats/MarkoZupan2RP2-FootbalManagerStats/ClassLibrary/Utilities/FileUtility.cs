namespace ClassLibrary.Utilities
{
    public class FileUtility
    {
        private const string projectName = "ClassLibrary";
        private const string parentFolderName = "Data";

        public static string GetFilePath(string fileName)
        {
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string solutionDir = Directory.GetParent(dir).FullName;

            string dataFolderPath = Path.Combine(solutionDir, projectName, parentFolderName);

            if (!Directory.Exists(dataFolderPath))
                Directory.CreateDirectory(dataFolderPath);

            return Path.Combine(dataFolderPath,fileName);
        }
       
    }
}
