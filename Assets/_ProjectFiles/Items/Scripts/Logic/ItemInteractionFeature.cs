using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Resolvers;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public class ItemInteractionFeature: IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Item;

        public InteractData GetInteractData(Player.Scripts.Core.Player player, InteractableView interactableView)
        {
            if (interactableView is not ItemView itemView)
                return default;

            return new InteractData
            {
                CanInteract = true,
                ActionName = "Осмотреть"
            };
        }

        public void Interact(Player.Scripts.Core.Player player, InteractableView interactableView)
        {
            if (interactableView is not ItemView itemView)
                return;

            // дальше логика предмета
        }
    }
}