using _ProjectFiles.Items;
using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles
{
    public class ItemModel
    {
        public ItemModel(int id, BaseItemConfig config)
        {
            Id = id;
            Config = config;
            Type = config.Type;
        }
        
        public int Id { get; }
        public ItemType Type { get; }
        public BaseItemConfig Config { get;  }
    }
}