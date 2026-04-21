namespace _ProjectFiles.Items.Scripts.Data
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