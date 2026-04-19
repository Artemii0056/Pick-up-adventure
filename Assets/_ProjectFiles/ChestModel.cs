using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.Data;

namespace _ProjectFiles
{
    public class ChestModel 
    {
        private readonly InteractableItemType _type;

        public ChestModel(int id, InteractableItemType type) 
        {
            _type = type;
            Id = id;
            IsOpened = false;
            ReqiereKeyType = ChestKeyType.None;
        }

        public int Id { get; }
        public bool IsOpened { get; private set; }
        public InteractableItemType Type { get; private set; }
        public ChestKeyType ReqiereKeyType { get; private set; }

        public void Open()
        {
            IsOpened = true;
        }
    }
}