namespace _ProjectFiles.Items.Scripts.Logic
{
    public interface IItemStorage
    {
        void AddState(ItemModel item);
        ItemModel GetState(int id);
    }
}