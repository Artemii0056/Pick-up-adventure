using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public class ItemInteractionFeature: IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Item;
        
        public InteractData GetInteractData(Player.Scripts.Core.Player player, ItemView itemView)
        {
            throw new System.NotImplementedException();
        }

        public void Interact(Player.Scripts.Core.Player player, ItemView itemView)
        {
            throw new System.NotImplementedException();
        }
    }
}