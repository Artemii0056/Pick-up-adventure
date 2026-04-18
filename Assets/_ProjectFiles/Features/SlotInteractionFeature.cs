using _ProjectFiles.InteractableObjects;
using _ProjectFiles.InteractableObjects.Scripts;
using _ProjectFiles.RaycastResolvers.Scripts;
using DefaultNamespace;

namespace _ProjectFiles.Features
{
    public class SlotInteractionFeature : IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Slot;
        
        public InteractData GetInteractData(Player player, InteractableEntity interactableEntity) // Это будет TryGetInteractData
        {
            Slot slot = (Slot)interactableEntity;
            
            if (player.Hand is not Item item)
                return new InteractData
                {
                    CanInteract = true,
                    ActionName = "Положить",
                };

            //проверить, если вообще Item в Холдере
            //Взять Id слота и сравнить с id предмета

            if (player.Hand == null)
                return default;

            return new InteractData
            {
                CanInteract = true,
                ActionName = "Положить",
            };
        }

        public void Interact(Player player, InteractableEntity interactableEntity)
        {
            // if (request.Target is not ItemSlot slot)
            //     return;
            //
            // Player player = request.Player;
            //
            // if (player.Hand is not Item item)
            //     return;
            //
            // if (item.OriginSlot != slot)
            //     return;
            //
            // player.ClearHand();
            // item.ReturnToSlot(slot);
        }
    }
}