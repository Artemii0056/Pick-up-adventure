using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Items.Keys.Scripts.Data;

namespace _ProjectFiles.Chest.Scripts.Data
{
    public class ChestModel 
    {
        public ChestModel(int id, InteractableItemType type, ChestKeyType keyType) 
        {
            Id = id;
            Type = type;
            IsOpened = false;
            ReqiereKeyType = keyType;
        }

        public int Id { get; }
        public bool IsOpened { get; private set; }
        public InteractableItemType Type { get; private set; }
        public ChestKeyType ReqiereKeyType { get; private set; }
        
        public bool CanOpenWith(KeyItemModel key)
        {
            return key.ChestKeyType == ReqiereKeyType;
        }

        public void Open()
        {
            IsOpened = true;
        }
    }
}