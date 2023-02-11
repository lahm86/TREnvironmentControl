using TREnvironmentEditor;
using TRRandomizerCore.Secrets;

namespace TREnvironmentControl
{
    public abstract class BaseControl<E> : BaseIO
        where E : class
    {
        public abstract string Level { get; }
        public abstract string MappingPath { get; }
        public abstract string SecretRoomPath { get; }
        public abstract void GenerateEnvironmentMapping();
        public virtual void GenerateSecretRoomMapping() { }

        protected EMEditorMapping GetMapping()
        {
            return EMEditorMapping.Get(MappingPath);
        }

        protected void WriteMapping(EMEditorMapping mapping)
        {
            mapping.SerializeTo(MappingPath);
        }

        protected TRSecretMapping<E> GetSecretRoomMapping()
        {
            return TRSecretMapping<E>.Get(SecretRoomPath);
        }

        protected void WriteSecretRoomMapping(TRSecretMapping<E> mapping)
        {
            mapping.SerializeTo(SecretRoomPath);
        }
    }
}
