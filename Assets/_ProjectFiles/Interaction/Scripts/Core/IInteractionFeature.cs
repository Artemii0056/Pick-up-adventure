using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface IInteractionFeature
    {
        InteractableItemType Type { get; }
        InteractData GetInteractData(Player.Scripts.Core.Player player ,ItemView itemView);
        void Interact(Player.Scripts.Core.Player player, ItemView itemView);
    }
}