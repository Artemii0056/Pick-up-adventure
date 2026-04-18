using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class SlotInteractionFeature : IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Slot;
        
        public InteractData GetInteractData(Player.Scripts.Core.Player player, ItemView itemView) // Это будет TryGetInteractData
        {
            SlotView slotView = (SlotView)itemView;
            
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

        public void Interact(Player.Scripts.Core.Player player, ItemView itemView)
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