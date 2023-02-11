using Newtonsoft.Json;
using System.IO;

namespace TREnvironmentControl
{
    public class Settings
    {
        private static readonly string _configPath = "config.json";
        private static Settings _instance;
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(_configPath));
                }
                return _instance;
            }
        }

        private Settings() { }

        public string TR1LevelReadPath { get; set; }
        public string TR1LevelWritePath { get; set; }
        public string TR2LevelReadPath { get; set; }
        public string TR2LevelWritePath { get; set; }
        public string TR3LevelReadPath { get; set; }
        public string TR3LevelWritePath { get; set; }

        public string TR1EnvironmentPath { get; set; }
        public string TR2EnvironmentPath { get; set; }
        public string TR3EnvironmentPath { get; set; }

        public string TR1SecretRoomPath { get; set; }
        public string TR3SecretRoomPath { get; set; }

        public void Serialize()
        {
            File.WriteAllText(_configPath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
