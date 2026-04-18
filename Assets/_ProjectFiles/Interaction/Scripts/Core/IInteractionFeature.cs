using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface IInteractionFeature
    {
        InteractableItemType Type { get; }
        InteractData GetInteractData(Player.Scripts.Core.Player player, InteractableView interactableView);
        void Interact(Player.Scripts.Core.Player player, InteractableView interactableView);
    }
}