using _ProjectFiles.InteractableObjects.Scripts;
using _ProjectFiles.RaycastResolvers.Scripts;

namespace _ProjectFiles.InteractableObjects
{
    public interface IInteractionFeature
    {
        InteractableItemType Type { get; }
        InteractData GetInteractData(Player player ,InteractableEntity interactableEntity);
        void Interact(Player player, InteractableEntity interactableEntity);
    }
}