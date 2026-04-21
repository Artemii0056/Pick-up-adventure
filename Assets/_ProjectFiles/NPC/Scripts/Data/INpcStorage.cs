namespace _ProjectFiles.NPC.Scripts.Data
{
    public interface INpcStorage
    {
        void AddState(NpcModel item);
        NpcModel GetState(int id);
        bool TryGetState(int npcId, out NpcModel model);
    }
}