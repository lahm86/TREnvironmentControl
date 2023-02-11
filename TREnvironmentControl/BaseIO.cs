using System.IO;
using TRLevelReader;
using TRLevelReader.Model;

namespace TREnvironmentControl
{
    public class BaseIO
    {
        protected TRLevel GetTR1Level(string lvl)
        {
            return new TR1LevelReader().ReadLevel(Path.Combine(Settings.Instance.TR1LevelReadPath, lvl));
        }

        protected void Write(TRLevel level, string lvl)
        {
            new TR1LevelWriter().WriteLevelToFile(level, Path.Combine(Settings.Instance.TR1LevelWritePath, lvl));
        }

        protected TR2Level GetTR2Level(string lvl)
        {
            return new TR2LevelReader().ReadLevel(Path.Combine(Settings.Instance.TR2LevelReadPath, lvl));
        }

        protected void Write(TR2Level level, string lvl)
        {
            new TR2LevelWriter().WriteLevelToFile(level, Path.Combine(Settings.Instance.TR2LevelWritePath, lvl));
        }

        protected TR3Level GetTR3Level(string lvl)
        {
            return new TR3LevelReader().ReadLevel(Path.Combine(Settings.Instance.TR3LevelReadPath, lvl));
        }

        protected void Write(TR3Level level, string lvl)
        {
            new TR3LevelWriter().WriteLevelToFile(level, Path.Combine(Settings.Instance.TR3LevelWritePath, lvl));
        }

        protected string GetResource(string path)
        {
            return File.ReadAllText(Path.Combine("Resources", path));
        }
    }
}
