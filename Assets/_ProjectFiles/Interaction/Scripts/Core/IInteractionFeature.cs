using _ProjectFiles.InteractableObjects.Scripts;
using _ProjectFiles.RaycastResolvers.Scripts;

namespace _ProjectFiles.InteractableObjects
{
    public interface IInteractionFeature
    {
        InteractableItemType Type { get; }
        InteractData GetInteractData(Player.Scripts.Core.Player player ,ItemView itemView);
        void Interact(Player.Scripts.Core.Player player, ItemView itemView);
    }
}