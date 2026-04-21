using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Player.Scripts.Core
{
    public class PlayerHandModel
    {
        public bool HasItem => ItemModel != null;
        
        public ItemModel ItemModel { get; private set; }

        public void Set(ItemModel itemModel) => 
            ItemModel = itemModel;

        public void Clear() => 
            ItemModel = null;
    }
}