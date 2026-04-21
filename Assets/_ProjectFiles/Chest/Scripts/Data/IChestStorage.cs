namespace _ProjectFiles.Chest.Scripts.Data
{
    public interface IChestStorage
    {
        void AddState(ChestModel state);
        ChestModel GetState(int id);
        void Remove(int keyModelId);
    }
}