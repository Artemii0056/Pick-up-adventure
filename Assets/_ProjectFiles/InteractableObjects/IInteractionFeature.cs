using _ProjectFiles.InteractableObjects.Scripts;
using _ProjectFiles.RaycastResolvers.Scripts;

namespace _ProjectFiles.InteractableObjects
{
    public interface IInteractionFeature
    {
        InteractableItemType Type { get; }
        void Execute(InteractableEntity interactableEntity);
        InteractData GetInteractData(Player player ,InteractableEntity interactableEntity);
    }
}