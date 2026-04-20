using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public interface IStoragePickedUpItems
    {
        void AddState(ItemType item, int id);
        ItemType GetState(int id);
    }
}