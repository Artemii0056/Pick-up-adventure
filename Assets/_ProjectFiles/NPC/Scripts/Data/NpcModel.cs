using _ProjectFiles.DialogueSystem.Scripts.Data;

namespace _ProjectFiles.NPC.Scripts.Data
{
    public class NpcModel
    {
        public NpcModel(int id, NpcConfig config)
        {
            Id = id;
            Config = config;
        }

        public int Id { get; }
        public NpcConfig Config { get; }
    }
}