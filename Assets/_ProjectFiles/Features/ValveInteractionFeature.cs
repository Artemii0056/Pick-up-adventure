using _ProjectFiles.InteractableObjects;
using _ProjectFiles.InteractableObjects.Scripts;
using _ProjectFiles.RaycastResolvers.Scripts;

namespace _ProjectFiles.Features
{
    public class ValveInteractionFeature : IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Valve;

        public InteractData GetInteractData(Player player, ItemView itemView)
        {
            return new InteractData
            {
                CanInteract = true,
                ActionName = "Крутить",
            };
        }

        public void Interact(Player player, ItemView itemView)
        {
            ValveView valveView = (ValveView)itemView;
            
            valveView.RotateStep();
        }
    }
}