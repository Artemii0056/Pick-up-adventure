using _ProjectFiles.InteractableObjects;
using _ProjectFiles.InteractableObjects.Scripts;
using _ProjectFiles.RaycastResolvers.Scripts;

namespace _ProjectFiles.Features
{
    public class ItemInteractionFeature: IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Item;
        
        public InteractData GetInteractData(Player player, ItemView itemView)
        {
            throw new System.NotImplementedException();
        }

        public void Interact(Player player, ItemView itemView)
        {
            throw new System.NotImplementedException();
        }
    }
}