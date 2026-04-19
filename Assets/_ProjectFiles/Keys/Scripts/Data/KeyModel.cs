using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Keys.Scripts.Data
{
    public class KeyModel : ItemModel
    {
        public KeyModel(int id, ItemType type, ChestKeyType chestKeyType) : base(id, type)
        {
            ChestKeyType = chestKeyType;
        }

        public ChestKeyType ChestKeyType { get; private set; }
    }
}