using _ProjectFiles.Interaction.Scripts.Data;

namespace _ProjectFiles.Chest.Scripts.Data
{
    public class ChestModelFactory : IChestModelFactory
    {
        private readonly IChestStorage _chestStorage;

        public ChestModelFactory(IChestStorage chestStorage)
        {
            _chestStorage = chestStorage;
        }

        public ChestModel CreateKeyModel(int id, InteractableItemType itemType)
        {
            ChestModel chestModel = new ChestModel(id, itemType);
            
            _chestStorage.AddState(chestModel);
            
            return chestModel;
        }
    }
}