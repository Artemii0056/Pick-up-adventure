using _ProjectFiles.Interaction.Scripts.Data;

namespace _ProjectFiles.Chest.Scripts.Data
{
    public interface IChestModelFactory
    {
        ChestModel CreateKeyModel(int id, InteractableItemType itemType);
    }
}