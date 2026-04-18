using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles
{
    public class ItemModel
    {
        public int Id { get; }
        public ItemType Type { get; }

        public ItemModel(int id, ItemType type)
        {
            Id = id;
            Type = type;
        }
    }
}