using System.IO;
using TRLevelReader.Model;

namespace TREnvironmentControl
{
    public abstract class BaseTR1Control : BaseControl<TREntity>
    {
        public override string MappingPath => Path.Combine(Settings.Instance.TR1EnvironmentPath, Level + "-Environment.json");
        public override string SecretRoomPath => Path.Combine(Settings.Instance.TR1SecretRoomPath, Level + "-SecretMapping.json");
    }
}
