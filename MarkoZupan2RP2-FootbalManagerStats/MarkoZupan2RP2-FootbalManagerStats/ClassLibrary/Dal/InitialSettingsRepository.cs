using ClassLibrary.Constants;
using ClassLibrary.Models;
using Newtonsoft.Json;

namespace ClassLibrary.Dal
{
    public class InitialSettingsRepository : ISingleEntityFileLoaderSaver<InitialSetting>
    {
        public async Task<InitialSetting> LoadFromFile(string filePath)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.InitalSettingsDir);
            string filepath = Path.Combine(dir, LocalPaths.InitialSettingsFile);

            if (!File.Exists(filepath))
                    return new InitialSetting();

            string json = await File.ReadAllTextAsync(filepath);

            var initialSetting = JsonConvert.DeserializeObject<InitialSetting>(json);
            return initialSetting ?? new InitialSetting();
        }

        public async Task SaveToFile(InitialSetting setting, string filePath)
        {
            if(setting == null)
                throw new ArgumentNullException(nameof(setting), "Data to save cannot be null.");

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                                                        LocalPaths.ParentFolder, 
                                                        LocalPaths.InitalSettingsDir);
            Directory.CreateDirectory(dir);
            string file = Path.Combine(dir, filePath);
            string json = JsonConvert.SerializeObject(setting, Formatting.Indented);
            await File.WriteAllTextAsync(file, json);
        }
    }
}
