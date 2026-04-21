using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Items.Keys.Scripts.Data
{
    public class KeyItemModel : ItemModel
    {
        public KeyItemModel(int id, KeyItemConfig config) : base(id, config)
        {
            ChestKeyType = config.ChestKeyType;
        }

        public ChestKeyType ChestKeyType { get; }
    }
}